using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AtividadePratica2
{

    public partial class Form1 : Form
    {
        
        Dictionary<string, List<Filmes>> Dicionario = new Dictionary<string, List<Filmes>>();
        List<Filmes> f = new List<Filmes>();
        List<Filmes> listafilmes;
        List<Filmes> listEdit = new List<Filmes>();
        List<Filmes> l = new List<Filmes>();
        List<Filmes> lp = new List<Filmes>();
        List<Filmes> listatotal = new List<Filmes>();
        ListViewItem lf = new ListViewItem();
        Filmes filmeencontrado;
        Filmes cobaia;
        Filmes encontrado;
        Filmes FE;
        List<Filmes> ListaPesquisaTOTAL = new List<Filmes>();
        
        //Método usado para armazenamento dos filmes no listView1
        public void Adicionar()
        {
            
            Filmes filme = new Filmes();

            if (txtnome.Text == "" || textBox1.Text == "" || cbGenero.Text == "")
            {
                foreach (Control c in tabPage1.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox t = (TextBox)c;
                        if (t.Text == "")
                        {
                            errorProvider1.SetError(t, "*Campo obrigatório");
                        }
                        else
                        {
                            errorProvider1.SetError(t, "");
                        }
                    }
                }
                foreach (Control c in tabPage1.Controls)
                {
                    if (c is ComboBox)
                    {
                        ComboBox t = (ComboBox)c;
                        if (t.Text == "")
                        {
                            errorProvider1.SetError(t, "*Campo obrigatório");
                        }
                        else
                        {
                            errorProvider1.SetError(t, "");
                        }
                    }
                }
            }
            else
            {
                errorProvider1.Clear();
                //usar um método do dicionario para verificar se a lista ja esta la!
                //usar a chave do dicionario para esta verificação!!!!
                //List<Filmes> lista = new List<Filmes>();
                if (txtnome.Text != "" || cbGenero.Text != "")
                {
                    filme.NomeFilme = txtnome.Text;
                    filme.generofilme = cbGenero.Text;
                    filme.DATA = datatimerdata.Value;
                    filme.local = textBox1.Text;

                    if (Dicionario.ContainsKey(cbGenero.Text))
                    {

                        //Esta lista de filmes 'r' é a referencia da lista 'lista' logo a baixo do código na condição else
                        List<Filmes> l = Dicionario[cbGenero.Text];
                        //ADICIONA NO LIST VIEW
                        l.Add(filme);
                    }
                    else
                    {
                        //Cria nova lista de filmes, servirá como referencia para a condição de verificação da chave do dicionário
                        //Adiciona filmes na lista 
                        List<Filmes> l = new List<Filmes>();
                        //ele adiciona na lista de filmes
                        l.Add(filme);
                        ////Adiciona no dicionario a chave cbGenero e a lista
                        Dicionario.Add(cbGenero.Text, l);
                    }
                }
                //Cria a lista para adicionar grupos e items de determinado grupo, dependendo do que ele selecionar no seu Genero ele entra nas condições e a condição verdadeira será o seu grupo..
                //OBS: os grupos criados sempre será o nome do gênero que voce selecionar no seu ComboBox.
                lf = new ListViewItem();

                lf.Group = listView1.Groups[filme.generofilme];
                lf.Text = txtnome.Text;
                lf.SubItems.Add(cbGenero.Text);
                lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                lf.SubItems.Add(textBox1.Text);
                listView1.Items.Add(lf);

                //Método criado para limpar campos.

                limpar();
                
            }
        }



        public void AdicionaLW2()
        {
            

            ListViewItem ap = new ListViewItem();
            ap.Text = cobaia.NomeFilme;
            ap.Group = listView2.Groups[cobaia.generofilme];
            listView2.Items.Add(ap);
            ap.SubItems.Add(cobaia.DATA.ToShortDateString());
            ap.SubItems.Add(cobaia.local);
           
           
        }



        public Form1()
        {
            InitializeComponent();
        }

        //funcao que limpa todos os campos
        public void limpar()
        {
            txtnome.Clear();
            cbGenero.Text = "";
            datatimerdata.Text = DateTime.Now.ToShortDateString();
            textBox1.Clear();
        }
        //BOTAO ADICIONAR
        private void button1_Click(object sender, EventArgs e)
        {
            Adicionar();
        }
        //BOTAO REMOVER
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count <= 0)
            {
                button3.Enabled = false;
            }
                listafilmes = Dicionario[listView1.SelectedItems[0].Group.Header];
                //remove os itens da lista
                for (int i = 0; i < listafilmes.Count; i++)
                {
                    Filmes encontrado = listafilmes[i];
                    if (encontrado.NomeFilme == listView1.SelectedItems[0].Text)
                    {
                        listafilmes.Remove(encontrado);
                    }
                }
                //O laço vai percorrer a lista, e quando encontrar o item selecionado irá removelo do ListView
                for (int i = listView1.SelectedItems.Count - 1; i >= 0; --i)
                {
                    ListViewItem remove = listView1.SelectedItems[i];
                    listView1.Items.Remove(remove);

                }
                button3.Enabled = false;

        }

        //BOTAO EDITAR 
        private void button4_Click(object sender, EventArgs e)
        {
            //pega o objeto do grupo selecionado e joga em um List
            listafilmes = Dicionario[listView1.SelectedItems[0].Group.Header];
            for (int i = 0; i < listafilmes.Count; i++)
            {
                //criei uma variavel local do meu objeto filme e atribui o item do listafilmes para a variavel l.
                Filmes encontrado = listafilmes[i];
                if (encontrado.NomeFilme == listView1.SelectedItems[0].Text)
                {
                    encontrado.NomeFilme = txtnome.Text;
                    encontrado.local = textBox1.Text;
                    encontrado.generofilme = cbGenero.SelectedItem.ToString();
                    encontrado.DATA = datatimerdata.Value.Date;
                    if (Dicionario.ContainsKey(encontrado.generofilme))
                    {
                        List<Filmes> list = Dicionario[encontrado.generofilme];
                        list.Add(encontrado);
                    }
                    else
                    {
                        List<Filmes> list = new List<Filmes>();
                        list.Add(encontrado);
                        Dicionario.Add(encontrado.generofilme, list);
                    }
                    listafilmes.Remove(encontrado);
                }
            }
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem atualiza = listView1.SelectedItems[i];
                atualiza.Group = listView1.Groups[cbGenero.SelectedIndex];
                atualiza.Text = txtnome.Text;
                atualiza.SubItems[1].Text = cbGenero.Text;
                atualiza.SubItems[2].Text = datatimerdata.Value.ToShortDateString();
                atualiza.SubItems[3].Text = textBox1.Text;
            }
        }

        //Evento de double click quando ele clicar no item da lista duas vezes
        //vai jogar todos os valores do objeto dentro dos campos.
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                
                //coloca os itens e subitens nos texboxs para edição
                txtnome.Text = listView1.SelectedItems[0].Text;
                datatimerdata.Text= listView1.FocusedItem.SubItems[2].Text;
                textBox1.Text = listView1.FocusedItem.SubItems[3].Text;
                
                cbGenero.Text = listView1.SelectedItems[0].Group.Header;
                
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            //ligando os grupos do listView aos valores do combobox
            //cbGenero.DataSource = listView1.Groups;
        }




        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (cbgenerop.SelectedItem != null)
            {
                //condição que verifica se a a chave fornecida pelo usuario na hora da pesquisa é válida, se nao for válida, ele vai dizer  que nao existe filme cadastrado com este genero!
                if (Dicionario.ContainsKey(cbgenerop.SelectedItem.ToString()))
                {
                    //a lista pesqlist pega os valores da chave do meu dicionario
                    List<Filmes> pesqlist = Dicionario[cbgenerop.Text];

                    //laço que vai percorrer cada valor da chave do dicionario e vai adicionando os valores que contem em cada chave no objeto FE da classe Filmes, ele verifica se o checkbox da data da checado ou nao, se tiver ele verifica se o meu objeto contem as datas menores que a inicial que eu estou procurando, e se até aonde eu estou procurando a data do meu objeto é MENOR se for, ele tem que apresentar o filme que esta marcado, se nao ele simplismente pega os campos que tiverem preenchidos e faz a pesquisa e vai encontra cazo meu dicionario possua o filme, caso nao tenha ele vai retornar um valor vazio no list view 2 
                    for (int i = 0; i < pesqlist.Count; i++)
                    {
                        FE = new Filmes();
                        //pega o objeto de cada filme que esta no pesqlist
                        FE = pesqlist[i];
                        //se a data nao for checada entra no if, se nao vai para outra condição
                        if (cbd.Checked == false)
                        {
                            //aqui ele faz a pesquisa por genero
                            if ((cbgenerop.SelectedItem.ToString() == FE.generofilme && txtnomep.Text == "" && txtlocalp.Text == ""))
                            {
                                cobaia = FE;
                                AdicionaLW2();
                            }
                            else if (((txtnomep.Text != "" && FE.NomeFilme.Contains(txtnomep.Text)) && (txtlocalp.Text != "" && FE.local.Contains(txtlocalp.Text))))
                            {
                                cobaia = FE;
                                AdicionaLW2();
                            }
                            else if ((txtnomep.Text != "" && FE.NomeFilme.Contains(txtnomep.Text) && txtlocalp.Text == "")
                            || ((txtlocalp.Text != "" && FE.local.Contains(txtlocalp.Text) && txtnomep.Text == "")))
                            {
                                cobaia = FE;
                                AdicionaLW2();
                            }
                        }
                        else
                        {
                            DateTime dataA = datap.Value.Date;
                            DateTime dataB = dataatep.Value.Date;
                            if ((dataA <= FE.DATA && dataB >= FE.DATA) && cbgenerop.SelectedItem.ToString() == FE.generofilme && txtnomep.Text == "" && txtlocalp.Text == "")
                            {
                                cobaia = FE;
                                AdicionaLW2();
                            }
                            else if ((txtnomep.Text != "" && FE.NomeFilme.Contains(txtnomep.Text) && txtlocalp.Text != "" && FE.local.Contains(txtlocalp.Text)
                                && (dataA <= FE.DATA && dataB >= FE.DATA)))
                            {
                                cobaia = FE;
                                AdicionaLW2();
                            }
                            else if ((txtnomep.Text != "" && FE.NomeFilme.Contains(txtnomep.Text) && (dataA <= FE.DATA && dataB >= FE.DATA))
                                || (txtlocalp.Text != "" && FE.local.Contains(txtlocalp.Text) && (dataA <= FE.DATA && dataB >= FE.DATA)))
                            {
                                cobaia = FE;
                                AdicionaLW2();
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Nao existe filme cadastrado com este tipo de genero", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                ListaPesquisaTOTAL.Clear();
                //Pega todos os valores do dicionadio
                foreach (List<Filmes> todalista in Dicionario.Values)
                {
                    ListaPesquisaTOTAL.AddRange(todalista);
                }
                //percorre cada filme ate que i < TodososFilmes
                for (int i = 0; i < ListaPesquisaTOTAL.Count; i++)
                {
                    FE = new Filmes();
                    FE = ListaPesquisaTOTAL[i];
                    //se a data nao for checada entra no if, se nao vai para outra condição
                    if (cbd.Checked == false)
                    {
                        if ((txtnomep.Text != "" && FE.NomeFilme.Contains(txtnomep.Text) && txtlocalp.Text == "")
                            || ((txtlocalp.Text != "" && FE.local.Contains(txtlocalp.Text) && txtnomep.Text == "")))
                        {
                            cobaia = FE;
                            AdicionaLW2();

                        }
                        else if (txtnomep.Text != "" && FE.NomeFilme.Contains(txtnomep.Text) && txtlocalp.Text != "" && FE.local.Contains(txtlocalp.Text))
                        {

                            AdicionaLW2();
                        }
                    }
                    else
                    {
                        DateTime dataA = datap.Value.Date;
                        DateTime dataB = dataatep.Value.Date;
                        if ((txtnomep.Text != "" && FE.NomeFilme.Contains(txtnomep.Text) && (dataA <= FE.DATA && dataB >= FE.DATA) && txtlocalp.Text == "")
                            || (txtlocalp.Text != "" && FE.local.Contains(txtlocalp.Text) && (dataA <= FE.DATA && dataB >= FE.DATA) && txtnomep.Text == ""))
                        {
                            cobaia = FE;
                            AdicionaLW2();

                        }
                        else if (txtnomep.Text != "" && FE.NomeFilme.Contains(txtnomep.Text) && (dataA <= FE.DATA && dataB >= FE.DATA)
                            && txtlocalp.Text != "" && FE.local.Contains(txtlocalp.Text))
                        {
                            cobaia = FE;
                            AdicionaLW2();

                        }
                        else if ((dataA <= FE.DATA && dataB >= FE.DATA) && txtnomep.Text == "" && txtlocalp.Text == "")
                        {
                            cobaia = FE;
                            AdicionaLW2();
                        }
                    }
                }
            }
        }
        


      
        //EVENTO CRIADO QUANDO ALTERAR O TAB CONTROL DE FILMES PARA PESQUISA

        //BOTAO LIMPAR
        private void button7_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            listView2.Items.Clear();
            cbd.Checked = false;
            //ListaPesquisaTOTAL.Clear();
            button2.Enabled = true;

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            if (listView1.Items.Count <= 0)
            {
                button3.Enabled = false;
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false; ;
            }
        }
    }
}