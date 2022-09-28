namespace ClickerGame
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
            this.b_clicker = new System.Windows.Forms.Button();
            this.b_upgrade = new System.Windows.Forms.Button();
            this.l_clicks = new System.Windows.Forms.Label();
            this.l_money = new System.Windows.Forms.Label();
            this.b_rng_upgrade = new System.Windows.Forms.Button();
            this.b_rng = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_clicker
            // 
            this.b_clicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_clicker.Location = new System.Drawing.Point(11, 136);
            this.b_clicker.Name = "b_clicker";
            this.b_clicker.Size = new System.Drawing.Size(348, 243);
            this.b_clicker.TabIndex = 0;
            this.b_clicker.Text = "CLICK ME!";
            this.b_clicker.UseVisualStyleBackColor = true;
            this.b_clicker.Click += new System.EventHandler(this.b_clicker_Click);
            // 
            // b_upgrade
            // 
            this.b_upgrade.Enabled = false;
            this.b_upgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_upgrade.Location = new System.Drawing.Point(12, 82);
            this.b_upgrade.Name = "b_upgrade";
            this.b_upgrade.Size = new System.Drawing.Size(347, 48);
            this.b_upgrade.TabIndex = 1;
            this.b_upgrade.Text = "Upgrade Click  |  Level :  1  |  Cost :  10 $";
            this.b_upgrade.UseVisualStyleBackColor = true;
            this.b_upgrade.Click += new System.EventHandler(this.b_upgrade_Click);
            // 
            // l_clicks
            // 
            this.l_clicks.AutoSize = true;
            this.l_clicks.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_clicks.Location = new System.Drawing.Point(13, 13);
            this.l_clicks.Name = "l_clicks";
            this.l_clicks.Size = new System.Drawing.Size(151, 33);
            this.l_clicks.TabIndex = 2;
            this.l_clicks.Text = "Clicks  :  0";
            // 
            // l_money
            // 
            this.l_money.AutoSize = true;
            this.l_money.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_money.Location = new System.Drawing.Point(13, 46);
            this.l_money.Name = "l_money";
            this.l_money.Size = new System.Drawing.Size(174, 33);
            this.l_money.TabIndex = 3;
            this.l_money.Text = "Money :  0 $";
            // 
            // b_rng_upgrade
            // 
            this.b_rng_upgrade.Enabled = false;
            this.b_rng_upgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_rng_upgrade.Location = new System.Drawing.Point(11, 385);
            this.b_rng_upgrade.Name = "b_rng_upgrade";
            this.b_rng_upgrade.Size = new System.Drawing.Size(348, 48);
            this.b_rng_upgrade.TabIndex = 4;
            this.b_rng_upgrade.Text = "Unlock Roll the Dice  |  Cost : 100 $";
            this.b_rng_upgrade.UseVisualStyleBackColor = true;
            this.b_rng_upgrade.Click += new System.EventHandler(this.b_rng_upgrade_Click);
            // 
            // b_rng
            // 
            this.b_rng.Enabled = false;
            this.b_rng.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_rng.Location = new System.Drawing.Point(13, 440);
            this.b_rng.Name = "b_rng";
            this.b_rng.Size = new System.Drawing.Size(346, 102);
            this.b_rng.TabIndex = 5;
            this.b_rng.Text = "Roll the Dice !";
            this.b_rng.UseVisualStyleBackColor = true;
            this.b_rng.Click += new System.EventHandler(this.b_rng_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 554);
            this.Controls.Add(this.b_rng);
            this.Controls.Add(this.b_rng_upgrade);
            this.Controls.Add(this.l_money);
            this.Controls.Add(this.l_clicks);
            this.Controls.Add(this.b_upgrade);
            this.Controls.Add(this.b_clicker);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_clicker;
        private System.Windows.Forms.Button b_upgrade;
        private System.Windows.Forms.Label l_clicks;
        private System.Windows.Forms.Label l_money;
        private System.Windows.Forms.Button b_rng_upgrade;
        private System.Windows.Forms.Button b_rng;
    }
}

