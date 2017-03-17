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
using System.Linq;
using System.Windows.Forms;

namespace SourceLinks.Plugin.Jira
{
    /// <summary>
    /// 
    /// </summary>
    public class JiraConnection
    {
        /// <summary>
        /// JIRA:VTOEM-1
        /// </summary>
        public string ServerUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="issueKey"></param>
        /// <returns></returns>
        public JiraIssue LoadIssue(string issueKey)
        {
            var jira = Atlassian.Jira.Jira.CreateRestClient(ServerUrl, Username, Password);
            var issue = jira.GetIssue(issueKey);
            var result = new JiraIssue
            {
                Key = issueKey,
                Summary = issue.Summary,
                Description = issue.Description,
                Reporter = issue.Reporter,
                Assignee = issue.Assignee,
                Status = issue.Status.Name,
                IssueType = issue.Type.Name,
                Priority = issue.Priority.Name,
                Created = issue.Created.GetValueOrDefault(),
                Updated = issue.Updated.GetValueOrDefault(),
                ResolvedDate = issue.ResolutionDate,
            };
            return result;
        }

        public void TestConnection()
        {
            var jira = Atlassian.Jira.Jira.CreateRestClient(ServerUrl, Username, Password);
            var project = jira.GetProjects().FirstOrDefault();
        }
    }
}