using System;
using System.Collections.Generic;

namespace Facebook.Types.Stream
{
    public class attachment
    {
        public string name { get; set; }
        public string href { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public attachment_property properties { get; set; }
        public List<attachment_media> media { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
    public class attachment_property
    {
        public attachment_category category { get; set; }
        public string ratings { get; set; }
    }
    public class attachment_category
    {
        public string href { get; set; }
        public string text { get; set; }

    }
    public class attachment_media
    {
        public attachment_media_type type { get; set; }
    }
    public class attachment_media_image : attachment_media
    {
        public attachment_media_image()
        {
            this.type = attachment_media_type.image;
        }
        public string src { get; set; }
        public string href { get; set; }
    }
    public class attachment_media_flash : attachment_media
    {
        public attachment_media_flash()
        {
            this.type = attachment_media_type.flash;
        }
        public string swfsrc { get; set; }
        public string imgsrc { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int expanded_width { get; set; }
        public int expanded_height { get; set; }
    }

    public class attachment_media_mp3 : attachment_media
    {
        public attachment_media_mp3()
        {
            this.type = attachment_media_type.mp3;
        }
        public string src { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
    }
    public class attachment_media_video : attachment_media
    {
        public attachment_media_video()
        {
            this.type = attachment_media_type.video;
        }
        public string video_src { get; set; }
        public string preview_img { get; set; }
        public string video_link { get; set; }
        public string video_title { get; set; }
    }

    public enum attachment_media_type
    {
        image, flash, mp3, video
    }
}
