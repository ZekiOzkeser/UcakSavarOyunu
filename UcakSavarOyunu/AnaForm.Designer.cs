
namespace UcakSavarOyunu
{
    partial class AnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.pnlAlt = new System.Windows.Forms.Panel();
            this.btnCikis = new System.Windows.Forms.Button();
            this.lblSkor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlOyunAlani = new System.Windows.Forms.Panel();
            this.pnlAlt.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAlt
            // 
            this.pnlAlt.Controls.Add(this.btnCikis);
            this.pnlAlt.Controls.Add(this.lblSkor);
            this.pnlAlt.Controls.Add(this.label1);
            this.pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlt.Location = new System.Drawing.Point(0, 831);
            this.pnlAlt.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAlt.Name = "pnlAlt";
            this.pnlAlt.Size = new System.Drawing.Size(1723, 85);
            this.pnlAlt.TabIndex = 0;
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Location = new System.Drawing.Point(1578, 43);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(93, 30);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.TabStop = false;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCikis_Clic);
            // 
            // lblSkor
            // 
            this.lblSkor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSkor.AutoSize = true;
            this.lblSkor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSkor.Location = new System.Drawing.Point(1661, 15);
            this.lblSkor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSkor.Name = "lblSkor";
            this.lblSkor.Size = new System.Drawing.Size(24, 25);
            this.lblSkor.TabIndex = 2;
            this.lblSkor.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1561, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SKOR : ";
            // 
            // pnlOyunAlani
            // 
            this.pnlOyunAlani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOyunAlani.Location = new System.Drawing.Point(0, 0);
            this.pnlOyunAlani.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOyunAlani.Name = "pnlOyunAlani";
            this.pnlOyunAlani.Size = new System.Drawing.Size(1723, 831);
            this.pnlOyunAlani.TabIndex = 2;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1723, 916);
            this.Controls.Add(this.pnlOyunAlani);
            this.Controls.Add(this.pnlAlt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AnaForm";
            this.Text = "Uçak Savar Oyunu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnaForm_KeyDown);
            this.pnlAlt.ResumeLayout(false);
            this.pnlAlt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAlt;
        private System.Windows.Forms.Panel pnlOyunAlani;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Label lblSkor;
        private System.Windows.Forms.Label label1;
    }
}