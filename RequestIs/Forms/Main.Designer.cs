namespace RequestIs.Forms
{
    partial class Main
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
            this.RequestsButton = new System.Windows.Forms.Button();
            this.UsersButton = new System.Windows.Forms.Button();
            this.SubmitRequestButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AdminPanel = new System.Windows.Forms.Panel();
            this.StoryButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.InfoButton = new System.Windows.Forms.Button();
            this.AdminPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(293, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Главная";
            // 
            // RequestsButton
            // 
            this.RequestsButton.Location = new System.Drawing.Point(18, 95);
            this.RequestsButton.Name = "RequestsButton";
            this.RequestsButton.Size = new System.Drawing.Size(147, 36);
            this.RequestsButton.TabIndex = 3;
            this.RequestsButton.Text = "Заявки";
            this.RequestsButton.UseVisualStyleBackColor = true;
            this.RequestsButton.Click += new System.EventHandler(this.RequestsButton_Click);
            // 
            // UsersButton
            // 
            this.UsersButton.Location = new System.Drawing.Point(509, 95);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(147, 36);
            this.UsersButton.TabIndex = 4;
            this.UsersButton.Text = "Пользователи";
            this.UsersButton.UseVisualStyleBackColor = true;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // SubmitRequestButton
            // 
            this.SubmitRequestButton.Location = new System.Drawing.Point(39, 107);
            this.SubmitRequestButton.Name = "SubmitRequestButton";
            this.SubmitRequestButton.Size = new System.Drawing.Size(147, 36);
            this.SubmitRequestButton.TabIndex = 5;
            this.SubmitRequestButton.Text = "Оставить заявку";
            this.SubmitRequestButton.UseVisualStyleBackColor = true;
            this.SubmitRequestButton.Click += new System.EventHandler(this.SubmitRequestButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Мои заявки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminPanel
            // 
            this.AdminPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminPanel.Controls.Add(this.StoryButton);
            this.AdminPanel.Controls.Add(this.label2);
            this.AdminPanel.Controls.Add(this.UsersButton);
            this.AdminPanel.Controls.Add(this.RequestsButton);
            this.AdminPanel.Location = new System.Drawing.Point(12, 281);
            this.AdminPanel.Name = "AdminPanel";
            this.AdminPanel.Size = new System.Drawing.Size(675, 233);
            this.AdminPanel.TabIndex = 7;
            this.AdminPanel.Visible = false;
            // 
            // StoryButton
            // 
            this.StoryButton.Location = new System.Drawing.Point(260, 95);
            this.StoryButton.Name = "StoryButton";
            this.StoryButton.Size = new System.Drawing.Size(147, 36);
            this.StoryButton.TabIndex = 6;
            this.StoryButton.Text = "История";
            this.StoryButton.UseVisualStyleBackColor = true;
            this.StoryButton.Click += new System.EventHandler(this.StoryButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(297, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Админ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 546);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ProfileButton
            // 
            this.ProfileButton.Location = new System.Drawing.Point(521, 107);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(147, 36);
            this.ProfileButton.TabIndex = 8;
            this.ProfileButton.Text = "Профиль";
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(246, 202);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(201, 36);
            this.InfoButton.TabIndex = 9;
            this.InfoButton.Text = "Информация о себе";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 603);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AdminPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SubmitRequestButton);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.AdminPanel.ResumeLayout(false);
            this.AdminPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RequestsButton;
        private System.Windows.Forms.Button UsersButton;
        private System.Windows.Forms.Button SubmitRequestButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel AdminPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button StoryButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Button InfoButton;
    }
}