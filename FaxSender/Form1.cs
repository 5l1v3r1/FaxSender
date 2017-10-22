using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

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
    }
}
