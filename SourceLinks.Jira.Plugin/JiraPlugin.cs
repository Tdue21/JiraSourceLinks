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
using System.Xml.Linq;
using RestSharp.Extensions.MonoHttp;
using WholeTomatoSoftware.SourceLinks;

namespace SourceLinks.Plugin.Jira
{
    /// <summary>
    /// Implements the <see cref="IPlugin"/> interface for supplying a plugin for the Visual Studio extension 
    /// <a href="http://www.wholetomato.com/sourcelinks/default.asp">SourceLinks 2</a>.
    /// </summary>
    public class JiraPlugin : IPlugin
    {
        private readonly SettingsHandler _settingsHandler;
        private JiraConnection _connection;

        /// <summary>The constructor of the plugin.</summary>
        public JiraPlugin()
        {
            _settingsHandler = new SettingsHandler();
            _connection = _settingsHandler.LoadSettings();
        }

        /// <summary>Returns true as the extension provides a configuration UI.</summary>
        /// <returns>True</returns>
        public bool CanConfigure() => true;

        /// <summary>Gets the name of the plugin.</summary>
        public string Name => "Jira Plugin";

        /// <summary>Gets the override Url for the plugin.</summary>
        public string OverrideUrl => $"{_connection.ServerUrl}/browse/%s";

        /// <summary>Shows the configuration dialog for the plugin.</summary>
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

        /// <summary>Assemble a tooltip string using the marker text as input.</summary>
        /// <param name="markerText">The marker text</param>
        /// <returns>A string containing the tooltip as a flow document.</returns>
        public string GetTooltip(string markerText)
        {
            // case:40 JIRA:XNET-12 JIRA:OF-12

            try
            {
                var issue = _connection.LoadIssue(markerText);
                if (issue != null)
                {
                    var xmlns = XNamespace.Get("http://schemas.microsoft.com/winfx/2006/xaml/presentation");

                    XElement paragraph;

                    var doc = new XDocument(
                        new XElement(xmlns + "FlowDocument",
                            new XAttribute(XNamespace.Xmlns + "x", "http://schemas.microsoft.com/winfx/2006/xaml"),
                            new XElement(xmlns + "Paragraph"
                            //,
                            //    new XElement(xmlns + "Span",
                            //        new XAttribute("FontSize", 14),
                            //        new XAttribute("FontStyle", "Bold"),
                            //        new XText(HttpUtility.HtmlEncode(issue.Key))
                            //    )
                            ),

                            paragraph = new XElement(xmlns + "Paragraph")
                        )
                    );

                    paragraph.AddElement(xmlns, "Summary", HttpUtility.HtmlEncode(issue.Summary));
                    paragraph.AddElement(xmlns, "Type", HttpUtility.HtmlEncode(issue.IssueType));
                    paragraph.AddElement(xmlns, "Priority", HttpUtility.HtmlEncode(issue.Priority));
                    paragraph.AddElement(xmlns, "Status", HttpUtility.HtmlEncode(issue.Status));
                    paragraph.AddElement(xmlns, "Reporter", HttpUtility.HtmlEncode(issue.Reporter));
                    paragraph.AddElement(xmlns, "Assignee", HttpUtility.HtmlEncode(issue.Assignee));
                    paragraph.AddElement(xmlns, "Created", HttpUtility.HtmlEncode(issue.Created.ToShortDateString()));

                    if (issue.ResolvedDate.HasValue)
                    {
                        paragraph.AddElement(xmlns, "Resolved", HttpUtility.HtmlEncode(issue.ResolvedDate.Value.ToShortDateString()));
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
}
