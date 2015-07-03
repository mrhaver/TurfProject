namespace Turven_FraGie.Forms
{
    partial class MaakAccountForm
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
            this.gbMaakPersoon = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbVerifieerWachtwoord = new System.Windows.Forms.TextBox();
            this.btnAnnuleer = new System.Windows.Forms.Button();
            this.btnMaakPersoon = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAccountType = new System.Windows.Forms.TextBox();
            this.tbWachtwoord = new System.Windows.Forms.TextBox();
            this.tbVerenigingNaam = new System.Windows.Forms.TextBox();
            this.tbInlogNaam = new System.Windows.Forms.TextBox();
            this.gbKiesVereniging = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbZoeken = new System.Windows.Forms.TextBox();
            this.lbVerenigingen = new System.Windows.Forms.ListBox();
            this.btnMaakTurver = new System.Windows.Forms.Button();
            this.btnMaakBeheerder = new System.Windows.Forms.Button();
            this.btnInloggen = new System.Windows.Forms.Button();
            this.gbMaakPersoon.SuspendLayout();
            this.gbKiesVereniging.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMaakPersoon
            // 
            this.gbMaakPersoon.Controls.Add(this.label3);
            this.gbMaakPersoon.Controls.Add(this.tbVerifieerWachtwoord);
            this.gbMaakPersoon.Controls.Add(this.btnAnnuleer);
            this.gbMaakPersoon.Controls.Add(this.btnMaakPersoon);
            this.gbMaakPersoon.Controls.Add(this.label6);
            this.gbMaakPersoon.Controls.Add(this.label5);
            this.gbMaakPersoon.Controls.Add(this.label4);
            this.gbMaakPersoon.Controls.Add(this.label2);
            this.gbMaakPersoon.Controls.Add(this.tbAccountType);
            this.gbMaakPersoon.Controls.Add(this.tbWachtwoord);
            this.gbMaakPersoon.Controls.Add(this.tbVerenigingNaam);
            this.gbMaakPersoon.Controls.Add(this.tbInlogNaam);
            this.gbMaakPersoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMaakPersoon.Location = new System.Drawing.Point(1003, 140);
            this.gbMaakPersoon.Name = "gbMaakPersoon";
            this.gbMaakPersoon.Size = new System.Drawing.Size(626, 461);
            this.gbMaakPersoon.TabIndex = 16;
            this.gbMaakPersoon.TabStop = false;
            this.gbMaakPersoon.Text = "Maak";
            this.gbMaakPersoon.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 29);
            this.label3.TabIndex = 24;
            this.label3.Text = "Verifieer Wachtwoord: ";
            // 
            // tbVerifieerWachtwoord
            // 
            this.tbVerifieerWachtwoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVerifieerWachtwoord.Location = new System.Drawing.Point(306, 239);
            this.tbVerifieerWachtwoord.Name = "tbVerifieerWachtwoord";
            this.tbVerifieerWachtwoord.PasswordChar = '*';
            this.tbVerifieerWachtwoord.Size = new System.Drawing.Size(291, 36);
            this.tbVerifieerWachtwoord.TabIndex = 4;
            // 
            // btnAnnuleer
            // 
            this.btnAnnuleer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuleer.Location = new System.Drawing.Point(23, 372);
            this.btnAnnuleer.Name = "btnAnnuleer";
            this.btnAnnuleer.Size = new System.Drawing.Size(262, 64);
            this.btnAnnuleer.TabIndex = 22;
            this.btnAnnuleer.Text = "Annuleer";
            this.btnAnnuleer.UseVisualStyleBackColor = true;
            this.btnAnnuleer.Click += new System.EventHandler(this.btnAnnuleer_Click);
            // 
            // btnMaakPersoon
            // 
            this.btnMaakPersoon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaakPersoon.Location = new System.Drawing.Point(335, 372);
            this.btnMaakPersoon.Name = "btnMaakPersoon";
            this.btnMaakPersoon.Size = new System.Drawing.Size(262, 64);
            this.btnMaakPersoon.TabIndex = 21;
            this.btnMaakPersoon.Text = "Maak Turver";
            this.btnMaakPersoon.UseVisualStyleBackColor = true;
            this.btnMaakPersoon.Click += new System.EventHandler(this.btnMaakPersoon_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 29);
            this.label6.TabIndex = 20;
            this.label6.Text = "Type Account: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 29);
            this.label5.TabIndex = 19;
            this.label5.Text = "Wachtwoord: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 29);
            this.label4.TabIndex = 18;
            this.label4.Text = "Vereniging Naam: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "Inlognaam: ";
            // 
            // tbAccountType
            // 
            this.tbAccountType.Enabled = false;
            this.tbAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccountType.Location = new System.Drawing.Point(306, 296);
            this.tbAccountType.Name = "tbAccountType";
            this.tbAccountType.Size = new System.Drawing.Size(291, 36);
            this.tbAccountType.TabIndex = 3;
            // 
            // tbWachtwoord
            // 
            this.tbWachtwoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWachtwoord.Location = new System.Drawing.Point(306, 182);
            this.tbWachtwoord.Name = "tbWachtwoord";
            this.tbWachtwoord.PasswordChar = '*';
            this.tbWachtwoord.Size = new System.Drawing.Size(291, 36);
            this.tbWachtwoord.TabIndex = 2;
            // 
            // tbVerenigingNaam
            // 
            this.tbVerenigingNaam.Enabled = false;
            this.tbVerenigingNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVerenigingNaam.Location = new System.Drawing.Point(306, 125);
            this.tbVerenigingNaam.Name = "tbVerenigingNaam";
            this.tbVerenigingNaam.Size = new System.Drawing.Size(291, 36);
            this.tbVerenigingNaam.TabIndex = 1;
            // 
            // tbInlogNaam
            // 
            this.tbInlogNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInlogNaam.Location = new System.Drawing.Point(306, 68);
            this.tbInlogNaam.Name = "tbInlogNaam";
            this.tbInlogNaam.Size = new System.Drawing.Size(291, 36);
            this.tbInlogNaam.TabIndex = 0;
            // 
            // gbKiesVereniging
            // 
            this.gbKiesVereniging.Controls.Add(this.label1);
            this.gbKiesVereniging.Controls.Add(this.tbZoeken);
            this.gbKiesVereniging.Controls.Add(this.lbVerenigingen);
            this.gbKiesVereniging.Controls.Add(this.btnMaakTurver);
            this.gbKiesVereniging.Controls.Add(this.btnMaakBeheerder);
            this.gbKiesVereniging.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbKiesVereniging.Location = new System.Drawing.Point(142, 140);
            this.gbKiesVereniging.Name = "gbKiesVereniging";
            this.gbKiesVereniging.Size = new System.Drawing.Size(673, 461);
            this.gbKiesVereniging.TabIndex = 17;
            this.gbKiesVereniging.TabStop = false;
            this.gbKiesVereniging.Text = "Kies Uw Vereniging";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 29);
            this.label1.TabIndex = 20;
            this.label1.Text = "Zoeken op naam";
            // 
            // tbZoeken
            // 
            this.tbZoeken.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbZoeken.Location = new System.Drawing.Point(367, 267);
            this.tbZoeken.Name = "tbZoeken";
            this.tbZoeken.Size = new System.Drawing.Size(183, 36);
            this.tbZoeken.TabIndex = 19;
            this.tbZoeken.TextChanged += new System.EventHandler(this.tbZoeken_TextChanged_1);
            // 
            // lbVerenigingen
            // 
            this.lbVerenigingen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVerenigingen.FormattingEnabled = true;
            this.lbVerenigingen.ItemHeight = 29;
            this.lbVerenigingen.Location = new System.Drawing.Point(121, 90);
            this.lbVerenigingen.Name = "lbVerenigingen";
            this.lbVerenigingen.Size = new System.Drawing.Size(450, 149);
            this.lbVerenigingen.TabIndex = 18;
            this.lbVerenigingen.SelectedIndexChanged += new System.EventHandler(this.lbVerenigingen_SelectedIndexChanged_1);
            // 
            // btnMaakTurver
            // 
            this.btnMaakTurver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaakTurver.Location = new System.Drawing.Point(367, 372);
            this.btnMaakTurver.Name = "btnMaakTurver";
            this.btnMaakTurver.Size = new System.Drawing.Size(262, 64);
            this.btnMaakTurver.TabIndex = 17;
            this.btnMaakTurver.Text = "Maak Turver";
            this.btnMaakTurver.UseVisualStyleBackColor = true;
            this.btnMaakTurver.Click += new System.EventHandler(this.btnMaakTurver_Click_1);
            // 
            // btnMaakBeheerder
            // 
            this.btnMaakBeheerder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaakBeheerder.Location = new System.Drawing.Point(42, 372);
            this.btnMaakBeheerder.Name = "btnMaakBeheerder";
            this.btnMaakBeheerder.Size = new System.Drawing.Size(262, 64);
            this.btnMaakBeheerder.TabIndex = 16;
            this.btnMaakBeheerder.Text = "Maak Beheerder";
            this.btnMaakBeheerder.UseVisualStyleBackColor = true;
            this.btnMaakBeheerder.Click += new System.EventHandler(this.btnMaakBeheerder_Click_1);
            // 
            // btnInloggen
            // 
            this.btnInloggen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInloggen.Location = new System.Drawing.Point(184, 705);
            this.btnInloggen.Name = "btnInloggen";
            this.btnInloggen.Size = new System.Drawing.Size(262, 64);
            this.btnInloggen.TabIndex = 21;
            this.btnInloggen.Text = "Terug";
            this.btnInloggen.UseVisualStyleBackColor = true;
            this.btnInloggen.Click += new System.EventHandler(this.btnInloggen_Click);
            // 
            // MaakAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 1045);
            this.Controls.Add(this.btnInloggen);
            this.Controls.Add(this.gbKiesVereniging);
            this.Controls.Add(this.gbMaakPersoon);
            this.Name = "MaakAccountForm";
            this.Text = "Maak Account";
            this.gbMaakPersoon.ResumeLayout(false);
            this.gbMaakPersoon.PerformLayout();
            this.gbKiesVereniging.ResumeLayout(false);
            this.gbKiesVereniging.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMaakPersoon;
        private System.Windows.Forms.Button btnMaakPersoon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAccountType;
        private System.Windows.Forms.TextBox tbWachtwoord;
        private System.Windows.Forms.TextBox tbVerenigingNaam;
        private System.Windows.Forms.TextBox tbInlogNaam;
        private System.Windows.Forms.Button btnAnnuleer;
        private System.Windows.Forms.GroupBox gbKiesVereniging;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbZoeken;
        private System.Windows.Forms.ListBox lbVerenigingen;
        private System.Windows.Forms.Button btnMaakTurver;
        private System.Windows.Forms.Button btnMaakBeheerder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbVerifieerWachtwoord;
        private System.Windows.Forms.Button btnInloggen;

    }
}