using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml;
using Facebook.Entity;
using Facebook.Types;
using Facebook.Utility;

namespace Facebook.Parser
{
	internal static class UserParser
	{
		/// <summary>
		/// Uses DOM parsing to constitute a PhotoTag data object given the xml returned from facebook
		/// </summary>
		internal static User ParseUser(XmlNode node)
		{
			var user = new User();

			if (!Equals(node, null))
			{
				var nodeElement = node as XmlElement;

				user.UserId = XmlHelper.GetNodeText(node, "uid");
				user.FirstName = XmlHelper.GetNodeText(node, "first_name");
				user.LastName = XmlHelper.GetNodeText(node, "last_name");
				user.Name = XmlHelper.GetNodeText(node, "name");
				
				user.AboutMe = XmlHelper.GetNodeText(node, "about_me");
				user.NotesCount = int.Parse(XmlHelper.GetNodeText(node, "notes_count", Enums.NodeTypes.Int));
				user.WallCount = int.Parse(XmlHelper.GetNodeText(node, "wall_count", Enums.NodeTypes.Int));


				if (!String.IsNullOrEmpty(XmlHelper.GetNodeText(node, "profile_update_time")) &&
				    double.Parse(XmlHelper.GetNodeText(node, "profile_update_time")) > 0)
				{
					user.ProfileUpdateDate =
						DateHelper.ConvertDoubleToDate(double.Parse(XmlHelper.GetNodeText(node, "profile_update_time"),
						                                            CultureInfo.InvariantCulture));
				}

				

				var statusNodeList = nodeElement.GetElementsByTagName("status");
				user.Status.Message = XmlHelper.GetNodeText(statusNodeList[statusNodeList.Count - 1], "message");
				if (!String.IsNullOrEmpty(XmlHelper.GetNodeText(statusNodeList[statusNodeList.Count - 1], "time")))
				{
					user.Status.Time =
						DateHelper.ConvertDoubleToDate(double.Parse(
						                               	XmlHelper.GetNodeText(statusNodeList[statusNodeList.Count - 1], "time"),
						                               	CultureInfo.InvariantCulture));
				}

				
			}
			return user;
		}

		/// <summary>
		/// Uses DOM parsing to constitute a collection of relationshiptype object given the xml returned from facebook
		/// </summary>
		private static Collection<LookingFor> ParseRelationshipTypes(XmlNode node)
		{
			var relationshipTypeList = new Collection<LookingFor>();

			foreach (XmlNode seekingNode in ((XmlElement) node).GetElementsByTagName("seeking"))
			{
				try
				{
					relationshipTypeList.Add(
						(LookingFor) Enum.Parse(typeof (LookingFor), (seekingNode).InnerText.Replace(" ", "").Replace("'", ""), true));
				}
				catch (ArgumentException)
				{
					// if there was no enum for this relationship type, we set it to Unknown
					relationshipTypeList.Add(LookingFor.Unknown);
				}
			}
			return relationshipTypeList;
		}

		/// <summary>
		/// Uses DOM parsing to constitute a collection of genderlist object given the xml returned from facebook
		/// </summary>
		private static Collection<Gender> ParseInterestedInGenders(XmlNode node)
		{
			var genderList = new Collection<Gender>();

			foreach (XmlNode sexNode in ((XmlElement) node).GetElementsByTagName("sex"))
			{
				genderList.Add((Gender) Enum.Parse(typeof (Gender), (sexNode).InnerText, true));
			}
			return genderList;
		}
	}
}