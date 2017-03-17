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
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using RestSharp.Extensions.MonoHttp;
using WholeTomatoSoftware.SourceLinks;

namespace SourceLinks.Plugin.Jira
{
    /// <summary>
    /// 
    /// </summary>
    public class JiraPlugin : IPlugin
    {
        private readonly SettingsHandler _settingsHandler;
        private JiraConnection _connection;

        public JiraPlugin()
        {
            _settingsHandler = new SettingsHandler();
            _connection = _settingsHandler.LoadSettings();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanConfigure()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Configure()
        {
            using (var dialog = new ConfigurationDialogForm())
            {
                if (dialog.ShowDialog(_connection) == DialogResult.OK)
                {
                    var data = dialog.ConnectionInfo;
                    _settingsHandler.SaveSettings(data);
                    _connection = _settingsHandler.LoadSettings();
                }
            }
        }

        public string Name
        {
            get { return "Jira Plugin"; }
        }

        public string OverrideUrl
        {
            // JIRA:XNET-3456 
            get { return string.Format("{0}/browse/%s", _connection.ServerUrl); }
        }

        public string GetTooltip2(string markerText)
        {
            string txt = string.Empty;
            try
            {
                var caseDetails = _connection.LoadIssue(markerText);
                if (null != caseDetails)
                {
                    txt = txt + "<Span Foreground=\"Navy\"><Bold>Title:</Bold></Span> " + HttpUtility.HtmlEncode(caseDetails.Summary);
                    txt = txt + "<LineBreak /><Span Foreground=\"Navy\"><Bold>Status:</Bold></Span> " + HttpUtility.HtmlEncode(caseDetails.Status);
                    txt = txt + "<LineBreak /><Span Foreground=\"Navy\"><Bold>Assigned To:</Bold></Span> " + HttpUtility.HtmlEncode(caseDetails.Assignee);

                    if (caseDetails.ResolvedDate.HasValue)
                    {
                        txt = txt + "<LineBreak /><Span Foreground=\"Navy\"><Bold>Date Resolved:</Bold></Span> " +
                              caseDetails.ResolvedDate.Value.ToShortDateString();
                    }

                    txt = txt + "<LineBreak /><Span Foreground=\"Navy\"><Bold>Date Opened:</Bold></Span> " + caseDetails.Created.ToShortDateString();

                    if (txt.IndexOf("<Paragraph", StringComparison.Ordinal) == -1 && txt.IndexOf("<paragraph", StringComparison.Ordinal) == -1)
                    {
                        txt = "<Paragraph>" + txt + "</Paragraph>";
                    }
                    txt = txt.Replace("\r\n", "<LineBreak />");
                    txt = txt.Replace("\n", "<LineBreak />");
                    txt = txt.Replace("\r", "<LineBreak />");

                    txt = "<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">" + txt + "</FlowDocument>";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return txt;
        }

        /// <summary>
        /// case:40
        /// </summary>
        /// <param name="markerText"></param>
        /// <returns></returns>
        public string GetTooltip(string markerText)
        {
            try
            {
                var issue = _connection.LoadIssue(markerText);
                if (issue != null)
                {
                    const string span = "<Span><Bold>{0}:</Bold></Span> {1}<Linebreak />";

                    var xmlns = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml/presentation");

                    XElement paragraph;

                    var doc = new XDocument(
                        new XElement(xmlns + "FlowDocument",
                            new XAttribute(XNamespace.Xmlns + "x", "http://schemas.microsoft.com/winfx/2006/xaml"),
                            new XElement(xmlns + "Paragraph",
                                new XElement(xmlns + "Span",
                                    new XAttribute("FontSize", 14),
                                    new XAttribute("FontStyle", "Bold"),
                                    new XText(issue.Key)
                                )
                            ),

                            paragraph = new XElement(xmlns + "Paragraph")
                        )
                    );

                    paragraph.AddElement(xmlns, "Summary", issue.Summary);
                    paragraph.AddElement(xmlns, "Type", issue.IssueType);
                    paragraph.AddElement(xmlns, "Priority", issue.Priority);
                    paragraph.AddElement(xmlns, "Status", issue.Status);
                    paragraph.AddElement(xmlns, "Reporter", issue.Reporter);
                    paragraph.AddElement(xmlns, "Assignee", issue.Assignee);
                    paragraph.AddElement(xmlns, "Created", issue.Created.ToShortDateString());
                    if (issue.ResolvedDate.HasValue)
                    {
                        paragraph.AddElement(xmlns, "Resolved", issue.ResolvedDate.Value.ToShortDateString());
                    }

                    var tooltip = doc.ToString(SaveOptions.DisableFormatting);

                    return tooltip;
                }
                return markerText;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    public static class XElementExtensions
    {
        public static void AddElement(this XElement element, XNamespace ns, string label, string value)
        {
            element.Add(

                new XElement(ns + "Bold", label + ": "),
                new XText(value),
                new XElement(ns + "LineBreak")
            );
        }
    }
}
