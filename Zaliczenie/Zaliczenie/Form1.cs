using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaliczenie
{
    public partial class Form1 : Form
    {
        private HtmlDocument document;
        private HashSet<HtmlDocument> documentHandlers;

        private IDictionary<HtmlElement, string> elementStyles = new Dictionary<HtmlElement, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument htmlDoc = browser.Document;

            document = browser.Document;

            //-- add our handler only once
            //if (!this.documentHandlers.Contains(document))
            //{
                document.MouseOver += new HtmlElementEventHandler(document_MouseOver);
                document.MouseLeave += new HtmlElementEventHandler(document_MouseLeave);

                mshtml.HTMLDocumentEvents2_Event iEvent;
                mshtml.IHTMLDocument2 currentDoc = (mshtml.IHTMLDocument2)browser.Document.DomDocument;

                iEvent = (mshtml.HTMLDocumentEvents2_Event)currentDoc;
                iEvent.onclick += new mshtml.HTMLDocumentEvents2_onclickEventHandler(clickDocumentHandler);

           //     this.documentHandlers.Add(document);
           // }
        }

        private void document_MouseLeave(object sender, HtmlElementEventArgs e)
        {
            HtmlElement element = e.FromElement;
            if (this.elementStyles.ContainsKey(element))
            {
                string style = this.elementStyles[element];
                this.elementStyles.Remove(element);
                element.Style = style;
            }

            mshtml.HTMLElementEvents2_Event iEvent;
            iEvent = element.DomElement as mshtml.HTMLElementEvents2_Event;
            if (iEvent == null)
                return;
            iEvent.onclick -= new mshtml.HTMLElementEvents2_onclickEventHandler(clickElementHandler);
        }

        private void document_MouseOver(object sender, HtmlElementEventArgs e)
        {
            HtmlElement element = e.ToElement;
            if (!this.elementStyles.ContainsKey(element))
            {
                string style = element.Style;
                this.elementStyles.Add(element, style);
                element.Style = style + "; border: 1px dotted lightblue; cursor: crosshair;";
                this.Text = element.TagName ?? "(no id)";
            }

            mshtml.HTMLElementEvents2_Event iEvent;
            iEvent = element.DomElement as mshtml.HTMLElementEvents2_Event;
            if (iEvent == null)
                return;
            iEvent.onclick += new mshtml.HTMLElementEvents2_onclickEventHandler(clickElementHandler);
        }

        private bool clickDocumentHandler(mshtml.IHTMLEventObj e)
        {
            mshtml.IHTMLElement element = (mshtml.IHTMLElement) e.srcElement;

            string euid = DateTime.Now.ToString("yyyymmddhhssfff");
            element.setAttribute("data-euid", euid);
            element.setAttribute("style", "background:red;");
            dataGridView1.Rows.Add(euid, element.tagName, "");

            this.Text = e.srcElement.toString();
            e.cancelBubble = true;
            e.returnValue = false;
            return false;
        }

        private bool clickElementHandler(mshtml.IHTMLEventObj pEvtObj)
        {
            mshtml.IHTMLElement element = (mshtml.IHTMLElement)pEvtObj.srcElement;
            this.Text = element.toString();
            pEvtObj.cancelBubble = true;
            pEvtObj.returnValue = false;

            return false;
        }

        private void process_Click(object sender, EventArgs e)
        {
            browser.Url = new Uri(targetUrl.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
