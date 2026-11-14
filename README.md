# ESA – Evaluation System Analyzer

Projeto de Extensão (IFSP) – sistema de avaliação de competições (SENAI Roberto Mange, Usinagem CNC).
C# .NET 8 + WinForms + MySQL (ADO.NET), seguindo o modelo de cadastro do professor.

## Como executar

1. Abra o MySQL e execute o script `ESA/Database/schema.sql` (cria o banco `esa`, as 12 tabelas e os dados iniciais).
2. Em `ESA/Cadastro.cs`, confira a connection string (padrão: `server=127.0.0.1;uid=root;pwd=ifsp;database=esa`). Troque a senha se a sua for outra.
3. Abra `ESA.sln` no Visual Studio 2022 (workload "Desenvolvimento para desktop com .NET"), restaure o NuGet (`MySql.Data 8.4.0`) e pressione F5.

O programa **não** cria o banco: ele só testa a conexão ao iniciar e avisa se algo estiver errado.

## Estrutura

```
ESA.sln
ESA/
  Program.cs          cria UM objeto Cadastro e abre o FormPrincipal
  Cadastro.cs         TODO o acesso ao MySQL (conexão única, comandos com parâmetros)
  Ferramentas.cs      mensagens/erros e configuração de grids
  Models/             Competidor, Inscricao, Nota, Item, RegraNegocioException
  Forms/              5 janelas (.cs + .Designer.cs)
  Database/schema.sql script do banco
```

## Banco de dados (14 tabelas)

perfil, usuario, estado, cidade, instituicao, competidor, telefone, avaliador, modalidade, fase, edicao, inscricao, prova, nota.
Normalizado: estado → cidade → instituição, fase em tabela própria, telefones separados do competidor.
Usa chaves estrangeiras com `ON DELETE CASCADE` (usuario → competidor → telefone/inscricao → nota), chaves únicas e CHECK na nota (0–100), sem a palavra `CONSTRAINT`.
O script faz `DROP DATABASE IF EXISTS esa` e recria tudo. Estados, cidades, instituições, modalidades, fases, edições, avaliadores e provas vêm populados (sem telas de cadastro).

## Requisitos do professor

- Várias janelas: Principal, Competidores, Inscrições, Notas e Ranking.
- Classes próprias com atributos privados, construtores, getX/setX e métodos com parâmetros/retorno.
- Referência passada entre janelas: o `Cadastro` é entregue a cada formulário pelo construtor.
- Exceções: do sistema (`FormatException`, `MySqlException`) e própria (`RegraNegocioException`, lançada com `throw`).
- ADO.NET: insert, update, delete e select (DataTable para grids) em `Cadastro.cs`.

## Requisitos do ESA

RF-01..03 Competidores (limite de 50) · RF-04/05 Notas (0–100, máx. 20 por inscrição) · RF-06 Média/maior/menor ·
RF-07 Histórico de notas · RF-08 Ranking (média simples, "N/A" sem notas).
Removidos: status da inscrição, RF-09 (relatório), RF-10 (gráfico), solicitações/anexos, critérios de avaliação e avaliador por modalidade.

## Não implementado

Login/senha (`usuario.senha_hash` fica vazio) e migração dos antigos arquivos `.dat`.
