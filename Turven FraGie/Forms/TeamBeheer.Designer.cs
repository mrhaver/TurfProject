namespace Turven_FraGie.Forms
{
    partial class TeamBeheer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVerwijderComp = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbWZoekComp = new System.Windows.Forms.TextBox();
            this.lbWZoekComp = new System.Windows.Forms.ListBox();
            this.btnWijzigComp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbWRegio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbWPoule = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbWNiveau = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbWcode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMaakComp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCompRegio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCompPoule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCompNiveau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCompCode = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1774, 1033);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1766, 991);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Competitie Beheer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVerwijderComp);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbWZoekComp);
            this.groupBox2.Controls.Add(this.lbWZoekComp);
            this.groupBox2.Controls.Add(this.btnWijzigComp);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbWRegio);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbWPoule);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbWNiveau);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbWcode);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(453, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1247, 520);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wijzig / Verwijder Competitie";
            // 
            // btnVerwijderComp
            // 
            this.btnVerwijderComp.ForeColor = System.Drawing.Color.Red;
            this.btnVerwijderComp.Location = new System.Drawing.Point(834, 420);
            this.btnVerwijderComp.Name = "btnVerwijderComp";
            this.btnVerwijderComp.Size = new System.Drawing.Size(226, 75);
            this.btnVerwijderComp.TabIndex = 12;
            this.btnVerwijderComp.Text = "Verwijder Competitie";
            this.btnVerwijderComp.UseVisualStyleBackColor = true;
            this.btnVerwijderComp.Click += new System.EventHandler(this.btnVerwijderComp_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(241, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Zoek Competitie Op Poule";
            // 
            // tbWZoekComp
            // 
            this.tbWZoekComp.Location = new System.Drawing.Point(8, 86);
            this.tbWZoekComp.Name = "tbWZoekComp";
            this.tbWZoekComp.Size = new System.Drawing.Size(317, 36);
            this.tbWZoekComp.TabIndex = 10;
            this.tbWZoekComp.TextChanged += new System.EventHandler(this.tbWZoekComp_TextChanged);
            // 
            // lbWZoekComp
            // 
            this.lbWZoekComp.FormattingEnabled = true;
            this.lbWZoekComp.ItemHeight = 29;
            this.lbWZoekComp.Location = new System.Drawing.Point(10, 149);
            this.lbWZoekComp.Name = "lbWZoekComp";
            this.lbWZoekComp.Size = new System.Drawing.Size(760, 265);
            this.lbWZoekComp.TabIndex = 9;
            this.lbWZoekComp.SelectedIndexChanged += new System.EventHandler(this.lbWZoekComp_SelectedIndexChanged);
            // 
            // btnWijzigComp
            // 
            this.btnWijzigComp.Location = new System.Drawing.Point(834, 339);
            this.btnWijzigComp.Name = "btnWijzigComp";
            this.btnWijzigComp.Size = new System.Drawing.Size(226, 75);
            this.btnWijzigComp.TabIndex = 8;
            this.btnWijzigComp.Text = "Wijzig Competitie";
            this.btnWijzigComp.UseVisualStyleBackColor = true;
            this.btnWijzigComp.Click += new System.EventHandler(this.btnWijzigComp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(834, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Poule";
            // 
            // tbWRegio
            // 
            this.tbWRegio.Location = new System.Drawing.Point(834, 295);
            this.tbWRegio.Name = "tbWRegio";
            this.tbWRegio.Size = new System.Drawing.Size(317, 36);
            this.tbWRegio.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(834, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Regio";
            // 
            // tbWPoule
            // 
            this.tbWPoule.Location = new System.Drawing.Point(834, 220);
            this.tbWPoule.Name = "tbWPoule";
            this.tbWPoule.Size = new System.Drawing.Size(317, 36);
            this.tbWPoule.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(834, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Niveau";
            // 
            // tbWNiveau
            // 
            this.tbWNiveau.Location = new System.Drawing.Point(834, 149);
            this.tbWNiveau.Name = "tbWNiveau";
            this.tbWNiveau.Size = new System.Drawing.Size(317, 36);
            this.tbWNiveau.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(834, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "Code";
            // 
            // tbWcode
            // 
            this.tbWcode.Location = new System.Drawing.Point(834, 74);
            this.tbWcode.Name = "tbWcode";
            this.tbWcode.Size = new System.Drawing.Size(317, 36);
            this.tbWcode.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMaakComp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbCompRegio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbCompPoule);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCompNiveau);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbCompCode);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 520);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maak Competitie";
            // 
            // btnMaakComp
            // 
            this.btnMaakComp.Location = new System.Drawing.Point(6, 412);
            this.btnMaakComp.Name = "btnMaakComp";
            this.btnMaakComp.Size = new System.Drawing.Size(226, 91);
            this.btnMaakComp.TabIndex = 8;
            this.btnMaakComp.Text = "Maak Competitie";
            this.btnMaakComp.UseVisualStyleBackColor = true;
            this.btnMaakComp.Click += new System.EventHandler(this.btnMaakComp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Poule";
            // 
            // tbCompRegio
            // 
            this.tbCompRegio.Location = new System.Drawing.Point(6, 289);
            this.tbCompRegio.Name = "tbCompRegio";
            this.tbCompRegio.Size = new System.Drawing.Size(317, 36);
            this.tbCompRegio.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Regio";
            // 
            // tbCompPoule
            // 
            this.tbCompPoule.Location = new System.Drawing.Point(6, 214);
            this.tbCompPoule.Name = "tbCompPoule";
            this.tbCompPoule.Size = new System.Drawing.Size(317, 36);
            this.tbCompPoule.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Niveau";
            // 
            // tbCompNiveau
            // 
            this.tbCompNiveau.Location = new System.Drawing.Point(6, 143);
            this.tbCompNiveau.Name = "tbCompNiveau";
            this.tbCompNiveau.Size = new System.Drawing.Size(317, 36);
            this.tbCompNiveau.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code";
            // 
            // tbCompCode
            // 
            this.tbCompCode.Location = new System.Drawing.Point(6, 68);
            this.tbCompCode.Name = "tbCompCode";
            this.tbCompCode.Size = new System.Drawing.Size(317, 36);
            this.tbCompCode.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1766, 991);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1766, 991);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TeamBeheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 1045);
            this.Controls.Add(this.tabControl1);
            this.Name = "TeamBeheer";
            this.Text = "TeamBeheer";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnVerwijderComp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbWZoekComp;
        private System.Windows.Forms.ListBox lbWZoekComp;
        private System.Windows.Forms.Button btnWijzigComp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbWRegio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbWPoule;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbWNiveau;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbWcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMaakComp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCompRegio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCompPoule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCompNiveau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCompCode;
    }
}