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
    /// <summary>
    /// 
    /// </summary>
    public class JiraIssue
    {
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Summary { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string IssueType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Reporter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Assignee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ResolvedDate { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Key, Summary);
        }
    }
}