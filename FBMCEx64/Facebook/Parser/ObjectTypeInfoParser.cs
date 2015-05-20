using Facebook.Entity;
using System.Xml;
using Facebook.Utility;

namespace Facebook.Parser
{
    internal sealed class ObjectTypeInfoParser
    {
        internal static ObjectTypeInfo ParseObjectTypeInfo(XmlNode node)
        {
            var objectTypeInfo = new ObjectTypeInfo();

            if (node != null)
            {
                objectTypeInfo.Name = XmlHelper.GetNodeText(node, "name");
                objectTypeInfo.ObjectClass = XmlHelper.GetNodeText(node, "object_class");
                var element = node as XmlElement;
                if (element != null)
                {
                    var propertyNodes = element.GetElementsByTagName("object_property_info");

                    foreach (XmlNode propertyNode in propertyNodes)
                    {
                        objectTypeInfo.Properties.Add(ObjectPropertyInfoParser.ParseObjectPropertyInfo(propertyNode));
                    }
                }
            }

            return objectTypeInfo;
        }
    }
}
