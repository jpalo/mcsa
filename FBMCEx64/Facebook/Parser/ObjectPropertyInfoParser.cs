using Facebook.Entity;
using System.Xml;
using Facebook.Utility;

namespace Facebook.Parser
{
    internal sealed class ObjectPropertyInfoParser
    {
        internal static ObjectPropertyInfo ParseObjectPropertyInfo(XmlNode node)
        {
            var result = new ObjectPropertyInfo();

            if (node != null)
            {
                result.Name = XmlHelper.GetNodeText(node, "name");
                result.DataType = (ObjectPropertyType)int.Parse(XmlHelper.GetNodeText(node, "data_type"));
                result.IndexType = int.Parse(XmlHelper.GetNodeText(node, "index_type"));
            }

            return result;
        }
    }
}
