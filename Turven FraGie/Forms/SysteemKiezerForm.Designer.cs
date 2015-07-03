namespace Turven_FraGie.Forms
{
    partial class SysteemKiezerForm
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
            this.btnTeamBeheer = new System.Windows.Forms.Button();
            this.btnTurfWedstrijd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTerug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTeamBeheer
            // 
            this.btnTeamBeheer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeamBeheer.Location = new System.Drawing.Point(441, 371);
            this.btnTeamBeheer.Name = "btnTeamBeheer";
            this.btnTeamBeheer.Size = new System.Drawing.Size(354, 216);
            this.btnTeamBeheer.TabIndex = 0;
            this.btnTeamBeheer.Text = "Team Beheer";
            this.btnTeamBeheer.UseVisualStyleBackColor = true;
            // 
            // btnTurfWedstrijd
            // 
            this.btnTurfWedstrijd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurfWedstrijd.Location = new System.Drawing.Point(1045, 371);
            this.btnTurfWedstrijd.Name = "btnTurfWedstrijd";
            this.btnTurfWedstrijd.Size = new System.Drawing.Size(354, 216);
            this.btnTurfWedstrijd.TabIndex = 1;
            this.btnTurfWedstrijd.Text = "Turf Wedstrijd";
            this.btnTurfWedstrijd.UseVisualStyleBackColor = true;
            this.btnTurfWedstrijd.Click += new System.EventHandler(this.btnTurfWedstrijd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(745, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 58);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maak Uw Keuze";
            // 
            // btnTerug
            // 
            this.btnTerug.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerug.Location = new System.Drawing.Point(441, 724);
            this.btnTerug.Name = "btnTerug";
            this.btnTerug.Size = new System.Drawing.Size(216, 114);
            this.btnTerug.TabIndex = 3;
            this.btnTerug.Text = "Terug";
            this.btnTerug.UseVisualStyleBackColor = true;
            this.btnTerug.Click += new System.EventHandler(this.btnTerug_Click);
            // 
            // SysteemKiezerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 1045);
            this.Controls.Add(this.btnTerug);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTurfWedstrijd);
            this.Controls.Add(this.btnTeamBeheer);
            this.Name = "SysteemKiezerForm";
            this.Text = "SysteemKiezerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTeamBeheer;
        private System.Windows.Forms.Button btnTurfWedstrijd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTerug;
    }
}