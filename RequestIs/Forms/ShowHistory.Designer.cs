namespace RequestIs.Forms
{
    partial class ShowHistory
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
            this.DoctorsDataGridView = new System.Windows.Forms.DataGridView();
            this.BackButton = new System.Windows.Forms.Button();
            this.idDocrors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DoctorsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(327, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "История";
            // 
            // DoctorsDataGridView
            // 
            this.DoctorsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DoctorsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocrors,
            this.HeaderRequest,
            this.ContentRequest,
            this.StatusRequest});
            this.DoctorsDataGridView.Location = new System.Drawing.Point(27, 76);
            this.DoctorsDataGridView.Name = "DoctorsDataGridView";
            this.DoctorsDataGridView.RowHeadersWidth = 51;
            this.DoctorsDataGridView.RowTemplate.Height = 24;
            this.DoctorsDataGridView.Size = new System.Drawing.Size(708, 392);
            this.DoctorsDataGridView.TabIndex = 4;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(27, 16);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(114, 36);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // idDocrors
            // 
            this.idDocrors.HeaderText = "id";
            this.idDocrors.MinimumWidth = 6;
            this.idDocrors.Name = "idDocrors";
            this.idDocrors.Visible = false;
            this.idDocrors.Width = 125;
            // 
            // HeaderRequest
            // 
            this.HeaderRequest.HeaderText = "Заголовок заявки";
            this.HeaderRequest.MinimumWidth = 6;
            this.HeaderRequest.Name = "HeaderRequest";
            this.HeaderRequest.Width = 125;
            // 
            // ContentRequest
            // 
            this.ContentRequest.HeaderText = "Текст заявки";
            this.ContentRequest.MinimumWidth = 6;
            this.ContentRequest.Name = "ContentRequest";
            this.ContentRequest.Width = 125;
            // 
            // StatusRequest
            // 
            this.StatusRequest.HeaderText = "Статус";
            this.StatusRequest.MinimumWidth = 6;
            this.StatusRequest.Name = "StatusRequest";
            this.StatusRequest.Width = 125;
            // 
            // ShowHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 518);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.DoctorsDataGridView);
            this.Controls.Add(this.label1);
            this.Name = "ShowHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "История";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShowHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DoctorsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DoctorsDataGridView;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusRequest;
    }
}