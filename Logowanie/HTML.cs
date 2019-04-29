using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logowanie
{
    public partial class HTML : Form
    {
        OpenFileDialog openFileDialog;
        int tabNumber = 0;
        public HTML()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Plik TXT|*.txt|Plik HTML|*.html";
        }

        private void NowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Add(createNewTab("Nowy"));
        }

        private void OtwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tabNumber++;
                tabControl.TabPages.Add(createNewTab(string.Format("Tab{0}", tabNumber), openFileDialog.FileName));
            }
        }



        private TabPage createNewTab(string name, string file = "")
        {
            TabPage page = new TabPage();
            page.Name = name;
            page.Text = name;

            CTRDziedzicz rtb = new CTRDziedzicz();
            rtb.filePath = file;
            rtb.Name = name;
            rtb.TabIndex = 0;
            rtb.Dock = DockStyle.Left;

            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Right;

            if (File.Exists(file) && file != "")
            {
                page.Text = Path.GetFileName(file);
                rtb.Text = File.ReadAllText(rtb.filePath);
                webBrowser.DocumentText = rtb.Text;
            }

            page.Resize += delegate (object sender, EventArgs e)
            {
                rtb.Width = page.Width / 2;
                webBrowser.Width = page.Width / 2;
            };

            rtb.TextChanged += delegate (object sender, EventArgs e)
            {
                webBrowser.DocumentText = rtb.Text;
            };

            page.Controls.Add(webBrowser);
            page.Controls.Add(rtb);


            return page;
        }
        private CTRDziedzicz GetRtbFromTab(TabPage tab)
        {
            return (CTRDziedzicz)tab.Controls.Cast<Control>().FirstOrDefault(x => x.GetType() == typeof(CTRDziedzicz));
        }

        private void ZapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabControl.TabPages.Count > 0)
            {
                CTRDziedzicz rtb = GetRtbFromTab(this.tabControl.SelectedTab);
                rtb.SaveAsFile();

            }
        }

        private void ZapiszWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CTRDziedzicz> rtbs = new List<CTRDziedzicz>();

            if (this.tabControl.TabPages.Count > 0)
            {
                foreach (TabPage tab in this.tabControl.TabPages)
                {
                    rtbs.Add(GetRtbFromTab(tab));
                }

                foreach (CTRDziedzicz rtb in rtbs)
                {
                    rtb.SaveAsFile();
                }
            }
        }

        private void PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CTRDziedzicz rtb = GetRtbFromTab(this.tabControl.SelectedTab);
            rtb.AddMarker("<p>", "");
        }

        private void SpanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CTRDziedzicz rtb = GetRtbFromTab(this.tabControl.SelectedTab);
            rtb.AddMarker("<span>", "</span>");
        }

        private void BrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CTRDziedzicz rtb = GetRtbFromTab(this.tabControl.SelectedTab);
            rtb.AddMarker("", "</br>");
        }


    }
}
