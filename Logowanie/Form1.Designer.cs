namespace Logowanie
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.Edycja = new System.Windows.Forms.Button();
            this.ComboRanga = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "user";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Edycja
            // 
            this.Edycja.Location = new System.Drawing.Point(63, 76);
            this.Edycja.Margin = new System.Windows.Forms.Padding(4);
            this.Edycja.Name = "Edycja";
            this.Edycja.Size = new System.Drawing.Size(100, 30);
            this.Edycja.TabIndex = 2;
            this.Edycja.Text = "Edycja";
            this.Edycja.UseVisualStyleBackColor = true;
            this.Edycja.Click += new System.EventHandler(this.Edycja_Click);
            // 
            // ComboRanga
            // 
            this.ComboRanga.Enabled = false;
            this.ComboRanga.FormattingEnabled = true;
            this.ComboRanga.Location = new System.Drawing.Point(53, 44);
            this.ComboRanga.Name = "ComboRanga";
            this.ComboRanga.Size = new System.Drawing.Size(121, 25);
            this.ComboRanga.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(230, 119);
            this.Controls.Add(this.ComboRanga);
            this.Controls.Add(this.Edycja);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "State";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Edycja;
        private System.Windows.Forms.ComboBox ComboRanga;
    }
}

