using Microsoft.Xml.XMLGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace FaxSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            var path = System.IO.Path.GetDirectoryName(
      System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            XmlTextWriter textWriter = new XmlTextWriter("FAXGateway.xml", null);
            textWriter.Formatting = Formatting.Indented;
            XmlQualifiedName qname = new XmlQualifiedName("SendOutboundFAX", "http://www.childmaintenance.gsi.gov.uk");
            XmlSampleGenerator generator = new XmlSampleGenerator("Schemas\\FAXGateway.xsd", qname);
            generator.WriteXml(textWriter);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] pdfBytes = File.ReadAllBytes("pdf-sample.pdf");
            string pdfBase64 = Convert.ToBase64String(pdfBytes);
            System.IO.File.WriteAllText("pdf-sample.txt", pdfBase64);
        }
    }
}
