using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace dregg
{
    public class ReleaseNotes
    {
        private Version version;
        private List<Api.Ticket> entries = new List<Api.Ticket>();
        public Version Version { get { return this.version; } set { this.version = value; } }
        public List<Api.Ticket> Entries
        {
            get { return this.entries; }
            set { this.entries = value; }
        }

        public void ToHTML(string outputPath)
        {
            using (var file = new StreamWriter(outputPath))
            {
                using (var writer = new HtmlTextWriter(file))
                {
                    writer.WriteLine(@"<!DOCTYPE html>");
                    writer.RenderBeginTag(HtmlTextWriterTag.Html);
                        writer.RenderBeginTag(HtmlTextWriterTag.Head);
                    writer.AddAttribute("charset", "utf-8");
                    writer.RenderBeginTag(HtmlTextWriterTag.Meta);
                        writer.RenderEndTag();
                    writer.AddAttribute("name", "generator");
                    writer.AddAttribute("content", "dragg");
                    writer.RenderBeginTag(HtmlTextWriterTag.Meta);
                        writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Title);
                        writer.Write("Release Notes SimulationX", this.version);
                    writer.RenderEndTag();
                    writer.AddAttribute("rel", "stylesheet");
                    writer.AddAttribute("href", @"file:///D:/ITI-Projekte_NoBackup/Notes/css/style.css");
                    writer.RenderBeginTag(HtmlTextWriterTag.Link);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Body);
                        writer.RenderBeginTag(HtmlTextWriterTag.H1);
                            writer.WriteLine("Release Notes SimulationX", this.version);
                        writer.RenderEndTag();
                        writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                    foreach (var entry in this.entries)
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Li);
                        writer.RenderBeginTag(HtmlTextWriterTag.P);
                            writer.WriteEncodedText(entry.Id);
                        writer.RenderEndTag();
                        writer.RenderBeginTag(HtmlTextWriterTag.P);
                        writer.WriteEncodedText(entry.Data.Source);
                        writer.RenderEndTag();
                        writer.RenderBeginTag(HtmlTextWriterTag.P);
                        writer.WriteEncodedText(entry.Data.Summary);
                        writer.RenderEndTag();
                        writer.RenderEndTag();
                    }
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }
            }
            Process.Start(outputPath);
        }
    }
}
