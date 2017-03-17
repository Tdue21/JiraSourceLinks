// ************************************************************************************
// * MIT License
// * 
// * Copyright (c) 2017 by Scanvaegt Systems A/S
// * 
// * Permission is hereby granted, free of charge, to any person obtaining a copy
// * of this software and associated documentation files (the "Software"), to deal
// * in the Software without restriction, including without limitation the rights
// * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// * copies of the Software, and to permit persons to whom the Software is
// * furnished to do so, subject to the following conditions:
// * 
// * The above copyright notice and this permission notice shall be included in all
// * copies or substantial portions of the Software.
// * 
// * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// * SOFTWARE.
// ************************************************************************************


using System;
using System.Windows.Forms;

namespace SourceLinks.Plugin.Jira
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ConfigurationDialogForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public ConfigurationDialogForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public JiraConnection ConnectionInfo { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionInfo"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(JiraConnection connectionInfo)
        {
            PrepareDialog(connectionInfo);
            return ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionInfo"></param>
        private void PrepareDialog(JiraConnection connectionInfo)
        {
            if (connectionInfo == null)
            {
                throw new ArgumentNullException(nameof(connectionInfo));
            }

            ServerUrlTextBox.Text = connectionInfo.ServerUrl;
            UsernameTextBox.Text = connectionInfo.Username;
            PasswordTextBox.Text = connectionInfo.Password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DialogAcceptButton_Click(object sender, EventArgs e) => ConnectionInfo = GetJiraConnection();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                var connection = GetJiraConnection();
                connection.TestConnection();

                MessageBox.Show(this, "Connection seems to be ok.", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Connection failed: {ex.Message}", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private JiraConnection GetJiraConnection()
        {
            return new JiraConnection
            {
                ServerUrl = ServerUrlTextBox.Text,
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Text
            };
        }
    }
}
