using Facebook.Entity;
using System.Xml;

namespace Facebook.Parser
{
    internal sealed class DataObjectParser
    {
        internal static DataObject ParseDataObject(XmlNode node)
        {
            var result = new DataObject();

            if (node != null)
            {
                foreach (XmlNode prop in node.ChildNodes)
                {
                    result.Properties.Add(prop.Name, prop.InnerText);
                }
            }

            return result;
        }
    }
}
