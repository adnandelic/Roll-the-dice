namespace Kocke
{
    partial class Igrac
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
            this.components = new System.ComponentModel.Container();
            this.textBoxBrRundi = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxPlavi = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxCrveni = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxBrRundi
            // 
            this.textBoxBrRundi.BackColor = System.Drawing.Color.White;
            this.textBoxBrRundi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxBrRundi.ForeColor = System.Drawing.Color.Black;
            this.textBoxBrRundi.Location = new System.Drawing.Point(75, 220);
            this.textBoxBrRundi.MaxLength = 1;
            this.textBoxBrRundi.Name = "textBoxBrRundi";
            this.textBoxBrRundi.Size = new System.Drawing.Size(120, 35);
            this.textBoxBrRundi.TabIndex = 10;
            this.textBoxBrRundi.Text = "3";
            this.textBoxBrRundi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxBrRundi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBrRundi_KeyPress);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Green;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStart.Location = new System.Drawing.Point(32, 261);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(206, 38);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxPlavi
            // 
            this.textBoxPlavi.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBoxPlavi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPlavi.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.textBoxPlavi.Location = new System.Drawing.Point(32, 179);
            this.textBoxPlavi.Name = "textBoxPlavi";
            this.textBoxPlavi.Size = new System.Drawing.Size(206, 35);
            this.textBoxPlavi.TabIndex = 9;
            this.textBoxPlavi.Text = "Ime Plavi";
            this.textBoxPlavi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 450;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // textBoxCrveni
            // 
            this.textBoxCrveni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxCrveni.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCrveni.ForeColor = System.Drawing.Color.IndianRed;
            this.textBoxCrveni.Location = new System.Drawing.Point(33, 12);
            this.textBoxCrveni.Name = "textBoxCrveni";
            this.textBoxCrveni.Size = new System.Drawing.Size(206, 35);
            this.textBoxCrveni.TabIndex = 8;
            this.textBoxCrveni.Text = "Ime Crveni";
            this.textBoxCrveni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kocke.Properties.Resources.ikona;
            this.pictureBox1.Location = new System.Drawing.Point(75, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Igrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 311);
            this.Controls.Add(this.textBoxBrRundi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxPlavi);
            this.Controls.Add(this.textBoxCrveni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Igrac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Igrač prijava";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Igrac_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBrRundi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxPlavi;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox textBoxCrveni;

    }
}