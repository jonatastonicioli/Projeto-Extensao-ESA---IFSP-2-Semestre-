using System.Data;
using ESA.Models;

namespace ESA.Forms;

/// <summary>Inscrição de competidores em uma modalidade de uma edição.</summary>
public partial class FormInscricoes : Form
{
    private Cadastro cadastro; //referencia para o objeto cadastro criado no program.cs
    private DataTable tabela = new DataTable(); //objeto tabela criado para atualizar o grid na funcao carregarGrid()

    public FormInscricoes(Cadastro cadastro)
    {
        InitializeComponent();
        this.cadastro = cadastro;
    }

    private void FormInscricoes_Load(object? sender, EventArgs e) //Quando a tela é inicializada isso acontece: 
    {
        try
        {
            cmbCompetidor.DataSource = cadastro.listarCompetidores(); //ComboBox preenchidos
            cmbModalidade.DataSource = cadastro.listarModalidades(); //ComboBox preenchidos
            cmbEdicao.DataSource = cadastro.listarEdicoes(); //ComboBox preenchidos
            carregarGrid(); //Datagrid atualizado
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void carregarGrid() //funcao para recarregar o drid
    {
        cadastro.gerarRelatorioInscricoes(tabela);
        dgvInscricoes.DataSource = tabela;
    }

    private int idSelecionado()
    {
        if (dgvInscricoes.CurrentRow == null) return -1;
        return Convert.ToInt32(dgvInscricoes.CurrentRow.Cells["ID"].Value);
    }

    private static int idDoItem(object? selecionado)
    {
        Item? item = selecionado as Item;
        return item == null ? 0 : item.getId();
    }

    private void btnInscrever_Click(object? sender, EventArgs e)
    {
        try
        {
            Inscricao inscricao = new Inscricao(idDoItem(cmbCompetidor.SelectedItem), //vai para o Models/Inscricao.cs fazer as validações
                                                idDoItem(cmbModalidade.SelectedItem),
                                                idDoItem(cmbEdicao.SelectedItem));

            cadastro.inserirInscricao(inscricao);
            carregarGrid(); //atualiza o grid depois do cadastro "DPS DE APERTAR O BOTAO"
            Ferramentas.mostraAviso("Inscrição realizada com sucesso.");
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }

    private void btnRemover_Click(object? sender, EventArgs e)
    {
        int id = idSelecionado(); //descobre qual competidor esta selecionado
        if (id < 0) //se nada esta selecionado
        {
            Ferramentas.mostraAviso("Selecione uma inscrição na tabela.");
            return;
        }

        if (!Ferramentas.confirma("Remover a inscrição selecionada?\nAs notas dela também serão apagadas.")) //pergunta para o usuario se tem certeza
            return;

        try
        {
            cadastro.removerInscricao(id); //chama o cadastro e remove o competidor
            carregarGrid(); //recarrega o grid
        }
        catch (Exception ex) { Ferramentas.tratarExcecao(ex); }
    }
}
