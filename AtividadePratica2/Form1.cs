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
        List<string> l = new List<string>();

        public static void Adiciona()
        {
             
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lf = new ListViewItem();
            if (cbGenero.Text == "Comédia")
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
            


           
            
        }

    }
}
