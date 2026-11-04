# ESA – Evaluation System Analyzer (C# / WinForms / MySQL)

Migração do protótipo em C para C# com interface gráfica Windows Forms e persistência em MySQL (ADO.NET).

## Como executar
1. Instale o .NET 8 SDK e o MySQL Server.
2. Execute o script `ESA/Database/schema.sql` no MySQL (Workbench ou linha de comando) para criar o banco `esa` e as tabelas.
3. Ajuste a conexão (padrão: `Server=localhost;Port=3306;Uid=root;Pwd=root;`) pela variável de ambiente:
   `setx ESA_MYSQL_CONN "Server=localhost;Port=3306;Uid=root;Pwd=SUA_SENHA;"`
4. Abra `ESA.sln` no Visual Studio 2022 (carga de trabalho "Desenvolvimento para desktop com .NET"), aguarde a restauração do pacote NuGet `MySql.Data` e pressione F5. Também funciona com `dotnet run --project ESA`.

## Estrutura
- `Models/` – `Aluno`, `Pontuacao`, `Metricas`, `RegraNegocioException` (campos, public/private, construtores, getters/setters, métodos).
- `Data/` – `Database`, `AlunoRepository`, `PontuacaoRepository` (INSERT, UPDATE, DELETE, SELECT via `MySqlConnection`/`MySqlCommand`).
- `Forms/` – 7 janelas (cada uma em `.cs` + `.Designer.cs`, editáveis no designer visual): Principal, Alunos, Pontuação, Métricas, Ranking, Relatório e Gráfico.

## Mapa de requisitos
| Requisito | Onde |
|---|---|
| RF-01 Cadastrar | `FormAlunos` + `AlunoRepository.Inserir` (nome ≥2 letras/espaços, máx. 50) |
| RF-02 Listar | `FormAlunos` |
| RF-03 Remover | `FormAlunos` + `AlunoRepository.Remover` (cascade apaga pontuações) |
| RF-04 Registrar pontuação | `FormPontuacao` (0–100, máx. 20 peças) |
| RF-05 Histórico | `FormMetricas` / `FormPontuacao` |
| RF-06/07 Métricas | `Metricas.Calcular` + `FormMetricas` |
| RF-08 Ranking | `FormRanking` ("N/A" sem notas) |
| RF-09 Relatório | `FormRelatorio` |
| RF-10 Gráfico | `FormGrafico` (GDI+, mínimo 2 pontuações) |
| RF-11 MySQL | `Data/` |

## Requisitos mínimos do Projeto de Extensão
- Mais de uma janela WinForms ✔
- Classes próprias com campos, `public`/`private`, construtor, getters/setters e métodos com parâmetros e retorno ✔
- Referências: repositórios criados em `Program.cs` e passados por referência às janelas ✔
- Exceções: `FormatException` (`double.Parse`), `MySqlException` e `RegraNegocioException` (via `throw`) ✔
- MySQL com ADO.NET: inserção, atualização e remoção ✔

## Fora do escopo (adiáveis / não implementados)
- Autenticação e criptografia de dados sensíveis (RNF-01/RNF-10) – listados como adiáveis no LR.
- Migração dos dados do `esa_dados.dat` antigo (restrição 4 do LR): não incluída; peça se quiser um importador.
