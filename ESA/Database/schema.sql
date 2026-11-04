-- ESA - Evaluation System Analyzer
-- Script de criação do banco (o programa também executa isto automaticamente na inicialização).

CREATE DATABASE IF NOT EXISTS esa CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE esa;

CREATE TABLE IF NOT EXISTS alunos (
    id   INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS pontuacoes (
    id            INT AUTO_INCREMENT PRIMARY KEY,
    aluno_id      INT NOT NULL,
    valor         DECIMAL(5,2) NOT NULL,
    data_registro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_pontuacao_aluno FOREIGN KEY (aluno_id)
        REFERENCES alunos(id) ON DELETE CASCADE,
    CONSTRAINT ck_valor CHECK (valor >= 0 AND valor <= 100)
);
