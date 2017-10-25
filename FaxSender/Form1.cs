using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using Microsoft.Xml.XMLGen;
using System.Diagnostics;

namespace FaxSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            SendFAXGatewayWebReference.SendFAXGatewayHttpServiceSoapClient client = new SendFAXGatewayWebReference.SendFAXGatewayHttpServiceSoapClient();

            var parameter = new SendFAXGatewayWebReference.SendFAX();
            parameter.SendOutboundFAX = new SendFAXGatewayWebReference.SendOutboundFAXType();
            parameter.SendOutboundFAX.UserName = "User Name";
            parameter.SendOutboundFAX.Sender = "Sender 1";
            parameter.SendOutboundFAX.Receipt = "Receipt 1";
            parameter.SendOutboundFAX.Priority = "1";
            parameter.SendOutboundFAX.FaxRequestDateTime = "01-01-2018T12:00:00";
            parameter.SendOutboundFAX.Documents = new SendFAXGatewayWebReference.Document[3];

            var pdfFile = new SendFAXGatewayWebReference.Document();
            pdfFile.SeqNumber = "1";
            pdfFile.DocumentId = Guid.NewGuid().ToString();
            pdfFile.DocumentType = SendFAXGatewayWebReference.DocumentType.PDF;


            byte[] pdfBytes = System.IO.File.ReadAllBytes(@"..\..\Files\pdf-sample.pdf");

            pdfFile.DocumentContent = pdfBytes;

            parameter.SendOutboundFAX.Documents[0] = pdfFile;

            client.SendFAX(parameter);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t = DateTime.Now.ToString().Replace(@"/", "").Replace(" ", "").Replace(":", "");
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            XmlTextWriter textWriter = new XmlTextWriter("FAXmessage" + t + ".xml", null);
            textWriter.Formatting = Formatting.Indented;
            XmlQualifiedName qname = new XmlQualifiedName("SendOutboundFAX", "");
            XmlSampleGenerator generator = new XmlSampleGenerator("..\\..\\Schemas\\FAXGateway.xsd",qname); /* The "..\..\" are to avoid moving the Schema directory to the Debug directory - for some reason the system was looking for the schema file in .\bin\Debug\Schemas */
            generator.WriteXml(textWriter);
        }   

        private void button4_Click(object sender, EventArgs e)
        {
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            MessageBox.Show(path.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string t1 = DateTime.Now.ToString().Replace(@"/", "").Replace(" ", "").Replace(":","") ;
           
            MessageBox.Show(t1);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Random r = new Random();
            int i = 0;
            
            for (int j = 0; j <= 100; j++){

                i = r.Next(1, 4);

                //if (i == 3) {
                    //MessageBox.Show(i.ToString());
                //}
            } 
                
        }
    }
}
