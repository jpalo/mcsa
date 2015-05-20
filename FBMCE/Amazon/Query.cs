using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml;
using System.Web;

namespace FBMCE.Amazon
{
    public static class Query
    {
        private const string MY_AWS_ACCESS_KEY_ID = "";
        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";

        /// <summary>
        /// Searches for one item
        /// </summary>
        /// <param name="status">Search string</param>
        /// <returns>ASIN of first item</returns>
        public static string[] SearchItems(string status, string searchIndex, string[] amazonDetails, string amazonLocaleApiUrl)
        {
            IDictionary<string, string> r1 = new Dictionary<string, String>();
            r1["Service"] = "AWSECommerceService";
            r1["Version"] = "2011-08-01";
            r1["Operation"] = "ItemSearch";

            if (searchIndex.Equals("Music"))
            {
                string[] songInfo = status.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                r1["Artist"] = songInfo[0];
                r1["Title"] = songInfo[1];
                r1["SearchIndex"] = searchIndex;
            }
            else if (searchIndex.StartsWith("TV"))
            {
                r1["Keywords"] = HttpUtility.HtmlEncode(status.Replace('.', ' ').Replace('-', ' '));

                //string durationString = searchIndex.Substring(searchIndex.IndexOf('|') + 1);

                //if (!string.IsNullOrEmpty(durationString))
                //{
                //    int duration = int.Parse(durationString);

                //    if (duration < 3600)
                //    {
                //        r1["BrowseNode"] = GetTelevisionBrowseNodeId(amazonLocaleApiUrl);
                //    }
                //}

                r1["SearchIndex"] = "DVD";
            }
            else
            {
                r1["Keywords"] = HttpUtility.HtmlEncode(status.Replace('.', ' ').Replace('-', ' '));
                r1["SearchIndex"] = searchIndex;
            }

            r1["ResponseGroup"] = "Small";
            r1["AssociateTag"] = GetAssociateTag(amazonLocaleApiUrl);

            SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, amazonLocaleApiUrl);

            string requestUrl = helper.Sign(r1);
            return FetchItem(requestUrl, amazonDetails);
        }

        private static string GetTelevisionBrowseNodeId(string amazonLocaleApiUrl)
        {
            switch (amazonLocaleApiUrl)
            {
                case ("ecs.amazonaws.co.uk"):
                    return "342350011";

                case ("ecs.amazonaws.fr"):
                    return "409468";

                case ("ecs.amazonaws.ca"):
                    return "953128";

                case ("ecs.amazonaws.jp"):
                    return "16286781";

                case ("ecs.amazonaws.de"):
                    return "508214";

                default:
                    return "163450";
            }
        }

        public static string GetAssociateTag(string amazonLocaleApiUrl)
        {
            switch (amazonLocaleApiUrl)
            {
                case ("ecs.amazonaws.co.uk"):
                    return "medicentstata-21";

                case ("ecs.amazonaws.fr"):
                    return "medicentst04a-21";

                case ("ecs.amazonaws.ca"):
                    return "medicentstata-20";

                case ("ecs.amazonaws.jp"):
                    return "medicentstata-22";

                case ("ecs.amazonaws.de"):
                    return "medicentsta0a-21";

                default:
                    return "mediacenterstatustool-20";
            }
        }

        public static string[] LookupItem(string[] amazonDetails, string amazonLocaleUrl)
        {
            IDictionary<string, string> r1 = new Dictionary<string, String>();
            r1["Service"] = "AWSECommerceService";
            r1["Version"] = "2011-08-01";
            r1["Operation"] = "ItemLookup";
            r1["ItemId"] = amazonDetails[4];
            r1["ResponseGroup"] = "Reviews,Images";
            r1["AssociateTag"] = GetAssociateTag(amazonLocaleUrl);

            SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, amazonLocaleUrl);

            string requestUrl = helper.Sign(r1);
            return FetchItemDetails(requestUrl, amazonDetails);
        }

        private static string[] FetchItem(string url, string[] amazonDetails)
        {
            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                XmlDocument doc = new XmlDocument();
                doc.Load(response.GetResponseStream());

                XmlNodeList errorMessageNodes = doc.GetElementsByTagName("Message", NAMESPACE);
                if (errorMessageNodes != null && errorMessageNodes.Count > 0)
                {
                    amazonDetails[3] = errorMessageNodes.Item(0).InnerText;
                    return amazonDetails;
                }

                XmlNode titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(0);

                if (titleNode != null)
                {
                    amazonDetails[0] = titleNode.InnerText;
                }

                XmlNode artistNode = doc.GetElementsByTagName("Artist", NAMESPACE).Item(0);

                if (artistNode != null)
                {
                    amazonDetails[6] = artistNode.InnerText;
                }

                XmlNode urlNode = doc.GetElementsByTagName("DetailPageURL", NAMESPACE).Item(0);

                if (urlNode != null)
                {
                    amazonDetails[1] = urlNode.InnerText;
                }

                XmlNode asin = doc.GetElementsByTagName("ASIN", NAMESPACE).Item(0);

                if (asin != null)
                {
                    amazonDetails[4] = asin.InnerText;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Caught Exception: " + e.Message);
                System.Console.WriteLine("Stack Trace: " + e.StackTrace);
            }

            return amazonDetails;
        }

        private static string[] FetchItemDetails(string url, string[] amazonDetails)
        {
            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                XmlDocument doc = new XmlDocument();
                doc.Load(response.GetResponseStream());

                XmlNodeList errorMessageNodes = doc.GetElementsByTagName("Message", NAMESPACE);
                if (errorMessageNodes != null && errorMessageNodes.Count > 0)
                {
                    amazonDetails[3] = errorMessageNodes.Item(0).InnerText;
                    return amazonDetails;
                }

                XmlNamespaceManager xmlNSM = new XmlNamespaceManager(doc.NameTable);
                xmlNSM.AddNamespace("a", NAMESPACE);

                XmlNode imageUrlNode = doc.SelectSingleNode("//a:Item/a:SmallImage/a:URL", xmlNSM);

                if (imageUrlNode != null)
                {
                    amazonDetails[2] = imageUrlNode.InnerText;
                }

                XmlNode averageRating = doc.GetElementsByTagName("AverageRating", NAMESPACE).Item(0);

                if (averageRating != null)
                {
                    amazonDetails[5] = averageRating.InnerText;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Caught Exception: " + e.Message);
                System.Console.WriteLine("Stack Trace: " + e.StackTrace);
            }

            return amazonDetails;
        }
    }
}
