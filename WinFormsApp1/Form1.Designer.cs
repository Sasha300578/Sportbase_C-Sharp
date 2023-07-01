namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_enter = new System.Windows.Forms.Label();
            this.button_user = new System.Windows.Forms.Button();
            this.button_admin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_enter
            // 
            this.label_enter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_enter.AutoSize = true;
            this.label_enter.BackColor = System.Drawing.SystemColors.Menu;
            this.label_enter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_enter.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_enter.Location = new System.Drawing.Point(36, 181);
            this.label_enter.Name = "label_enter";
            this.label_enter.Size = new System.Drawing.Size(149, 34);
            this.label_enter.TabIndex = 0;
            this.label_enter.Text = "Войти как";
            // 
            // button_user
            // 
            this.button_user.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_user.AutoSize = true;
            this.button_user.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_user.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_user.Location = new System.Drawing.Point(36, 216);
            this.button_user.Name = "button_user";
            this.button_user.Size = new System.Drawing.Size(224, 60);
            this.button_user.TabIndex = 1;
            this.button_user.Text = "Гость";
            this.button_user.UseVisualStyleBackColor = false;
            this.button_user.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_admin
            // 
            this.button_admin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_admin.AutoSize = true;
            this.button_admin.BackColor = System.Drawing.Color.RoyalBlue;
            this.button_admin.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_admin.Location = new System.Drawing.Point(36, 282);
            this.button_admin.Name = "button_admin";
            this.button_admin.Size = new System.Drawing.Size(224, 60);
            this.button_admin.TabIndex = 2;
            this.button_admin.Text = "Администратор";
            this.button_admin.UseVisualStyleBackColor = false;
            this.button_admin.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(828, 544);
            this.Controls.Add(this.button_admin);
            this.Controls.Add(this.button_user);
            this.Controls.Add(this.label_enter);
            this.Name = "Form1";
            this.Text = "Спортбаза";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_enter;
        private Button button_user;
        private Button button_admin;
    }
}