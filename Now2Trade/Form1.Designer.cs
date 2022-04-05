namespace Now2Trade
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
            this.components = new System.ComponentModel.Container();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.tmrAna = new System.Windows.Forms.Timer(this.components);
            this.listLog = new System.Windows.Forms.ListBox();
            this.tmrIslem = new System.Windows.Forms.Timer(this.components);
            this.lblDeger = new System.Windows.Forms.Label();
            this.lblSonIslem = new System.Windows.Forms.Label();
            this.tmrZamanHesaplama = new System.Windows.Forms.Timer(this.components);
            this.lblKalanZaman = new System.Windows.Forms.Label();
            this.txtFark = new System.Windows.Forms.TextBox();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.lblFarkMax = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(12, 12);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(75, 23);
            this.btnBaslat.TabIndex = 0;
            this.btnBaslat.Text = "Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // tmrAna
            // 
            this.tmrAna.Interval = 1000;
            this.tmrAna.Tick += new System.EventHandler(this.tmrAna_Tick);
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.Location = new System.Drawing.Point(93, 12);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(220, 264);
            this.listLog.TabIndex = 1;
            // 
            // tmrIslem
            // 
            this.tmrIslem.Interval = 200;
            this.tmrIslem.Tick += new System.EventHandler(this.tmrIslem_Tick);
            // 
            // lblDeger
            // 
            this.lblDeger.AutoSize = true;
            this.lblDeger.Location = new System.Drawing.Point(12, 47);
            this.lblDeger.Name = "lblDeger";
            this.lblDeger.Size = new System.Drawing.Size(35, 13);
            this.lblDeger.TabIndex = 2;
            this.lblDeger.Text = "label1";
            // 
            // lblSonIslem
            // 
            this.lblSonIslem.AutoSize = true;
            this.lblSonIslem.Location = new System.Drawing.Point(12, 117);
            this.lblSonIslem.Name = "lblSonIslem";
            this.lblSonIslem.Size = new System.Drawing.Size(35, 13);
            this.lblSonIslem.TabIndex = 3;
            this.lblSonIslem.Text = "label1";
            // 
            // tmrZamanHesaplama
            // 
            this.tmrZamanHesaplama.Interval = 1000;
            this.tmrZamanHesaplama.Tick += new System.EventHandler(this.tmrZamanHesaplama_Tick);
            // 
            // lblKalanZaman
            // 
            this.lblKalanZaman.AutoSize = true;
            this.lblKalanZaman.Location = new System.Drawing.Point(12, 72);
            this.lblKalanZaman.Name = "lblKalanZaman";
            this.lblKalanZaman.Size = new System.Drawing.Size(35, 13);
            this.lblKalanZaman.TabIndex = 4;
            this.lblKalanZaman.Text = "label1";
            // 
            // txtFark
            // 
            this.txtFark.Location = new System.Drawing.Point(-4, 88);
            this.txtFark.Name = "txtFark";
            this.txtFark.Size = new System.Drawing.Size(100, 20);
            this.txtFark.TabIndex = 6;
            this.txtFark.Text = "470";
            // 
            // tmrTime
            // 
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // lblFarkMax
            // 
            this.lblFarkMax.AutoSize = true;
            this.lblFarkMax.Location = new System.Drawing.Point(12, 148);
            this.lblFarkMax.Name = "lblFarkMax";
            this.lblFarkMax.Size = new System.Drawing.Size(13, 13);
            this.lblFarkMax.TabIndex = 7;
            this.lblFarkMax.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 284);
            this.Controls.Add(this.lblFarkMax);
            this.Controls.Add(this.txtFark);
            this.Controls.Add(this.lblKalanZaman);
            this.Controls.Add(this.lblSonIslem);
            this.Controls.Add(this.lblDeger);
            this.Controls.Add(this.listLog);
            this.Controls.Add(this.btnBaslat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Timer tmrAna;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.Timer tmrIslem;
        private System.Windows.Forms.Label lblDeger;
        private System.Windows.Forms.Label lblSonIslem;
        private System.Windows.Forms.Timer tmrZamanHesaplama;
        private System.Windows.Forms.Label lblKalanZaman;
        private System.Windows.Forms.TextBox txtFark;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Label lblFarkMax;
    }
}

