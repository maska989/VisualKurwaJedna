using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logowanie
{
    class CTRDziedzicz : RichTextBox
    {
        public string filePath { get; set; }
        public void SaveAsFile()
        {
            if (File.Exists(this.filePath))
            {
                MessageBox.Show("Istnieje");
                using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(filePath))
                {
                    SaveFile.WriteLine(this.Text);
                }

            }
            else
            {
                MessageBox.Show("Nie istnieje");
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Plik HTML|*.html|Plik TXT|*.txt";
                sd.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\file";


                if (sd.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sd.FileName))
                    {
                        SaveFile.WriteLine(this.Text);
                    }
                }


            }
        }
        public void AddMarker(string markerStart, string markerStop = "")
        {
            string prepared = string.Format("{0}{1}", markerStart, markerStop);
            int startIndex = this.SelectionStart;
            if (this.SelectedText != string.Empty)
            {
                prepared = string.Format("{0}{2}{1}", markerStart, markerStop, this.SelectedText);

                int lenght = this.SelectedText.Length;
                string tempText = this.Text.Remove(startIndex, lenght);
                this.Text = tempText.Insert(startIndex, prepared);
                this.Select(startIndex + prepared.Length, 0);


            }
            else
            {
                this.Text = this.Text.Insert(startIndex, prepared);
                this.Select(startIndex + markerStart.Length, 0);
            }

        }
    }
}
