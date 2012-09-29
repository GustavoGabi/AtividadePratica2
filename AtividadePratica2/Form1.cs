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
        ListViewItem LISTA = new ListViewItem();
        ListViewItem lf = new ListViewItem();
        Filmes filmeencontrado;
        Filmes cobaia;
        Filmes encontrado;

        //Método usado para armazenamento dos filmes no listView1
        public void Adicionar()
        {
            Filmes filme = new Filmes();

            if (txtnome.Text == "" || textBox1.Text == "" || cbGenero.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

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
            

            lf = new ListViewItem();
            lf.Text = cobaia.NomeFilme;
            lf.Group = listView2.Groups[cobaia.generofilme];
            listView2.Items.Add(lf);
            lf.SubItems.Add(cobaia.DATA.ToShortDateString());
            lf.SubItems.Add(cobaia.local);
            //lf.SubItems[0].Text = cbgenerop.Text;
            //lf.SubItems[1].Text = (cobaia.DATA.ToShortDateString());
            //lf.SubItems[2].Text = cobaia.local;
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

                //textBox1.Text = listView1.FocusedItem.SubItems[3].Text;
                //cbGenero.Text = listView1.FocusedItem.SubItems[1].Text;
                //datatimerdata.Text = listView1.FocusedItem.SubItems[2].Text;
                //txtnome.Text = listView1.FocusedItem.SubItems[0].Text;
                //List<Filmes> l = Dicionario[cbGenero.Text];

                //foreach (Filmes f in l)
                //{
                //    if (f.NomeFilme == txtnome.Text)
                //    {
                //        encontrado = f;
                //        MessageBox.Show("" + encontrado.NomeFilme + "   " + encontrado.generofilme + "  " + encontrado.DATA + "  " + encontrado.local, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        break;
                //    }

                //}

                //pega o genero, pega a lista referente aquele genero, achou ve o que voce quer. data


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
            if (cbgenerop.SelectedItem != null)
            {
                //verifica se genero ja existe no dicionario, se existe entra , se nao retorna uma mensagem dizendo que o genero nao foi encontrado 
                if (Dicionario.ContainsKey(cbgenerop.SelectedItem.ToString()))
                {
                    //pega os valores da chave do dicionario.
                    List<Filmes> lPesquisa = Dicionario[cbgenerop.Text];

                    //percorre cada filme ate que i < pesqlist 
                    for (int i = 0; i < lPesquisa.Count; i++)
                    {
                        filmeencontrado = new Filmes();
                        //pega o objeto de cada filme que esta no pesqlist
                        filmeencontrado = lPesquisa[i];
                        //se a data nao for checada entra no if, se nao vai para outra condição
                        if (cbd.Checked == false)
                        {
                            if ((cbgenerop.SelectedItem.ToString() == filmeencontrado.generofilme && txtnomep.Text == "" && txtlocalp.Text == ""))
                            {
                                cobaia = filmeencontrado;
                                AdicionaLW2();

                            }
                            else if (((txtnomep.Text != "" && filmeencontrado.NomeFilme.Contains(txtnomep.Text)) && (txtlocalp.Text != "" && filmeencontrado.local.Contains(txtlocalp.Text))))
                            {
                                cobaia = filmeencontrado;
                                AdicionaLW2();

                            }
                            else if ((txtnomep.Text != "" && filmeencontrado.NomeFilme.Contains(txtnomep.Text) && txtlocalp.Text == "")
                            || ((txtlocalp.Text != "" && filmeencontrado.local.Contains(txtlocalp.Text) && txtnomep.Text == "")))
                            {
                                cobaia = filmeencontrado;
                                AdicionaLW2();

                            }
                        }
                        else
                        {
                            DateTime dataA = datap.Value.Date;
                            DateTime dataB = dataatep.Value.Date;
                            if ((dataA <= filmeencontrado.DATA && dataB >= filmeencontrado.DATA) && cbgenerop.SelectedItem.ToString() == filmeencontrado.generofilme && txtnomep.Text == "" && txtlocalp.Text == "")
                            {
                                cobaia = filmeencontrado;
                                AdicionaLW2();

                            }
                            else if ((txtnomep.Text != "" && filmeencontrado.NomeFilme.Contains(txtnomep.Text) && txtlocalp.Text != "" && filmeencontrado.local.Contains(txtlocalp.Text)
                                && (dataA <= filmeencontrado.DATA && dataB >= filmeencontrado.DATA)))
                            {
                                cobaia = filmeencontrado;
                                AdicionaLW2();

                            }
                            else if ((txtnomep.Text != "" && filmeencontrado.NomeFilme.Contains(txtnomep.Text) && (dataA <= filmeencontrado.DATA && dataB >= filmeencontrado.DATA))
                                || (txtlocalp.Text != "" && filmeencontrado.local.Contains(txtlocalp.Text) && (dataA <= filmeencontrado.DATA && dataB >= filmeencontrado.DATA)))
                            {
                                cobaia = filmeencontrado;
                                AdicionaLW2();

                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Este genero não possui na sua Lista de filmeencontrados", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listatotal.Clear();
                foreach (List<Filmes> lt in Dicionario.Values)
                {
                    listatotal.AddRange(lt);
                }
                for (int i = 0; i < listatotal.Count; i++)
                {
                    filmeencontrado = new Filmes();
                    filmeencontrado = listatotal[i];
                    if (cbd.Checked == false)
                    {
                        if ((txtnomep.Text != "" && filmeencontrado.NomeFilme.Contains(txtnomep.Text) && txtlocalp.Text == "")
                            || ((txtlocalp.Text != "" && filmeencontrado.local.Contains(txtlocalp.Text) && txtnomep.Text == "")))
                        {
                            cobaia = filmeencontrado;
                            AdicionaLW2();


                        }
                        else if (txtnomep.Text != "" && filmeencontrado.NomeFilme.Contains(txtnomep.Text) && txtlocalp.Text != "" && filmeencontrado.local.Contains(txtlocalp.Text))
                        {
                            cobaia = filmeencontrado;
                            AdicionaLW2();

                        }
                    }
                    else
                    {
                        DateTime dataA = datap.Value.Date;
                        DateTime dataB = dataatep.Value.Date;
                        if ((txtnomep.Text != "" && filmeencontrado.NomeFilme.Contains(txtnomep.Text) && (dataA <= filmeencontrado.DATA && dataB >= filmeencontrado.DATA) && txtlocalp.Text == "")
                            || (txtlocalp.Text != "" && filmeencontrado.local.Contains(txtlocalp.Text) && (dataA <= filmeencontrado.DATA && dataB >= filmeencontrado.DATA) && txtnomep.Text == ""))
                        {
                            cobaia = filmeencontrado;
                            AdicionaLW2();

                        }
                        else if (txtnomep.Text != "" && filmeencontrado.NomeFilme.Contains(txtnomep.Text) && (dataA <= filmeencontrado.DATA && dataB >= filmeencontrado.DATA)
                            && txtlocalp.Text != "" && filmeencontrado.local.Contains(txtlocalp.Text))
                        {
                            cobaia = filmeencontrado;
                            AdicionaLW2();


                        }
                        else if ((dataA <= filmeencontrado.DATA && dataB >= filmeencontrado.DATA) && txtnomep.Text == "" && txtlocalp.Text == "")
                        {
                            cobaia = filmeencontrado;
                            AdicionaLW2();

                        }
                    }
                }
            }
        }
        //EVENTO CRIADO QUANDO ALTERAR O TAB CONTROL DE FILMES PARA PESQUISA
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedIndex == 0)
            //{
            //    // Filmes
            //    foreach (List<Filmes> l in Dicionario.Values)
            //    {
            //        for (int i = 0; i < l.Count; i++)
            //        {
            //            LISTA = new ListViewItem();
            //            LISTA.Group = listView1.Groups[l[i].generofilme];
            //            LISTA.Text = l[i].NomeFilme;
            //            LISTA.SubItems.Add(l[i].DATA.ToShortDateString());
            //            LISTA.SubItems.Add(l[i].local);
            //            listView1.Items.Add(LISTA);

            //        }
            //    }
            //}
            //else
            //{
            //    // Pesquisa
            //    listView1.Items.Clear();
            //}
        }

        //BOTAO LIMPAR
        private void button7_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            cbd.Checked = false;
            txtlocalp.Clear();
            txtnomep.Clear();
            cbgenerop.Text = "";
        }
    }
}
