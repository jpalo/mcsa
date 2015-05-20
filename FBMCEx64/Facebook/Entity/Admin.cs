using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Entity
{
	[Serializable]
	public class Admin
	{
		public string notifications_per_day { get; set; }
		public string daily_active_users { get; set; }
		public string unique_adds { get; set; }
		public string unique_removes { get; set; }
		public string unique_blocks { get; set; }
		public string unique_unblocks { get; set; }
		public string api_calls { get; set; }
		public string unique_api_calls { get; set; }
		public string canvas_page_views { get; set; }
		public string unique_canvas_page_views { get; set; }
		public string canvas_http_request_time_avg { get; set; }
		public string canvas_fbml_render_time_avg { get; set; }
	}
}
