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
using System.Collections;
using WholeTomatoSoftware.SourceLinks;

namespace SourceLinks.Plugin.Jira
{
    public class SettingsHandler
    {
        public JiraConnection LoadSettings()
        {
            var result = new JiraConnection();
            try
            {
                var hashtable = PluginUtils.LoadSettings(typeof(JiraPlugin));

                if (null == hashtable)
                {
                    throw new NullReferenceException("No settings for JiraPlugin.");
                }
                result.ServerUrl = hashtable.GetValue("server", "");
                result.Username = hashtable.GetValue("Username", "");
                result.Password = hashtable.GetValue("Password", "");
            }
            catch
            {
                result.ServerUrl = "";
                result.Username = "";
                result.Password = "";
            }
            return result;
        }

        public void SaveSettings(JiraConnection connection)
        {
            var hashtable = new Hashtable
            {
                {"server", connection.ServerUrl},
                {"Username", connection.Username},
                {"Password", connection.Password}
            };
            PluginUtils.SaveSettings(typeof(JiraPlugin), hashtable);
        }
    }
}