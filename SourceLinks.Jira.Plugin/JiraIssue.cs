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

namespace SourceLinks.Plugin.Jira
{
    /// <summary>Data entity that represents a specific Jira issue.</summary>
    public class JiraIssue
    {
        /// <summary>Gets or sets the issue key.</summary>
        public string Key { get; set; }

        /// <summary>Gets or sets the summary text.</summary>
        public string Summary { get; set; }

        /// <summary>Gets or sets the description.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the issue type.</summary>
        public string IssueType { get; set; }

        /// <summary>Gets or sets the priority of the issue.</summary>
        public string Priority { get; set; }

        /// <summary>Gets or sets the status of the issue.</summary>
        public string Status { get; set; }

        /// <summary>Gets or sets the name of the reporter.</summary>
        public string Reporter { get; set; }

        /// <summary>Gets or sets the name of the assignee.</summary>
        public string Assignee { get; set; }

        /// <summary>Gets or sets the date for when the issue was created.</summary>
        public DateTime Created { get; set; }

        /// <summary>Gets or sets the date where the issue was last updated.</summary>
        public DateTime Updated { get; set; }

        /// <summary>Gets or sets the date for when the issue was resolved.</summary>
        public DateTime? ResolvedDate { get; set; }

        /// <inheritdoc cref="object"/>
        public override string ToString()
        {
            return $"{Key} - {Summary}";
        }
    }
}