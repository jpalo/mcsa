using System;
using System.Xml;
using Facebook.Properties;
using Facebook.Types;

namespace Facebook.Utility
{
	internal static class XmlHelper
	{
		/// <summary>
		/// Method to return the inner text of a node.
		/// </summary>
		/// <param name="node">The node to parse.</param>
		/// <param name="name">The node name.</param>
		/// <returns>The text containted by the node.</returns>
		internal static string GetNodeText(XmlNode node, string name)
		{
			if (node == null) return string.Empty;

			var xmlElement = node as XmlElement;
			if (xmlElement == null) return string.Empty;

			var nodeList = xmlElement.GetElementsByTagName(name);
			return nodeList.Count > 0 ? nodeList[0].InnerText : string.Empty;
		}

		/// <summary>
		/// Method to return the inner text of a node, or the default value based on the type provided.
		/// Use the Enums.NodeTypes to select a default return value.
		/// </summary>
		/// <param name="node">The node to parse.</param>
		/// <param name="name">The node name.</param>
		/// <param name="nodeType">The type of resource to assign to</param>
		/// <returns>The text containted by the node, or the default based on the nodeType.</returns>
		internal static string GetNodeText(XmlNode node, string name, Enums.NodeTypes nodeType)
		{
			var returnString = GetNodeText(node, name);

			if (nodeType.Equals(Enums.NodeTypes.ImageURL))
			{
				if (String.IsNullOrEmpty(returnString))
				{
					returnString = Resources.MissingPictureUrl;
				}
			}
			if (nodeType.Equals(Enums.NodeTypes.Double))
			{
				try
				{
					double.Parse(returnString);
				}
				catch
				{
					returnString = "0.0";
				}
			}
			if (nodeType.Equals(Enums.NodeTypes.DateTime))
			{
				try
				{
					DateTime.Parse(returnString);
				}
				catch
				{
					returnString = "1/1/1900";
				}
			}
			if (nodeType.Equals(Enums.NodeTypes.Int))
			{
				try
				{
					int.Parse(returnString);
				}
				catch
				{
					returnString = "-1";
				}
			}

			return returnString;
		}
	}
}