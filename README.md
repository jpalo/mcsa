Using Media Center Status Application you can easily keep your friends in Facebook or Twitter up to date on what you watch and listen in Media Center. Application makes a Facebook wall post based on the media that is currently playing. Wall post will contain media name and optionally also media details fetched from Amazon. Twitter tweet is simpler and only contain text. You can also update the status to XML file and use it in any way you wish. 

You can also follow your Twitter friends tweets using the application. You will get a notification in Media Center whenever someone you follow tweets. Tweet is shown 5 or 10 seconds depending on length of the tweet. Dialogs will automatically disappear after 5 or 10 seconds, or you can close it immediately by pressing OK in the tweet dialog (just press OK on remote control).

**Status updates**

You can fully customize the status strings. By default, if you're watching recorded TV, live TV, DVD or video, your status is updated to `is watching [program/video/DVD](program_video_DVD)`. 

* If you're recording TV program, your status will be updated to `is recording [program](program)`. 

* If you're watching pictures, you status will be changed to `is looking at pictures`. 

* If you're listening to music status will be `is listening to [artist](artist) - [track/album](track_album)`. You may configure if status will be updated per track or per album.

Application checks Media Center status every 10 seconds (configurable) and only updates the status if change is detected.

**Other features you can configure**
* Confirmation before updating the status on Facebook or Twitter
* Get detailed media information from Amazon (cover, artist/album, rating, link to Amazon item)
* Limit which friends' tweets are shown in Media Center. If you don't set this, you see tweets from everyone you follow.
* Times between which the statuses are updated, e.g., only update my Twitter status between 8 pm and 2 am.
* Exclude some status updates based on the media title (uses regular expressions), e.g., don't update status if TV show title contains "wild" (but what would be the fun in that)
* Disable status events completely on certain media type, e.g., don't ever update status from any DVD being watched
* Clear XML status when exiting Media Center
* Suspend Tweet display for specific time period

**Requirements**
* Windows Vista/7/8 with Media Center
* .NET Framework 2.0. 
* Facebook or Twitter account (not needed if updating status only to XML file)
