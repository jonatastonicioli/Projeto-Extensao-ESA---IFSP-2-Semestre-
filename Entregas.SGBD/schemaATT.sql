
DROP DATABASE IF EXISTS esa;
CREATE DATABASE esa;
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

-- ---------------------------------------------------------------------
--  COMPETIDORES, INSCRIÇÕES E NOTAS DE EXEMPLO
--    perfil: 1 Administrador, 2 Competidor, 3 Avaliador
--    usuario: 1 a 3 são os avaliadores; 4 a 9 são os competidores abaixo
--    instituicao: 1 SENAI Roberto Mange, 2 IFSP Campinas, 3 SENAI Suíço-Brasileira
--    modalidade: 1 Usinagem CNC, 2 Mecatrônica  |  edicao: 1 Regional, 2 Estadual
--    avaliador: 1 Carlos, 2 Mariana, 3 Rafael
-- ---------------------------------------------------------------------

-- usuários dos competidores (ids 4 a 9)
INSERT INTO usuario (nome, email, perfil_id) VALUES
    ('Ana Beatriz Rocha', 'ana.rocha@esa.exemplo', 2),
    ('Bruno Henrique Dias', 'bruno.dias@esa.exemplo', 2),
    ('Camila Fernandes Torres', 'camila.torres@esa.exemplo', 2),
    ('Diego Martins Oliveira', 'diego.oliveira@esa.exemplo', 2),
    ('Eduarda Lopes Santos', 'eduarda.santos@esa.exemplo', 2),
    ('Felipe Augusto Barbosa', 'felipe.barbosa@esa.exemplo', 2);

-- competidores (usuario_id, instituicao_id)
INSERT INTO competidor (usuario_id, instituicao_id) VALUES
    (4, 1),  -- Ana Beatriz Rocha
    (5, 1),  -- Bruno Henrique Dias
    (6, 2),  -- Camila Fernandes Torres
    (7, 2),  -- Diego Martins Oliveira
    (8, 3),  -- Eduarda Lopes Santos
    (9, 3);  -- Felipe Augusto Barbosa


-- telefones (competidor_id, numero)
INSERT INTO telefone (competidor_id, numero) VALUES
    (1, '(19) 99871-2301'),
    (2, '(19) 99872-4410'),
    (3, '(19) 99873-5502'),
    (4, '(19) 99874-6613'),
    (5, '(11) 99875-7724'),
    (6, '(11) 99876-8835');

-- inscrições (competidor_id, modalidade_id, edicao_id, data)
INSERT INTO inscricao (competidor_id, modalidade_id, edicao_id, data) VALUES
    (1, 1, 1, '2026-08-10'),  -- inscrição 1: Ana Beatriz Rocha, Etapa Regional
    (2, 2, 1, '2026-08-11'),  -- inscrição 2: Bruno Henrique Dias, Etapa Regional
    (3, 1, 1, '2026-08-12'),  -- inscrição 3: Camila Fernandes Torres, Etapa Regional
    (4, 2, 1, '2026-08-13'),  -- inscrição 4: Diego Martins Oliveira, Etapa Regional
    (5, 1, 1, '2026-08-14'),  -- inscrição 5: Eduarda Lopes Santos, Etapa Regional
    (6, 2, 1, '2026-08-15'),  -- inscrição 6: Felipe Augusto Barbosa, Etapa Regional
    (1, 1, 2, '2026-10-05'),  -- inscrição 7: Ana Beatriz Rocha, Etapa Estadual
    (2, 2, 2, '2026-10-06');  -- inscrição 8: Bruno Henrique Dias, Etapa Estadual

-- notas (inscricao_id, avaliador_id, valor)
INSERT INTO nota (inscricao_id, avaliador_id, valor) VALUES
    (1, 1, 72.1),
    (1, 2, 71.5),
    (2, 3, 83.5),
    (2, 2, 80.6),
    (3, 1, 83.1),
    (3, 2, 83.5),
    (4, 3, 91.7),
    (4, 2, 89.7),
    (5, 1, 67.3),
    (5, 2, 71.8),
    (6, 3, 68.7),
    (6, 2, 77.2),
    (7, 1, 73.3),
    (7, 2, 77.6),
    (8, 3, 85.3),
    (8, 2, 85.2);
