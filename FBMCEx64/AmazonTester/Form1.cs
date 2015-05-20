using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Web;

namespace AmazonTester
{
    public partial class Form1 : Form
    {
        private const string MY_AWS_ACCESS_KEY_ID = "";
        private const string MY_AWS_SECRET_KEY = "";
        private const string DESTINATION = "ecs.amazonaws.com";
        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> r1 = new Dictionary<string, String>();
            r1["Service"] = "AWSECommerceService";
            r1["Version"] = "2011-08-01";
            r1["Operation"] = "ItemSearch";
            r1["Keywords"] = "Flaming Lips Yoshimi battles the pink robots";
            //r1["ResponseGroup"] = "Small,Images,Reviews";
            r1["ResponseGroup"] = "Small";
            r1["SearchIndex"] = "Music";
            r1["AssociateTag"] = "mediacenterstatustool-20";           

            SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, MY_AWS_SECRET_KEY, DESTINATION);

            string requestUrl = helper.Sign(r1);
            string[] details = FetchItemInformation(requestUrl);

            if (string.IsNullOrEmpty(details[3]))
            {
                MessageBox.Show(String.Join(", ", details));
            }
        }

        private string[] FetchItemInformation(string url)
        {
            string[] retVal = { "", "", "", "" };

            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                XmlDocument doc = new XmlDocument();
                doc.Load(response.GetResponseStream());

                XmlNodeList errorMessageNodes = doc.GetElementsByTagName("Message", NAMESPACE);
                if (errorMessageNodes != null && errorMessageNodes.Count > 0)
                {
                    retVal[3] = errorMessageNodes.Item(0).InnerText;
                    return retVal;
                }

                XmlNode titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(0);
                retVal[0] = titleNode.InnerText;

                XmlNode urlNode = doc.GetElementsByTagName("DetailPageURL", NAMESPACE).Item(0);
                retVal[1] = urlNode.InnerText;

                XmlNamespaceManager xmlNSM = new XmlNamespaceManager(doc.NameTable);
                xmlNSM.AddNamespace("a", NAMESPACE);

                XmlNode imageUrlNode = doc.SelectSingleNode("//a:Item/a:SmallImage/a:URL", xmlNSM);
                retVal[2] = imageUrlNode.InnerText;
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Caught Exception: " + e.Message);
                System.Console.WriteLine("Stack Trace: " + e.StackTrace);
            }

            return retVal;
        }
    }
}
