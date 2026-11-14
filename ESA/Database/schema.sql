-- ESA - Evaluation System Analyzer
-- Execute este script INTEIRO no MySQL (Workbench: File > Open SQL Script > raio) antes de abrir o programa.
-- Ele cria o banco "esa" com 14 tabelas e alguns dados de exemplo.
-- Atenção: ao rodar de novo, o banco "esa" inteiro é apagado e recriado (os dados são perdidos).

DROP DATABASE IF EXISTS esa;
CREATE DATABASE esa CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE esa;

-- =====================================================================
--  ACESSO E PESSOAS
-- =====================================================================
CREATE TABLE perfil (
    id   INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE usuario (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    nome       VARCHAR(80)  NOT NULL,
    email      VARCHAR(100) NOT NULL UNIQUE,
    senha_hash VARCHAR(255) NOT NULL DEFAULT '',   -- reservado para a autenticação (requisito adiável)
    ativo      BOOLEAN      NOT NULL DEFAULT TRUE,
    perfil_id  INT          NOT NULL,
    FOREIGN KEY (perfil_id) REFERENCES perfil (id)
);

-- localização (normalizada: estado -> cidade -> instituição)
CREATE TABLE estado (
    id    INT AUTO_INCREMENT PRIMARY KEY,
    sigla CHAR(2)     NOT NULL UNIQUE,
    nome  VARCHAR(40) NOT NULL
);

CREATE TABLE cidade (
    id        INT AUTO_INCREMENT PRIMARY KEY,
    nome      VARCHAR(60) NOT NULL,
    estado_id INT         NOT NULL,
    FOREIGN KEY (estado_id) REFERENCES estado (id)
);

CREATE TABLE instituicao (
    id        INT AUTO_INCREMENT PRIMARY KEY,
    nome      VARCHAR(100) NOT NULL UNIQUE,
    cidade_id INT          NOT NULL,
    FOREIGN KEY (cidade_id) REFERENCES cidade (id)
);

CREATE TABLE competidor (
    id             INT AUTO_INCREMENT PRIMARY KEY,
    usuario_id     INT NOT NULL UNIQUE,
    instituicao_id INT NOT NULL,
    -- apagar o usuário apaga o competidor (e, em cascata, telefones, inscrições e notas)
    FOREIGN KEY (usuario_id)     REFERENCES usuario (id) ON DELETE CASCADE,
    FOREIGN KEY (instituicao_id) REFERENCES instituicao (id)
);

-- um competidor pode ter vários telefones
CREATE TABLE telefone (
    id            INT AUTO_INCREMENT PRIMARY KEY,
    competidor_id INT         NOT NULL,
    numero        VARCHAR(20) NOT NULL,
    FOREIGN KEY (competidor_id) REFERENCES competidor (id) ON DELETE CASCADE
);

CREATE TABLE avaliador (
    id            INT AUTO_INCREMENT PRIMARY KEY,
    usuario_id    INT NOT NULL UNIQUE,
    especialidade VARCHAR(60) NULL,
    FOREIGN KEY (usuario_id) REFERENCES usuario (id) ON DELETE CASCADE
);

-- =====================================================================
--  COMPETIÇÃO
-- =====================================================================
CREATE TABLE modalidade (
    id        INT AUTO_INCREMENT PRIMARY KEY,
    nome      VARCHAR(60)  NOT NULL UNIQUE,
    descricao VARCHAR(255) NULL
);

CREATE TABLE fase (
    id   INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE edicao (
    id          INT AUTO_INCREMENT PRIMARY KEY,
    ano         INT  NOT NULL,
    fase_id     INT  NOT NULL,
    data_inicio DATE NOT NULL,
    data_fim    DATE NOT NULL,
    UNIQUE KEY uk_edicao (ano, fase_id),
    FOREIGN KEY (fase_id) REFERENCES fase (id)
);

CREATE TABLE inscricao (
    id            INT AUTO_INCREMENT PRIMARY KEY,
    competidor_id INT  NOT NULL,
    modalidade_id INT  NOT NULL,
    edicao_id     INT  NOT NULL,
    data          DATE NOT NULL,
    UNIQUE KEY uk_inscricao (competidor_id, modalidade_id, edicao_id),
    FOREIGN KEY (competidor_id) REFERENCES competidor (id) ON DELETE CASCADE,
    FOREIGN KEY (modalidade_id) REFERENCES modalidade (id),
    FOREIGN KEY (edicao_id)     REFERENCES edicao (id)
);

CREATE TABLE prova (
    id            INT AUTO_INCREMENT PRIMARY KEY,
    modalidade_id INT         NOT NULL,
    edicao_id     INT         NOT NULL,
    nome          VARCHAR(80) NOT NULL,
    duracao_min   INT         NOT NULL,
    data_hora     DATETIME    NOT NULL,
    FOREIGN KEY (modalidade_id) REFERENCES modalidade (id),
    FOREIGN KEY (edicao_id)     REFERENCES edicao (id)
);

-- =====================================================================
--  AVALIAÇÃO
-- =====================================================================
CREATE TABLE nota (
    id              INT AUTO_INCREMENT PRIMARY KEY,
    inscricao_id    INT          NOT NULL,
    avaliador_id    INT          NOT NULL,
    valor           DECIMAL(5,2) NOT NULL,
    data_lancamento DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CHECK (valor >= 0 AND valor <= 100),
    FOREIGN KEY (inscricao_id) REFERENCES inscricao (id) ON DELETE CASCADE,
    FOREIGN KEY (avaliador_id) REFERENCES avaliador (id)
);

-- =====================================================================
--  DADOS DE EXEMPLO
--  Os competidores, inscrições e notas são cadastrados pelo programa.
-- =====================================================================
INSERT INTO perfil (nome) VALUES ('Administrador'), ('Competidor'), ('Avaliador');

INSERT INTO estado (sigla, nome) VALUES ('SP', 'São Paulo'), ('MG', 'Minas Gerais'), ('RJ', 'Rio de Janeiro');

INSERT INTO cidade (nome, estado_id) VALUES
    ('Campinas',  (SELECT id FROM estado WHERE sigla = 'SP')),
    ('São Paulo', (SELECT id FROM estado WHERE sigla = 'SP'));

INSERT INTO instituicao (nome, cidade_id) VALUES
    ('SENAI Roberto Mange',    (SELECT id FROM cidade WHERE nome = 'Campinas')),
    ('IFSP Campinas',          (SELECT id FROM cidade WHERE nome = 'Campinas')),
    ('SENAI Suíço-Brasileira', (SELECT id FROM cidade WHERE nome = 'São Paulo'));

INSERT INTO modalidade (nome, descricao) VALUES
    ('Usinagem CNC', 'Fabricação de peças em máquinas de comando numérico computadorizado'),
    ('Mecatrônica',  'Montagem, programação e manutenção de sistemas mecatrônicos');

INSERT INTO fase (nome) VALUES ('Etapa Regional'), ('Etapa Estadual');

INSERT INTO edicao (ano, fase_id, data_inicio, data_fim) VALUES
    (2026, (SELECT id FROM fase WHERE nome = 'Etapa Regional'), '2026-09-14', '2026-09-18'),
    (2026, (SELECT id FROM fase WHERE nome = 'Etapa Estadual'), '2026-11-23', '2026-11-27');

INSERT INTO usuario (nome, email, perfil_id) VALUES
    ('Carlos Eduardo Lima',  'carlos.lima@esa.exemplo',    (SELECT id FROM perfil WHERE nome = 'Avaliador')),
    ('Mariana Souza Alves',  'mariana.alves@esa.exemplo',  (SELECT id FROM perfil WHERE nome = 'Avaliador')),
    ('Rafael Nunes Pereira', 'rafael.pereira@esa.exemplo', (SELECT id FROM perfil WHERE nome = 'Avaliador'));

INSERT INTO avaliador (usuario_id, especialidade) VALUES
    ((SELECT id FROM usuario WHERE email = 'carlos.lima@esa.exemplo'),    'Usinagem CNC'),
    ((SELECT id FROM usuario WHERE email = 'mariana.alves@esa.exemplo'),  'Usinagem CNC e Mecatrônica'),
    ((SELECT id FROM usuario WHERE email = 'rafael.pereira@esa.exemplo'), 'Mecatrônica');

-- uma prova por modalidade em cada edição
INSERT INTO prova (modalidade_id, edicao_id, nome, duracao_min, data_hora)
SELECT m.id, e.id, CONCAT(IF(m.nome = 'Usinagem CNC', 'Peça de usinagem', 'Projeto mecatrônico'), ' - ', f.nome),
       IF(f.nome = 'Etapa Regional', 240, 300),
       IF(f.nome = 'Etapa Regional', '2026-09-15 08:00:00', '2026-11-24 08:00:00')
FROM modalidade m CROSS JOIN edicao e JOIN fase f ON f.id = e.fase_id;
