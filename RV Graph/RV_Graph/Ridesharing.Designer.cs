namespace RV_Graph
{
    partial class Ridesharing
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
            this.btnDegerAta = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRunRV = new System.Windows.Forms.Button();
            this.lstEslesme = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpArac = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstVehicleInstantX = new System.Windows.Forms.ListBox();
            this.lstVehicleInstantY = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstAtananIstekler = new System.Windows.Forms.ListBox();
            this.lstPickUpY = new System.Windows.Forms.ListBox();
            this.lstPickUpX = new System.Windows.Forms.ListBox();
            this.grpIstek = new System.Windows.Forms.GroupBox();
            this.lstDropOffX = new System.Windows.Forms.ListBox();
            this.lstDropOffY = new System.Windows.Forms.ListBox();
            this.lstEslesme2 = new System.Windows.Forms.ListBox();
            this.grpArac.SuspendLayout();
            this.grpIstek.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDegerAta
            // 
            this.btnDegerAta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDegerAta.Location = new System.Drawing.Point(644, 260);
            this.btnDegerAta.Name = "btnDegerAta";
            this.btnDegerAta.Size = new System.Drawing.Size(149, 65);
            this.btnDegerAta.TabIndex = 42;
            this.btnDegerAta.Text = "Değerleri Ata";
            this.btnDegerAta.UseVisualStyleBackColor = true;
            this.btnDegerAta.Click += new System.EventHandler(this.btnDegerAta_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(13, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Anlık Konum X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(167, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Anlık Konum Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(512, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "Hedef Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(348, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 45;
            this.label6.Text = "Hedef X";
            // 
            // btnRunRV
            // 
            this.btnRunRV.Enabled = false;
            this.btnRunRV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRunRV.Location = new System.Drawing.Point(814, 19);
            this.btnRunRV.Name = "btnRunRV";
            this.btnRunRV.Size = new System.Drawing.Size(289, 82);
            this.btnRunRV.TabIndex = 47;
            this.btnRunRV.Text = "RV Graph Çalıştır";
            this.btnRunRV.UseVisualStyleBackColor = true;
            this.btnRunRV.Click += new System.EventHandler(this.btnRunRV_Click);
            // 
            // lstEslesme
            // 
            this.lstEslesme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstEslesme.FormattingEnabled = true;
            this.lstEslesme.ItemHeight = 16;
            this.lstEslesme.Location = new System.Drawing.Point(814, 141);
            this.lstEslesme.Name = "lstEslesme";
            this.lstEslesme.Size = new System.Drawing.Size(289, 516);
            this.lstEslesme.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(908, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "Eşleşmeler";
            // 
            // grpArac
            // 
            this.grpArac.Controls.Add(this.label2);
            this.grpArac.Controls.Add(this.label1);
            this.grpArac.Controls.Add(this.lstVehicleInstantX);
            this.grpArac.Controls.Add(this.lstVehicleInstantY);
            this.grpArac.Controls.Add(this.label10);
            this.grpArac.Controls.Add(this.lstAtananIstekler);
            this.grpArac.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpArac.Location = new System.Drawing.Point(12, 371);
            this.grpArac.Name = "grpArac";
            this.grpArac.Size = new System.Drawing.Size(616, 313);
            this.grpArac.TabIndex = 72;
            this.grpArac.TabStop = false;
            this.grpArac.Text = "Vehicle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(48, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "Anlık Konum X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(232, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "Anlık Konum Y";
            // 
            // lstVehicleInstantX
            // 
            this.lstVehicleInstantX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstVehicleInstantX.FormattingEnabled = true;
            this.lstVehicleInstantX.ItemHeight = 15;
            this.lstVehicleInstantX.Location = new System.Drawing.Point(18, 40);
            this.lstVehicleInstantX.Name = "lstVehicleInstantX";
            this.lstVehicleInstantX.Size = new System.Drawing.Size(177, 259);
            this.lstVehicleInstantX.TabIndex = 74;
            // 
            // lstVehicleInstantY
            // 
            this.lstVehicleInstantY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstVehicleInstantY.FormattingEnabled = true;
            this.lstVehicleInstantY.ItemHeight = 15;
            this.lstVehicleInstantY.Location = new System.Drawing.Point(201, 40);
            this.lstVehicleInstantY.Name = "lstVehicleInstantY";
            this.lstVehicleInstantY.Size = new System.Drawing.Size(177, 259);
            this.lstVehicleInstantY.TabIndex = 75;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(461, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 17);
            this.label10.TabIndex = 45;
            this.label10.Text = "Atanan istekler";
            // 
            // lstAtananIstekler
            // 
            this.lstAtananIstekler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstAtananIstekler.FormattingEnabled = true;
            this.lstAtananIstekler.ItemHeight = 15;
            this.lstAtananIstekler.Location = new System.Drawing.Point(426, 40);
            this.lstAtananIstekler.Name = "lstAtananIstekler";
            this.lstAtananIstekler.Size = new System.Drawing.Size(184, 259);
            this.lstAtananIstekler.TabIndex = 76;
            // 
            // lstPickUpY
            // 
            this.lstPickUpY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstPickUpY.FormattingEnabled = true;
            this.lstPickUpY.ItemHeight = 15;
            this.lstPickUpY.Location = new System.Drawing.Point(161, 49);
            this.lstPickUpY.Name = "lstPickUpY";
            this.lstPickUpY.Size = new System.Drawing.Size(124, 289);
            this.lstPickUpY.TabIndex = 75;
            // 
            // lstPickUpX
            // 
            this.lstPickUpX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstPickUpX.FormattingEnabled = true;
            this.lstPickUpX.ItemHeight = 15;
            this.lstPickUpX.Location = new System.Drawing.Point(6, 49);
            this.lstPickUpX.Name = "lstPickUpX";
            this.lstPickUpX.Size = new System.Drawing.Size(124, 289);
            this.lstPickUpX.TabIndex = 74;
            // 
            // grpIstek
            // 
            this.grpIstek.Controls.Add(this.label3);
            this.grpIstek.Controls.Add(this.label4);
            this.grpIstek.Controls.Add(this.lstPickUpY);
            this.grpIstek.Controls.Add(this.lstPickUpX);
            this.grpIstek.Controls.Add(this.lstDropOffX);
            this.grpIstek.Controls.Add(this.lstDropOffY);
            this.grpIstek.Controls.Add(this.label6);
            this.grpIstek.Controls.Add(this.label5);
            this.grpIstek.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpIstek.Location = new System.Drawing.Point(12, 12);
            this.grpIstek.Name = "grpIstek";
            this.grpIstek.Size = new System.Drawing.Size(616, 353);
            this.grpIstek.TabIndex = 73;
            this.grpIstek.TabStop = false;
            this.grpIstek.Text = "Request";
            // 
            // lstDropOffX
            // 
            this.lstDropOffX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstDropOffX.FormattingEnabled = true;
            this.lstDropOffX.ItemHeight = 15;
            this.lstDropOffX.Location = new System.Drawing.Point(324, 49);
            this.lstDropOffX.Name = "lstDropOffX";
            this.lstDropOffX.Size = new System.Drawing.Size(124, 289);
            this.lstDropOffX.TabIndex = 77;
            // 
            // lstDropOffY
            // 
            this.lstDropOffY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstDropOffY.FormattingEnabled = true;
            this.lstDropOffY.ItemHeight = 15;
            this.lstDropOffY.Location = new System.Drawing.Point(486, 49);
            this.lstDropOffY.Name = "lstDropOffY";
            this.lstDropOffY.Size = new System.Drawing.Size(124, 289);
            this.lstDropOffY.TabIndex = 76;
            // 
            // lstEslesme2
            // 
            this.lstEslesme2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstEslesme2.FormattingEnabled = true;
            this.lstEslesme2.ItemHeight = 16;
            this.lstEslesme2.Location = new System.Drawing.Point(1109, 19);
            this.lstEslesme2.Name = "lstEslesme2";
            this.lstEslesme2.Size = new System.Drawing.Size(249, 644);
            this.lstEslesme2.TabIndex = 79;
            // 
            // Ridesharing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 734);
            this.Controls.Add(this.lstEslesme2);
            this.Controls.Add(this.grpIstek);
            this.Controls.Add(this.grpArac);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstEslesme);
            this.Controls.Add(this.btnRunRV);
            this.Controls.Add(this.btnDegerAta);
            this.Name = "Ridesharing";
            this.Text = "RV Graph";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpArac.ResumeLayout(false);
            this.grpArac.PerformLayout();
            this.grpIstek.ResumeLayout(false);
            this.grpIstek.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDegerAta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRunRV;
        private System.Windows.Forms.ListBox lstEslesme;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpArac;
        private System.Windows.Forms.GroupBox grpIstek;
        private System.Windows.Forms.ListBox lstPickUpY;
        private System.Windows.Forms.ListBox lstPickUpX;
        private System.Windows.Forms.ListBox lstDropOffX;
        private System.Windows.Forms.ListBox lstDropOffY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstVehicleInstantX;
        private System.Windows.Forms.ListBox lstVehicleInstantY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstAtananIstekler;
        private System.Windows.Forms.ListBox lstEslesme2;
    }
}

