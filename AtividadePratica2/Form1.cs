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
         Filmes encontrado;
         Filmes achado;
         


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
                        List<Filmes> referencia = Dicionario[cbGenero.Text];
                        //ADICIONA NO LIST VIEW
                        l.Add(filme);
                    }
                    else
                    {
                        //Cria nova lista de filmes porém nao armazena nenhum valor, servirá como referencia para a condição de verificação da chave do dicionário
                        //Adiciona filmes na lista l
                        List<Filmes> REF = new List<Filmes>();
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
               
                lf.Group = listView1.Groups[filme.generofilme];
                lf.Text = txtnome.Text;
                lf.SubItems.Add(cbGenero.Text);
                lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
                lf.SubItems.Add(textBox1.Text);
                listView1.Items.Add(lf);

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
        //BOTAO ADICIONAR
        private void button1_Click(object sender, EventArgs e)
        {
            Adicionar();
        }
        //BOTAO REMOVER
        private void button3_Click(object sender, EventArgs e)
        {
            //O laço vai percorrer a lista, e quando encontrar o item selecionado irá removelo do ListView
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; --i)
            {
                ListViewItem remove = listView1.SelectedItems[i];
                listView1.Items.Remove(remove);
            }

            List<Filmes> L = Dicionario[cbGenero.Text];

            foreach (Filmes F in L)
            {
                if (F.NomeFilme == txtnome.Text)
                {
                    achado = F;
                    break;
                }

            }
            L.Remove(achado);
            MessageBox.Show("" + L, "", MessageBoxButtons.OK);
            
        }
        //BOTAO EDITAR 
        private void button4_Click(object sender, EventArgs e)
        {
            //laço percorre o list view até o seu item selecionado, quando o item for selecionado, ele troca seus campos.
            for (int i = listView1.SelectedItems.Count - 1; i >= 0; --i)
            {
                ListViewItem r = listView1.SelectedItems[i];
                r.Group = listView1.Groups[cbGenero.SelectedIndex];
                r.Text = txtnome.Text;
                r.SubItems[1].Text = cbGenero.Text;
                r.SubItems[2].Text = datatimerdata.Text;
                r.SubItems[3].Text = textBox1.Text;
            }


            if (cbGenero.Text == encontrado.generofilme)
            {

                encontrado.NomeFilme = txtnome.Text;
                encontrado.generofilme = cbGenero.Text;
                encontrado.DATA = datatimerdata.Text;
                encontrado.local = textBox1.Text;
            }
            //else
            //{
            //    //ELE TEM QUE REMOVER.

            //    List<Filmes> L = Dicionario[cbGenero.Text];

            //    foreach (Filmes F in L)
            //    {
            //        if (F.NomeFilme == txtnome.Text)
            //      + {
            //            achado = F;
            //            break;
            //        }

            //    }
            //    L.Remove(achado);
            //    MessageBox.Show("" + L, "", MessageBoxButtons.OK);
            //    ListView lf;
            //    lf.Group = listView1.Groups[achado.generofilme];
            //    lf.Text = txtnome.Text;
            //    lf.SubItems.Add(cbGenero.Text);
            //    lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
            //    lf.SubItems.Add(textBox1.Text);
            //    listView1.Items.Add(lf);

            

            //}
        }
         
        //Evento de double click quando ele clicar no item da lista duas vezes
        //vai jogar todos os campos 
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
              
                    textBox1.Text = listView1.FocusedItem.SubItems[3].Text;
                    cbGenero.Text = listView1.FocusedItem.SubItems[1].Text;
                    datatimerdata.Text = listView1.FocusedItem.SubItems[2].Text;
                    txtnome.Text = listView1.FocusedItem.SubItems[0].Text;
                    List<Filmes> l = Dicionario[cbGenero.Text];
                    
                    foreach (Filmes f in l)
                    {
                        if (f.NomeFilme == txtnome.Text)
                        {
                            encontrado = f;
                            MessageBox.Show("" + encontrado.NomeFilme + "   " + encontrado.generofilme + "  " + encontrado.DATA + "  " + encontrado.local, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        
                    }
                    
                    //pega o genero, pega a lista referente aquele genero, achou ve o que voce quer. data
                
            
            }
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
            //ligando os grupos do listView aos valores do combobox
            //cbGenero.DataSource = listView1.Groups;
        }

    }
}
