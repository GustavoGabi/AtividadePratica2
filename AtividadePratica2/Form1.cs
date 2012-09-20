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
        Dictionary<string, List<string>> Dicionario = new Dictionary<string, List<string>>();

        


        
      
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Filmes filme = new Filmes();
            List<Filmes> l = new List<Filmes>();



            //Adiciona filmes na lista l
            filme.NomeFilme = txtnome.Text;
            filme.generofilme = cbGenero.Text;
            filme.DATA = datatimerdata.Value.ToShortDateString();
            filme.local = textBox1.Text;
            l.Add(filme);



            
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
               // else if (cbGenero.Text == "Ação")
                //{
                  //  lf.Group = listView1.Groups["acao"];
            //        lf.Text = txtnome.Text;
            //        lf.SubItems.Add(cbGenero.Text);
            //        lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
            //        lf.SubItems.Add(textBox1.Text);
            //        listView1.Items.Add(lf);
            //    }
            //    else if (cbGenero.Text == "Aventura")
            //    {
            //        lf.Group = listView1.Groups["aventura"];
            //        lf.Text = txtnome.Text;
            //        lf.SubItems.Add(cbGenero.Text);
            //        lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
            //        lf.SubItems.Add(textBox1.Text);
            //        listView1.Items.Add(lf);
            //    }
            //    else if (cbGenero.Text == "Romance")
            //    {
            //        lf.Group = listView1.Groups["romance"];
            //        lf.Text = txtnome.Text;
            //        lf.SubItems.Add(cbGenero.Text);
            //        lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
            //        lf.SubItems.Add(textBox1.Text);
            //        listView1.Items.Add(lf);
            //    }
            //    else if (cbGenero.Text == "Terror")
            //    {
            //        lf.Group = listView1.Groups["terror"];
            //        lf.Text = txtnome.Text;
            //        lf.SubItems.Add(cbGenero.Text);
            //        lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
            //        lf.SubItems.Add(textBox1.Text);
            //        listView1.Items.Add(lf);
            //    }
            //    else if (cbGenero.Text == "Documentário")
            //    {
            //        lf.Group = listView1.Groups["documentario"];
            //        lf.Text = txtnome.Text;
            //        lf.SubItems.Add(cbGenero.Text);
            //        lf.SubItems.Add(datatimerdata.Value.ToShortDateString());
            //        lf.SubItems.Add(textBox1.Text);
            //        listView1.Items.Add(lf);
            //    }




            //    txtnome.Clear();
            //    textBox1.Clear();
            //    datatimerdata.Text = DateTime.Now.ToShortDateString();
            //    cbGenero.Text = "";
            
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
                ListViewItem r = listView1.SelectedItems[i];
                r.Group = listView1.Groups["terror"];
                r.Text = txtnome.Text;
                r.SubItems[1].Text = cbGenero.Text;
                r.SubItems[2].Text = datatimerdata.Text;
                r.SubItems[3].Text = textBox1.Text;
            }
        }

    }
}
