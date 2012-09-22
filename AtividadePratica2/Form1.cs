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
                List<Filmes> l = new List<Filmes>();
                if (txtnome.Text != "" || cbGenero.Text != "")
                {

                    //l.Add(filme);

                    if (Dicionario.ContainsKey(cbGenero.Text))
                    {

                        //Esta lista de filmes 'r' é a referencia da lista 'lista' logo a baixo do código na condição else
                        List<Filmes> r = Dicionario[cbGenero.Text];
                        //ADICIONA NO LIST VIEW
                        l.Add(filme);
                    }
                    else
                    {
                        //Cria nova lista de filmes porém nao armazena nenhum valor, servirá como referencia para a condição de verificação da chave do dicionário
                        List<Filmes> lista = new List<Filmes>();
                        //Adiciona filmes na lista l
                        filme.NomeFilme = txtnome.Text;
                        filme.generofilme = cbGenero.Text;
                        filme.DATA = datatimerdata.Value.ToShortDateString();
                        filme.local = textBox1.Text;
                        l.Add(filme);
                        //Adiciona no dicionario a chave cbGenero e a lista
                        Dicionario.Add(cbGenero.Text, l);
                    }
                }
                //Cria a lista para adicionar grupos e items de determinado grupo, dependendo do que ele selecionar no seu Genero ele entra nas condições e a condição verdadeira será o seu grupo..
                //OBS: os grupos criados sempre será o nome do gênero que voce selecionar no seu ComboBox.
                ListViewItem lf = new ListViewItem();
                if (filme.generofilme == "Comédia")
                {
                    lf.Group = listView1.Groups["Comedia"];
                    lf.Text = txtnome.Text;
                    lf.SubItems.Add(cbGenero.Text);
                    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                    lf.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(lf);
                }
                else if (cbGenero.Text == "Ação")
                {
                    lf.Group = listView1.Groups["acao"];
                    lf.Text = txtnome.Text;
                    lf.SubItems.Add(cbGenero.Text);
                    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                    lf.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(lf);
                }
                else if (cbGenero.Text == "Aventura")
                {
                    lf.Group = listView1.Groups["aventura"];
                    lf.Text = txtnome.Text;
                    lf.SubItems.Add(cbGenero.Text);
                    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                    lf.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(lf);
                }
                else if (cbGenero.Text == "Romance")
                {
                    lf.Group = listView1.Groups["romance"];
                    lf.Text = txtnome.Text;
                    lf.SubItems.Add(cbGenero.Text);
                    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                    lf.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(lf);
                }
                else if (cbGenero.Text == "Terror")
                {
                    lf.Group = listView1.Groups["terror"];
                    lf.Text = txtnome.Text;
                    lf.SubItems.Add(cbGenero.Text);
                    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                    lf.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(lf);
                }
                else if (cbGenero.Text == "Documentário")
                {
                    lf.Group = listView1.Groups["documentario"];
                    lf.Text = txtnome.Text;
                    lf.SubItems.Add(cbGenero.Text);
                    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                    lf.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(lf);
                }
                else if (cbGenero.Text == "Infantil")
                {
                    lf.Group = listView1.Groups["infantil"];
                    lf.Text = txtnome.Text;
                    lf.SubItems.Add(cbGenero.Text);
                    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                    lf.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(lf);
                }
                else if (cbGenero.Text == "Ficção - Científica")
                {
                    lf.Group = listView1.Groups["ficção"];
                    lf.Text = txtnome.Text;
                    lf.SubItems.Add(cbGenero.Text);
                    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                    lf.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(lf);
                }
                else if (cbGenero.Text == "Suspense")
                {
                    lf.Group = listView1.Groups["suspense"];
                    lf.Text = txtnome.Text;
                    lf.SubItems.Add(cbGenero.Text);
                    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                    lf.SubItems.Add(textBox1.Text);
                    listView1.Items.Add(lf);
                }
                foreach (KeyValuePair<string, List<Filmes>> J in Dicionario)
                {
                    foreach (Filmes JJ in J.Value)
                    {
                        MessageBox.Show("" + filme.NomeFilme + " " + filme.generofilme + " " + filme.local + " " + filme.DATA + " " + J.Key, " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Método criado para limpar campos.

                limpar();

            }
        
        }

        public bool Verifica()
        {
            
            return true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Adicionar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; --i)
            {
                ListViewItem remove = listView1.SelectedItems[i];
                listView1.Items.Remove(remove);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; --i)
            {

                if (cbGenero.Text == "Comédia")
                {
                    ListViewItem r = listView1.SelectedItems[i];
                    r.Group = listView1.Groups["Comedia"];
                    r.Text = txtnome.Text;
                    r.SubItems[1].Text = cbGenero.Text;
                    r.SubItems[2].Text = datatimerdata.Text;
                    r.SubItems[3].Text = textBox1.Text;
                }
                else if (cbGenero.Text == "Ação")
                {
                    ListViewItem r = listView1.SelectedItems[i];
                    r.Group = listView1.Groups["acao"];
                    r.Text = txtnome.Text;
                    r.SubItems[1].Text = cbGenero.Text;
                    r.SubItems[2].Text = datatimerdata.Text;
                    r.SubItems[3].Text = textBox1.Text;
                }
                else if (cbGenero.Text == "Aventura")
                {
                    ListViewItem r = listView1.SelectedItems[i];
                    r.Group = listView1.Groups["aventura"];
                    r.Text = txtnome.Text;
                    r.SubItems[1].Text = cbGenero.Text;
                    r.SubItems[2].Text = datatimerdata.Text;
                    r.SubItems[3].Text = textBox1.Text;
                }
                else if (cbGenero.Text == "Romance")
                {
                    ListViewItem r = listView1.SelectedItems[i];
                    r.Group = listView1.Groups["romance"];
                    r.Text = txtnome.Text;
                    r.SubItems[1].Text = cbGenero.Text;
                    r.SubItems[2].Text = datatimerdata.Text;
                    r.SubItems[3].Text = textBox1.Text;
                }
                else if (cbGenero.Text == "Terror")
                {
                    ListViewItem r = listView1.SelectedItems[i];
                    r.Group = listView1.Groups["terror"];
                    r.Text = txtnome.Text;
                    r.SubItems[1].Text = cbGenero.Text;
                    r.SubItems[2].Text = datatimerdata.Text;
                    r.SubItems[3].Text = textBox1.Text;
                }
                else if (cbGenero.Text == "Documentário")
                {
                    ListViewItem r = listView1.SelectedItems[i];
                    r.Group = listView1.Groups["documentario"];
                    r.Text = txtnome.Text;
                    r.SubItems[1].Text = cbGenero.Text;
                    r.SubItems[2].Text = datatimerdata.Text;
                    r.SubItems[3].Text = textBox1.Text;
                }
                else if (cbGenero.Text == "Infantil")
                {
                    ListViewItem r = listView1.SelectedItems[i];
                    r.Group = listView1.Groups["infantil"];
                    r.Text = txtnome.Text;
                    r.SubItems[1].Text = cbGenero.Text;
                    r.SubItems[2].Text = datatimerdata.Text;
                    r.SubItems[3].Text = textBox1.Text;
                }
                else if (cbGenero.Text == "Ficção - Científica")
                {
                    ListViewItem r = listView1.SelectedItems[i];
                    r.Group = listView1.Groups["ficção"];
                    r.Text = txtnome.Text;
                    r.SubItems[1].Text = cbGenero.Text;
                    r.SubItems[2].Text = datatimerdata.Text;
                    r.SubItems[3].Text = textBox1.Text;
                }
                else if (cbGenero.Text == "Suspense")
                {
                    ListViewItem r = listView1.SelectedItems[i];
                    r.Group = listView1.Groups["suspense"];
                    r.Text = txtnome.Text;
                    r.SubItems[1].Text = cbGenero.Text;
                    r.SubItems[2].Text = datatimerdata.Text;
                    r.SubItems[3].Text = textBox1.Text;
                    
                }
   
                //ListViewItem r = listView1.SelectedItems[i];
                //r.Group = listView1.Groups["Terror"];
                //r.Text = txtnome.Text;
                //r.SubItems[1].Text = cbGenero.Text;
                //r.SubItems[2].Text = datatimerdata.Text;
                //r.SubItems[3].Text = textBox1.Text;
            }
        }
        //Evento de double click quando ele clicar no item da lista duas vezes
        //vai jogar todos os campos 
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                if (listView1.SelectedItems[0].Selected)
                {
                    textBox1.Text = listView1.FocusedItem.SubItems[3].Text;
                    cbGenero.Text = listView1.FocusedItem.SubItems[1].Text;
                    datatimerdata.Text = listView1.FocusedItem.SubItems[2].Text;
                    txtnome.Text = listView1.FocusedItem.SubItems[0].Text;
                }
            }
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
            //ligando os grupos do listView aos valores do combobox
            //cbGenero.DataSource = listView1.Groups;
        }

    }
}
