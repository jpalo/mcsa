using Facebook.Entity;
using System.Xml;
using Facebook.Utility;

namespace Facebook.Parser
{
    internal sealed class DataAssociationParser
    {
        internal static DataAssociation ParseDataAssociation(XmlNode node)
        {
            var result = new DataAssociation();
            if (node != null)
            {
                long id1, id2;

                if(long.TryParse(XmlHelper.GetNodeText(node, "id1"), out id1))
                {
                    result.ID1 = id1;
                }

                if (long.TryParse(XmlHelper.GetNodeText(node, "id2"), out id2))
                {
                    result.ID2 = id2;
                }
                
                result.Data = XmlHelper.GetNodeText(node, "data");
                result.Name = XmlHelper.GetNodeText(node, "name");
                double timeStamp;
                if (double.TryParse(XmlHelper.GetNodeText(node, "time"), out timeStamp))
                {
                    var createTime = DateHelper.ConvertDoubleToDate(timeStamp);
                    result.Time = createTime;
                }
            }

            return result;
        }
    }
}
