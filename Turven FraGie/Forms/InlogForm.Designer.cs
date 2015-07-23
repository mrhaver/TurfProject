namespace Turven_FraGie
{
    partial class InlogForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInlognaam = new System.Windows.Forms.TextBox();
            this.tbWachtwoord = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnMaakAccount = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(716, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inlognaam: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(694, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wachtwoord: ";
            // 
            // tbInlognaam
            // 
            this.tbInlognaam.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbInlognaam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInlognaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInlognaam.Location = new System.Drawing.Point(894, 230);
            this.tbInlognaam.Name = "tbInlognaam";
            this.tbInlognaam.Size = new System.Drawing.Size(225, 36);
            this.tbInlognaam.TabIndex = 3;
            this.tbInlognaam.Text = " ";
            // 
            // tbWachtwoord
            // 
            this.tbWachtwoord.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbWachtwoord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbWachtwoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWachtwoord.Location = new System.Drawing.Point(894, 270);
            this.tbWachtwoord.Name = "tbWachtwoord";
            this.tbWachtwoord.PasswordChar = '*';
            this.tbWachtwoord.Size = new System.Drawing.Size(225, 36);
            this.tbWachtwoord.TabIndex = 4;
            this.tbWachtwoord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWachtwoord_KeyDown);
            // 
            // btnLogIn
            // 
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.Location = new System.Drawing.Point(894, 339);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(225, 69);
            this.btnLogIn.TabIndex = 5;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnMaakAccount
            // 
            this.btnMaakAccount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMaakAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaakAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaakAccount.Location = new System.Drawing.Point(636, 339);
            this.btnMaakAccount.Name = "btnMaakAccount";
            this.btnMaakAccount.Size = new System.Drawing.Size(225, 69);
            this.btnMaakAccount.TabIndex = 6;
            this.btnMaakAccount.Text = "Maak Account";
            this.btnMaakAccount.UseVisualStyleBackColor = false;
            this.btnMaakAccount.Click += new System.EventHandler(this.btnMaakAccount_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(799, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 58);
            this.label3.TabIndex = 7;
            this.label3.Text = "Inloggen";
            // 
            // InlogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1914, 1045);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMaakAccount);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.tbWachtwoord);
            this.Controls.Add(this.tbInlognaam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Name = "InlogForm";
            this.Text = "Inloggen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInlognaam;
        private System.Windows.Forms.TextBox tbWachtwoord;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnMaakAccount;
        private System.Windows.Forms.Label label3;
    }
}

