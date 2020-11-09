namespace TestGMAP
{
    partial class ActionForm
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
            this.b_dialog = new System.Windows.Forms.Button();
            this.b_changeColor = new System.Windows.Forms.Button();
            this.b_addRandom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_dialog
            // 
            this.b_dialog.Location = new System.Drawing.Point(12, 12);
            this.b_dialog.Name = "b_dialog";
            this.b_dialog.Size = new System.Drawing.Size(236, 38);
            this.b_dialog.TabIndex = 0;
            this.b_dialog.Text = "Show dialog";
            this.b_dialog.UseVisualStyleBackColor = true;
            this.b_dialog.Click += new System.EventHandler(this.b_dialog_Click);
            // 
            // b_changeColor
            // 
            this.b_changeColor.Location = new System.Drawing.Point(12, 56);
            this.b_changeColor.Name = "b_changeColor";
            this.b_changeColor.Size = new System.Drawing.Size(236, 38);
            this.b_changeColor.TabIndex = 1;
            this.b_changeColor.Text = "Change Marker Color";
            this.b_changeColor.UseVisualStyleBackColor = true;
            this.b_changeColor.Click += new System.EventHandler(this.b_changeColor_Click);
            // 
            // b_addRandom
            // 
            this.b_addRandom.Location = new System.Drawing.Point(12, 100);
            this.b_addRandom.Name = "b_addRandom";
            this.b_addRandom.Size = new System.Drawing.Size(236, 38);
            this.b_addRandom.TabIndex = 2;
            this.b_addRandom.Text = "Add Random Marker";
            this.b_addRandom.UseVisualStyleBackColor = true;
            this.b_addRandom.Click += new System.EventHandler(this.b_addRandom_Click);
            // 
            // ActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 152);
            this.Controls.Add(this.b_addRandom);
            this.Controls.Add(this.b_changeColor);
            this.Controls.Add(this.b_dialog);
            this.Name = "ActionForm";
            this.Text = "ActionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_dialog;
        private System.Windows.Forms.Button b_changeColor;
        private System.Windows.Forms.Button b_addRandom;
    }
}