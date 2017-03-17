namespace SourceLinks.Plugin.Jira
{
    partial class ConfigurationDialogForm
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
            this.ServerUrlLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.ServerUrlTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.DialogCancelButton = new System.Windows.Forms.Button();
            this.TestConnectionButton = new System.Windows.Forms.Button();
            this.DialogAcceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerUrlLabel
            // 
            this.ServerUrlLabel.AutoSize = true;
            this.ServerUrlLabel.Location = new System.Drawing.Point(12, 11);
            this.ServerUrlLabel.Name = "ServerUrlLabel";
            this.ServerUrlLabel.Size = new System.Drawing.Size(54, 13);
            this.ServerUrlLabel.TabIndex = 0;
            this.ServerUrlLabel.Text = "&Server Url";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(12, 37);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "&Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 63);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "&Password";
            // 
            // ServerUrlTextBox
            // 
            this.ServerUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerUrlTextBox.Location = new System.Drawing.Point(95, 8);
            this.ServerUrlTextBox.Name = "ServerUrlTextBox";
            this.ServerUrlTextBox.Size = new System.Drawing.Size(240, 20);
            this.ServerUrlTextBox.TabIndex = 1;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameTextBox.Location = new System.Drawing.Point(95, 34);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(240, 20);
            this.UsernameTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Location = new System.Drawing.Point(95, 60);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(240, 20);
            this.PasswordTextBox.TabIndex = 5;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // DialogCancelButton
            // 
            this.DialogCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DialogCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DialogCancelButton.Location = new System.Drawing.Point(260, 86);
            this.DialogCancelButton.Name = "DialogCancelButton";
            this.DialogCancelButton.Size = new System.Drawing.Size(75, 23);
            this.DialogCancelButton.TabIndex = 8;
            this.DialogCancelButton.Text = "&Cancel";
            this.DialogCancelButton.UseVisualStyleBackColor = true;
            // 
            // TestConnectionButton
            // 
            this.TestConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TestConnectionButton.Location = new System.Drawing.Point(12, 86);
            this.TestConnectionButton.Name = "TestConnectionButton";
            this.TestConnectionButton.Size = new System.Drawing.Size(75, 23);
            this.TestConnectionButton.TabIndex = 6;
            this.TestConnectionButton.Text = "&Test";
            this.TestConnectionButton.UseVisualStyleBackColor = true;
            this.TestConnectionButton.Click += new System.EventHandler(this.TestConnectionButton_Click);
            // 
            // DialogAcceptButton
            // 
            this.DialogAcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DialogAcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DialogAcceptButton.Location = new System.Drawing.Point(179, 86);
            this.DialogAcceptButton.Name = "DialogAcceptButton";
            this.DialogAcceptButton.Size = new System.Drawing.Size(75, 23);
            this.DialogAcceptButton.TabIndex = 7;
            this.DialogAcceptButton.Text = "&Ok";
            this.DialogAcceptButton.UseVisualStyleBackColor = true;
            this.DialogAcceptButton.Click += new System.EventHandler(this.DialogAcceptButton_Click);
            // 
            // ConfigurationDialogForm
            // 
            this.AcceptButton = this.DialogAcceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DialogCancelButton;
            this.ClientSize = new System.Drawing.Size(350, 121);
            this.Controls.Add(this.DialogAcceptButton);
            this.Controls.Add(this.TestConnectionButton);
            this.Controls.Add(this.DialogCancelButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.ServerUrlTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.ServerUrlLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jira Plugin Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerUrlLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox ServerUrlTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button DialogCancelButton;
        private System.Windows.Forms.Button TestConnectionButton;
        private System.Windows.Forms.Button DialogAcceptButton;
    }
}