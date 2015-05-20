using System;
using System.Globalization;
using System.Xml;
using Facebook.Entity;
using Facebook.Utility;

namespace Facebook.Parser
{
	internal static class AdminParser
	{
		/// <summary>
		/// Uses DOM parsing to constitute a data object given the xml returned from facebook
		/// </summary>
		internal static Admin ParseAdmin(XmlNode node)
		{
			var admin = new Admin();
			if (node != null)
			{
				admin.notifications_per_day = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.daily_active_users = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.unique_adds = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.unique_removes = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.unique_blocks = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.unique_unblocks = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.api_calls = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.unique_api_calls = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.canvas_page_views = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.unique_canvas_page_views = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.canvas_http_request_time_avg = XmlHelper.GetNodeText(node, "notifications_per_day");
				admin.canvas_fbml_render_time_avg = XmlHelper.GetNodeText(node, "notifications_per_day");
			}
			return admin;
		}
	}
}