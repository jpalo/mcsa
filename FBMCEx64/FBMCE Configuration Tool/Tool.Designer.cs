namespace FBMCE_Configuration_Tool
{
    partial class Tool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tool));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.btnClearTwitterOfflineData = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btnClearFacebookOfflineData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pollingInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.debug = new System.Windows.Forms.CheckBox();
            this.tabServices = new System.Windows.Forms.TabPage();
            this.i = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.service_Twitter_SuspendTime = new System.Windows.Forms.TextBox();
            this.service_Twitter_EnableSuspend = new System.Windows.Forms.CheckBox();
            this.twitterConfirmUpdates = new System.Windows.Forms.CheckBox();
            this.twitterFriends = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.twitterFrequencyOfFriendStatusQueries = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.eventsEnabled_Service_TwitterFriends = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.twitterEnabledBetweenEnd = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.twitterEnabledBetweenStart = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.eventsEnabled_Service_Twitter = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FacebookUpdateType = new System.Windows.Forms.ListBox();
            this.label18 = new System.Windows.Forms.Label();
            this.clearStatusOnExit = new System.Windows.Forms.CheckBox();
            this.amazonLocaleUrl_Label = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.amazonLocaleUrl = new System.Windows.Forms.ComboBox();
            this.facebookConfirmUpdates = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.facebookEnabledBetweenEnd = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.facebookEnabledBetweenStart = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.eventsEnabled_Service_Facebook = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.service_Xml_ClearStatusOnExit = new System.Windows.Forms.CheckBox();
            this.service_Xml_ClearWhenNoMedia = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnBrowseXmlFilePath = new System.Windows.Forms.Button();
            this.xmlEnabledBetweenEnd = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.xmlFilePath = new System.Windows.Forms.TextBox();
            this.xmlEnabledBetweenStart = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.eventsEnabled_Service_Xml = new System.Windows.Forms.CheckBox();
            this.tabExclusions = new System.Windows.Forms.TabPage();
            this.exclusions_RecordingTV = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.exclusions_Video = new System.Windows.Forms.TextBox();
            this.exclusions_TV = new System.Windows.Forms.TextBox();
            this.exclusions_RecordedTV = new System.Windows.Forms.TextBox();
            this.exclusions_Pictures = new System.Windows.Forms.TextBox();
            this.exclusions_Music = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.exclusions_DVD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.eventsConfig_Video_QueryAmazon = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.eventsConfig_Video_StatusString = new System.Windows.Forms.TextBox();
            this.events_Video = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.eventsConfig_TV_QueryAmazon = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.eventsConfig_TV_StatusString = new System.Windows.Forms.TextBox();
            this.events_TV = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.eventsConfig_RecordingTV_QueryAmazon = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.eventsConfig_RecordingTV_StatusString = new System.Windows.Forms.TextBox();
            this.events_RecordingTV = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.eventsConfig_RecordedTV_QueryAmazon = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.eventsConfig_RecordedTV_StatusString = new System.Windows.Forms.TextBox();
            this.events_RecordedTV = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.eventsConfig_Pictures_QueryAmazon = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.eventsConfig_Pictures_StatusString = new System.Windows.Forms.TextBox();
            this.events_Pictures = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.eventsConfig_Music_QueryAmazon = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.eventsConfig_Music_StatusString = new System.Windows.Forms.TextBox();
            this.events_Music = new System.Windows.Forms.CheckBox();
            this.albumMode = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.eventsConfig_DVD_QueryAmazon = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.events_DVD = new System.Windows.Forms.CheckBox();
            this.eventsConfig_DVD_StatusString = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.helpUrl = new System.Windows.Forms.LinkLabel();
            this.tabControl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabServices.SuspendLayout();
            this.i.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabExclusions.SuspendLayout();
            this.tabEvents.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGeneral);
            this.tabControl.Controls.Add(this.tabServices);
            this.tabControl.Controls.Add(this.tabExclusions);
            this.tabControl.Controls.Add(this.tabEvents);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(617, 557);
            this.tabControl.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.label30);
            this.tabGeneral.Controls.Add(this.btnClearTwitterOfflineData);
            this.tabGeneral.Controls.Add(this.label23);
            this.tabGeneral.Controls.Add(this.btnClearFacebookOfflineData);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.pollingInterval);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.debug);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(609, 531);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 183);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(452, 13);
            this.label30.TabIndex = 13;
            this.label30.Text = "Removes session information from registry that is used to persist Twitter login b" +
    "etween sessions";
            // 
            // btnClearTwitterOfflineData
            // 
            this.btnClearTwitterOfflineData.Location = new System.Drawing.Point(19, 157);
            this.btnClearTwitterOfflineData.Name = "btnClearTwitterOfflineData";
            this.btnClearTwitterOfflineData.Size = new System.Drawing.Size(203, 23);
            this.btnClearTwitterOfflineData.TabIndex = 12;
            this.btnClearTwitterOfflineData.Text = "Remove Twitter Session Information";
            this.btnClearTwitterOfflineData.UseVisualStyleBackColor = true;
            this.btnClearTwitterOfflineData.Click += new System.EventHandler(this.btnClearTwitterOfflineData_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(16, 122);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(468, 13);
            this.label23.TabIndex = 11;
            this.label23.Text = "Removes session information from registry that is used to persist Facebook login " +
    "between sessions";
            // 
            // btnClearFacebookOfflineData
            // 
            this.btnClearFacebookOfflineData.Location = new System.Drawing.Point(19, 96);
            this.btnClearFacebookOfflineData.Name = "btnClearFacebookOfflineData";
            this.btnClearFacebookOfflineData.Size = new System.Drawing.Size(203, 23);
            this.btnClearFacebookOfflineData.TabIndex = 10;
            this.btnClearFacebookOfflineData.Text = "Remove Facebook Session Information";
            this.btnClearFacebookOfflineData.UseVisualStyleBackColor = true;
            this.btnClearFacebookOfflineData.Click += new System.EventHandler(this.btnClearOfflineData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "seconds";
            // 
            // pollingInterval
            // 
            this.pollingInterval.Location = new System.Drawing.Point(98, 23);
            this.pollingInterval.Name = "pollingInterval";
            this.pollingInterval.Size = new System.Drawing.Size(100, 20);
            this.pollingInterval.TabIndex = 4;
            this.pollingInterval.TextChanged += new System.EventHandler(this.pollingInterval_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Polling Interval";
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(19, 52);
            this.debug.Name = "debug";
            this.debug.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.debug.Size = new System.Drawing.Size(58, 17);
            this.debug.TabIndex = 0;
            this.debug.Text = "Debug";
            this.debug.UseVisualStyleBackColor = true;
            // 
            // tabServices
            // 
            this.tabServices.Controls.Add(this.i);
            this.tabServices.Controls.Add(this.groupBox2);
            this.tabServices.Controls.Add(this.groupBox1);
            this.tabServices.Location = new System.Drawing.Point(4, 22);
            this.tabServices.Name = "tabServices";
            this.tabServices.Padding = new System.Windows.Forms.Padding(3);
            this.tabServices.Size = new System.Drawing.Size(609, 531);
            this.tabServices.TabIndex = 1;
            this.tabServices.Text = "Services";
            this.tabServices.UseVisualStyleBackColor = true;
            // 
            // i
            // 
            this.i.Controls.Add(this.label19);
            this.i.Controls.Add(this.service_Twitter_SuspendTime);
            this.i.Controls.Add(this.service_Twitter_EnableSuspend);
            this.i.Controls.Add(this.twitterConfirmUpdates);
            this.i.Controls.Add(this.twitterFriends);
            this.i.Controls.Add(this.label38);
            this.i.Controls.Add(this.label37);
            this.i.Controls.Add(this.twitterFrequencyOfFriendStatusQueries);
            this.i.Controls.Add(this.label36);
            this.i.Controls.Add(this.eventsEnabled_Service_TwitterFriends);
            this.i.Controls.Add(this.label31);
            this.i.Controls.Add(this.twitterEnabledBetweenEnd);
            this.i.Controls.Add(this.label32);
            this.i.Controls.Add(this.twitterEnabledBetweenStart);
            this.i.Controls.Add(this.label33);
            this.i.Controls.Add(this.eventsEnabled_Service_Twitter);
            this.i.Location = new System.Drawing.Point(6, 193);
            this.i.Name = "i";
            this.i.Size = new System.Drawing.Size(597, 201);
            this.i.TabIndex = 11;
            this.i.TabStop = false;
            this.i.Text = "Twitter";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(340, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "minutes to suspend";
            // 
            // service_Twitter_SuspendTime
            // 
            this.service_Twitter_SuspendTime.Location = new System.Drawing.Point(310, 17);
            this.service_Twitter_SuspendTime.Name = "service_Twitter_SuspendTime";
            this.service_Twitter_SuspendTime.Size = new System.Drawing.Size(24, 20);
            this.service_Twitter_SuspendTime.TabIndex = 19;
            this.service_Twitter_SuspendTime.TextChanged += new System.EventHandler(this.service_Twitter_SuspendTime_TextChanged);
            // 
            // service_Twitter_EnableSuspend
            // 
            this.service_Twitter_EnableSuspend.AutoSize = true;
            this.service_Twitter_EnableSuspend.Location = new System.Drawing.Point(153, 19);
            this.service_Twitter_EnableSuspend.Name = "service_Twitter_EnableSuspend";
            this.service_Twitter_EnableSuspend.Size = new System.Drawing.Size(151, 17);
            this.service_Twitter_EnableSuspend.TabIndex = 18;
            this.service_Twitter_EnableSuspend.Text = "Enable Tweet Suspending";
            this.service_Twitter_EnableSuspend.UseVisualStyleBackColor = true;
            this.service_Twitter_EnableSuspend.CheckedChanged += new System.EventHandler(this.service_Twitter_EnableSuspend_CheckedChanged);
            // 
            // twitterConfirmUpdates
            // 
            this.twitterConfirmUpdates.AutoSize = true;
            this.twitterConfirmUpdates.Location = new System.Drawing.Point(9, 42);
            this.twitterConfirmUpdates.Name = "twitterConfirmUpdates";
            this.twitterConfirmUpdates.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.twitterConfirmUpdates.Size = new System.Drawing.Size(104, 17);
            this.twitterConfirmUpdates.TabIndex = 13;
            this.twitterConfirmUpdates.Text = "Confirm Updates";
            this.twitterConfirmUpdates.UseVisualStyleBackColor = true;
            // 
            // twitterFriends
            // 
            this.twitterFriends.Location = new System.Drawing.Point(9, 174);
            this.twitterFriends.MaxLength = 1024;
            this.twitterFriends.Name = "twitterFriends";
            this.twitterFriends.Size = new System.Drawing.Size(582, 20);
            this.twitterFriends.TabIndex = 17;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 158);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(495, 13);
            this.label38.TabIndex = 16;
            this.label38.Text = "Show tweets from these friends only. Use screen names separated by semi-colons (;" +
    "). Empty to show all.";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(173, 131);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(106, 13);
            this.label37.TabIndex = 15;
            this.label37.Text = "times per hour (1-99).";
            // 
            // twitterFrequencyOfFriendStatusQueries
            // 
            this.twitterFrequencyOfFriendStatusQueries.Location = new System.Drawing.Point(139, 128);
            this.twitterFrequencyOfFriendStatusQueries.MaxLength = 2;
            this.twitterFrequencyOfFriendStatusQueries.Name = "twitterFrequencyOfFriendStatusQueries";
            this.twitterFrequencyOfFriendStatusQueries.Size = new System.Drawing.Size(28, 20);
            this.twitterFrequencyOfFriendStatusQueries.TabIndex = 14;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 131);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(127, 13);
            this.label36.TabIndex = 13;
            this.label36.Text = "Frequency of tweet query";
            // 
            // eventsEnabled_Service_TwitterFriends
            // 
            this.eventsEnabled_Service_TwitterFriends.AutoSize = true;
            this.eventsEnabled_Service_TwitterFriends.Location = new System.Drawing.Point(9, 105);
            this.eventsEnabled_Service_TwitterFriends.Name = "eventsEnabled_Service_TwitterFriends";
            this.eventsEnabled_Service_TwitterFriends.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eventsEnabled_Service_TwitterFriends.Size = new System.Drawing.Size(87, 17);
            this.eventsEnabled_Service_TwitterFriends.TabIndex = 11;
            this.eventsEnabled_Service_TwitterFriends.Text = "Show tweets";
            this.eventsEnabled_Service_TwitterFriends.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(187, 68);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(336, 13);
            this.label31.TabIndex = 10;
            this.label31.Text = "Type in start hour and end hour in a day when service updates status.";
            // 
            // twitterEnabledBetweenEnd
            // 
            this.twitterEnabledBetweenEnd.Location = new System.Drawing.Point(152, 65);
            this.twitterEnabledBetweenEnd.MaxLength = 2;
            this.twitterEnabledBetweenEnd.Name = "twitterEnabledBetweenEnd";
            this.twitterEnabledBetweenEnd.Size = new System.Drawing.Size(28, 20);
            this.twitterEnabledBetweenEnd.TabIndex = 9;
            this.twitterEnabledBetweenEnd.TextChanged += new System.EventHandler(this.twitterEnabledBetweenEnd_TextChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(136, 68);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(10, 13);
            this.label32.TabIndex = 8;
            this.label32.Text = "-";
            // 
            // twitterEnabledBetweenStart
            // 
            this.twitterEnabledBetweenStart.Location = new System.Drawing.Point(102, 65);
            this.twitterEnabledBetweenStart.MaxLength = 2;
            this.twitterEnabledBetweenStart.Name = "twitterEnabledBetweenStart";
            this.twitterEnabledBetweenStart.Size = new System.Drawing.Size(28, 20);
            this.twitterEnabledBetweenStart.TabIndex = 7;
            this.twitterEnabledBetweenStart.TextChanged += new System.EventHandler(this.twitterEnabledBetweenStart_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 68);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(90, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "Enabled between";
            // 
            // eventsEnabled_Service_Twitter
            // 
            this.eventsEnabled_Service_Twitter.AutoSize = true;
            this.eventsEnabled_Service_Twitter.Location = new System.Drawing.Point(9, 19);
            this.eventsEnabled_Service_Twitter.Name = "eventsEnabled_Service_Twitter";
            this.eventsEnabled_Service_Twitter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eventsEnabled_Service_Twitter.Size = new System.Drawing.Size(65, 17);
            this.eventsEnabled_Service_Twitter.TabIndex = 4;
            this.eventsEnabled_Service_Twitter.Text = "Enabled";
            this.eventsEnabled_Service_Twitter.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FacebookUpdateType);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.clearStatusOnExit);
            this.groupBox2.Controls.Add(this.amazonLocaleUrl_Label);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.amazonLocaleUrl);
            this.groupBox2.Controls.Add(this.facebookConfirmUpdates);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.facebookEnabledBetweenEnd);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.facebookEnabledBetweenStart);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.eventsEnabled_Service_Facebook);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 181);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Facebook";
            // 
            // FacebookUpdateType
            // 
            this.FacebookUpdateType.FormattingEnabled = true;
            this.FacebookUpdateType.Items.AddRange(new object[] {
            "Wall and News feed"});
            this.FacebookUpdateType.Location = new System.Drawing.Point(90, 66);
            this.FacebookUpdateType.Name = "FacebookUpdateType";
            this.FacebookUpdateType.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.FacebookUpdateType.Size = new System.Drawing.Size(120, 43);
            this.FacebookUpdateType.TabIndex = 21;
            this.FacebookUpdateType.SelectedIndexChanged += new System.EventHandler(this.FacebookUpdateType_SelectedIndexChanged_1);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(226, 120);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(292, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "See Events tab to enable/disable Amazon queries per media";
            // 
            // clearStatusOnExit
            // 
            this.clearStatusOnExit.AutoSize = true;
            this.clearStatusOnExit.Location = new System.Drawing.Point(229, 65);
            this.clearStatusOnExit.Name = "clearStatusOnExit";
            this.clearStatusOnExit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clearStatusOnExit.Size = new System.Drawing.Size(118, 17);
            this.clearStatusOnExit.TabIndex = 19;
            this.clearStatusOnExit.Text = "Clear Status on Exit";
            this.clearStatusOnExit.UseVisualStyleBackColor = true;
            this.clearStatusOnExit.Visible = false;
            // 
            // amazonLocaleUrl_Label
            // 
            this.amazonLocaleUrl_Label.AutoSize = true;
            this.amazonLocaleUrl_Label.Location = new System.Drawing.Point(7, 120);
            this.amazonLocaleUrl_Label.Name = "amazonLocaleUrl_Label";
            this.amazonLocaleUrl_Label.Size = new System.Drawing.Size(76, 13);
            this.amazonLocaleUrl_Label.TabIndex = 17;
            this.amazonLocaleUrl_Label.Text = "Amazon locale";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Update type";
            // 
            // amazonLocaleUrl
            // 
            this.amazonLocaleUrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.amazonLocaleUrl.FormattingEnabled = true;
            this.amazonLocaleUrl.Items.AddRange(new object[] {
            "Amazon US",
            "Amazon UK",
            "Amazon DE",
            "Amazon JP",
            "Amazon FR",
            "Amazon CA"});
            this.amazonLocaleUrl.Location = new System.Drawing.Point(89, 117);
            this.amazonLocaleUrl.Name = "amazonLocaleUrl";
            this.amazonLocaleUrl.Size = new System.Drawing.Size(121, 21);
            this.amazonLocaleUrl.TabIndex = 13;
            // 
            // facebookConfirmUpdates
            // 
            this.facebookConfirmUpdates.AutoSize = true;
            this.facebookConfirmUpdates.Location = new System.Drawing.Point(9, 42);
            this.facebookConfirmUpdates.Name = "facebookConfirmUpdates";
            this.facebookConfirmUpdates.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.facebookConfirmUpdates.Size = new System.Drawing.Size(104, 17);
            this.facebookConfirmUpdates.TabIndex = 11;
            this.facebookConfirmUpdates.Text = "Confirm Updates";
            this.facebookConfirmUpdates.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(188, 150);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(336, 13);
            this.label26.TabIndex = 10;
            this.label26.Text = "Type in start hour and end hour in a day when service updates status.";
            // 
            // facebookEnabledBetweenEnd
            // 
            this.facebookEnabledBetweenEnd.Location = new System.Drawing.Point(153, 147);
            this.facebookEnabledBetweenEnd.MaxLength = 2;
            this.facebookEnabledBetweenEnd.Name = "facebookEnabledBetweenEnd";
            this.facebookEnabledBetweenEnd.Size = new System.Drawing.Size(28, 20);
            this.facebookEnabledBetweenEnd.TabIndex = 9;
            this.facebookEnabledBetweenEnd.TextChanged += new System.EventHandler(this.facebookEnabledBetweenEnd_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(137, 150);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(10, 13);
            this.label25.TabIndex = 8;
            this.label25.Text = "-";
            // 
            // facebookEnabledBetweenStart
            // 
            this.facebookEnabledBetweenStart.Location = new System.Drawing.Point(103, 147);
            this.facebookEnabledBetweenStart.MaxLength = 2;
            this.facebookEnabledBetweenStart.Name = "facebookEnabledBetweenStart";
            this.facebookEnabledBetweenStart.Size = new System.Drawing.Size(28, 20);
            this.facebookEnabledBetweenStart.TabIndex = 7;
            this.facebookEnabledBetweenStart.TextChanged += new System.EventHandler(this.facebookEnabledBetweenStart_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 150);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(90, 13);
            this.label24.TabIndex = 6;
            this.label24.Text = "Enabled between";
            // 
            // eventsEnabled_Service_Facebook
            // 
            this.eventsEnabled_Service_Facebook.AutoSize = true;
            this.eventsEnabled_Service_Facebook.Location = new System.Drawing.Point(9, 19);
            this.eventsEnabled_Service_Facebook.Name = "eventsEnabled_Service_Facebook";
            this.eventsEnabled_Service_Facebook.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eventsEnabled_Service_Facebook.Size = new System.Drawing.Size(65, 17);
            this.eventsEnabled_Service_Facebook.TabIndex = 4;
            this.eventsEnabled_Service_Facebook.Text = "Enabled";
            this.eventsEnabled_Service_Facebook.UseVisualStyleBackColor = true;
            this.eventsEnabled_Service_Facebook.CheckedChanged += new System.EventHandler(this.eventsEnabled_Service_Facebook_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.service_Xml_ClearStatusOnExit);
            this.groupBox1.Controls.Add(this.service_Xml_ClearWhenNoMedia);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.btnBrowseXmlFilePath);
            this.groupBox1.Controls.Add(this.xmlEnabledBetweenEnd);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.xmlFilePath);
            this.groupBox1.Controls.Add(this.xmlEnabledBetweenStart);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.eventsEnabled_Service_Xml);
            this.groupBox1.Location = new System.Drawing.Point(6, 399);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 123);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML File";
            // 
            // service_Xml_ClearStatusOnExit
            // 
            this.service_Xml_ClearStatusOnExit.AutoSize = true;
            this.service_Xml_ClearStatusOnExit.Location = new System.Drawing.Point(102, 19);
            this.service_Xml_ClearStatusOnExit.Name = "service_Xml_ClearStatusOnExit";
            this.service_Xml_ClearStatusOnExit.Size = new System.Drawing.Size(118, 17);
            this.service_Xml_ClearStatusOnExit.TabIndex = 17;
            this.service_Xml_ClearStatusOnExit.Text = "Clear Status on Exit";
            this.service_Xml_ClearStatusOnExit.UseVisualStyleBackColor = true;
            // 
            // service_Xml_ClearWhenNoMedia
            // 
            this.service_Xml_ClearWhenNoMedia.AutoSize = true;
            this.service_Xml_ClearWhenNoMedia.Location = new System.Drawing.Point(246, 19);
            this.service_Xml_ClearWhenNoMedia.Name = "service_Xml_ClearWhenNoMedia";
            this.service_Xml_ClearWhenNoMedia.Size = new System.Drawing.Size(156, 17);
            this.service_Xml_ClearWhenNoMedia.TabIndex = 16;
            this.service_Xml_ClearWhenNoMedia.Text = "Clear status when no media";
            this.service_Xml_ClearWhenNoMedia.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(187, 44);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(336, 13);
            this.label27.TabIndex = 15;
            this.label27.Text = "Type in start hour and end hour in a day when service updates status.";
            // 
            // btnBrowseXmlFilePath
            // 
            this.btnBrowseXmlFilePath.Location = new System.Drawing.Point(516, 80);
            this.btnBrowseXmlFilePath.Name = "btnBrowseXmlFilePath";
            this.btnBrowseXmlFilePath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseXmlFilePath.TabIndex = 10;
            this.btnBrowseXmlFilePath.Text = "Browse...";
            this.btnBrowseXmlFilePath.UseVisualStyleBackColor = true;
            this.btnBrowseXmlFilePath.Click += new System.EventHandler(this.btnBrowseXmlFilePath_Click);
            // 
            // xmlEnabledBetweenEnd
            // 
            this.xmlEnabledBetweenEnd.Location = new System.Drawing.Point(152, 41);
            this.xmlEnabledBetweenEnd.MaxLength = 2;
            this.xmlEnabledBetweenEnd.Name = "xmlEnabledBetweenEnd";
            this.xmlEnabledBetweenEnd.Size = new System.Drawing.Size(28, 20);
            this.xmlEnabledBetweenEnd.TabIndex = 14;
            this.xmlEnabledBetweenEnd.TextChanged += new System.EventHandler(this.xmlEnabledBetweenEnd_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(136, 44);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(10, 13);
            this.label28.TabIndex = 13;
            this.label28.Text = "-";
            // 
            // xmlFilePath
            // 
            this.xmlFilePath.Location = new System.Drawing.Point(9, 82);
            this.xmlFilePath.Name = "xmlFilePath";
            this.xmlFilePath.Size = new System.Drawing.Size(501, 20);
            this.xmlFilePath.TabIndex = 9;
            // 
            // xmlEnabledBetweenStart
            // 
            this.xmlEnabledBetweenStart.Location = new System.Drawing.Point(102, 41);
            this.xmlEnabledBetweenStart.MaxLength = 2;
            this.xmlEnabledBetweenStart.Name = "xmlEnabledBetweenStart";
            this.xmlEnabledBetweenStart.Size = new System.Drawing.Size(28, 20);
            this.xmlEnabledBetweenStart.TabIndex = 12;
            this.xmlEnabledBetweenStart.TextChanged += new System.EventHandler(this.xmlEnabledBetweenStart_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 8;
            this.label22.Text = "File path";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 44);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(90, 13);
            this.label29.TabIndex = 11;
            this.label29.Text = "Enabled between";
            // 
            // eventsEnabled_Service_Xml
            // 
            this.eventsEnabled_Service_Xml.AutoSize = true;
            this.eventsEnabled_Service_Xml.Location = new System.Drawing.Point(9, 19);
            this.eventsEnabled_Service_Xml.Name = "eventsEnabled_Service_Xml";
            this.eventsEnabled_Service_Xml.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eventsEnabled_Service_Xml.Size = new System.Drawing.Size(65, 17);
            this.eventsEnabled_Service_Xml.TabIndex = 6;
            this.eventsEnabled_Service_Xml.Text = "Enabled";
            this.eventsEnabled_Service_Xml.UseVisualStyleBackColor = true;
            this.eventsEnabled_Service_Xml.CheckedChanged += new System.EventHandler(this.eventsEnabled_Service_Xml_CheckedChanged);
            // 
            // tabExclusions
            // 
            this.tabExclusions.Controls.Add(this.exclusions_RecordingTV);
            this.tabExclusions.Controls.Add(this.label41);
            this.tabExclusions.Controls.Add(this.label20);
            this.tabExclusions.Controls.Add(this.label13);
            this.tabExclusions.Controls.Add(this.exclusions_Video);
            this.tabExclusions.Controls.Add(this.exclusions_TV);
            this.tabExclusions.Controls.Add(this.exclusions_RecordedTV);
            this.tabExclusions.Controls.Add(this.exclusions_Pictures);
            this.tabExclusions.Controls.Add(this.exclusions_Music);
            this.tabExclusions.Controls.Add(this.label12);
            this.tabExclusions.Controls.Add(this.label11);
            this.tabExclusions.Controls.Add(this.label10);
            this.tabExclusions.Controls.Add(this.label9);
            this.tabExclusions.Controls.Add(this.exclusions_DVD);
            this.tabExclusions.Controls.Add(this.label8);
            this.tabExclusions.Location = new System.Drawing.Point(4, 22);
            this.tabExclusions.Name = "tabExclusions";
            this.tabExclusions.Size = new System.Drawing.Size(609, 531);
            this.tabExclusions.TabIndex = 2;
            this.tabExclusions.Text = "Exclusions";
            this.tabExclusions.UseVisualStyleBackColor = true;
            // 
            // exclusions_RecordingTV
            // 
            this.exclusions_RecordingTV.Location = new System.Drawing.Point(90, 142);
            this.exclusions_RecordingTV.Name = "exclusions_RecordingTV";
            this.exclusions_RecordingTV.Size = new System.Drawing.Size(508, 20);
            this.exclusions_RecordingTV.TabIndex = 13;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(13, 145);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(73, 13);
            this.label41.TabIndex = 12;
            this.label41.Text = "Recording TV";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(573, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Type in regular expression to prevent statuses that match the regular expression " +
    "from being updated to external services.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Music";
            // 
            // exclusions_Video
            // 
            this.exclusions_Video.Location = new System.Drawing.Point(90, 194);
            this.exclusions_Video.Name = "exclusions_Video";
            this.exclusions_Video.Size = new System.Drawing.Size(508, 20);
            this.exclusions_Video.TabIndex = 10;
            // 
            // exclusions_TV
            // 
            this.exclusions_TV.Location = new System.Drawing.Point(90, 168);
            this.exclusions_TV.Name = "exclusions_TV";
            this.exclusions_TV.Size = new System.Drawing.Size(508, 20);
            this.exclusions_TV.TabIndex = 9;
            // 
            // exclusions_RecordedTV
            // 
            this.exclusions_RecordedTV.Location = new System.Drawing.Point(90, 117);
            this.exclusions_RecordedTV.Name = "exclusions_RecordedTV";
            this.exclusions_RecordedTV.Size = new System.Drawing.Size(508, 20);
            this.exclusions_RecordedTV.TabIndex = 8;
            // 
            // exclusions_Pictures
            // 
            this.exclusions_Pictures.Location = new System.Drawing.Point(90, 91);
            this.exclusions_Pictures.Name = "exclusions_Pictures";
            this.exclusions_Pictures.Size = new System.Drawing.Size(508, 20);
            this.exclusions_Pictures.TabIndex = 7;
            // 
            // exclusions_Music
            // 
            this.exclusions_Music.Location = new System.Drawing.Point(90, 65);
            this.exclusions_Music.Name = "exclusions_Music";
            this.exclusions_Music.Size = new System.Drawing.Size(508, 20);
            this.exclusions_Music.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "TV";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Video";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Pictures";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "DVD";
            // 
            // exclusions_DVD
            // 
            this.exclusions_DVD.Location = new System.Drawing.Point(90, 39);
            this.exclusions_DVD.Name = "exclusions_DVD";
            this.exclusions_DVD.Size = new System.Drawing.Size(508, 20);
            this.exclusions_DVD.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Recorded TV";
            // 
            // tabEvents
            // 
            this.tabEvents.Controls.Add(this.groupBox10);
            this.tabEvents.Controls.Add(this.groupBox9);
            this.tabEvents.Controls.Add(this.groupBox8);
            this.tabEvents.Controls.Add(this.groupBox7);
            this.tabEvents.Controls.Add(this.label4);
            this.tabEvents.Controls.Add(this.groupBox6);
            this.tabEvents.Controls.Add(this.groupBox5);
            this.tabEvents.Controls.Add(this.groupBox4);
            this.tabEvents.Controls.Add(this.label21);
            this.tabEvents.Location = new System.Drawing.Point(4, 22);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Size = new System.Drawing.Size(609, 531);
            this.tabEvents.TabIndex = 3;
            this.tabEvents.Text = "Events";
            this.tabEvents.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.eventsConfig_Video_QueryAmazon);
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Controls.Add(this.eventsConfig_Video_StatusString);
            this.groupBox10.Controls.Add(this.events_Video);
            this.groupBox10.Location = new System.Drawing.Point(16, 438);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(581, 60);
            this.groupBox10.TabIndex = 39;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Video";
            // 
            // eventsConfig_Video_QueryAmazon
            // 
            this.eventsConfig_Video_QueryAmazon.AutoSize = true;
            this.eventsConfig_Video_QueryAmazon.Location = new System.Drawing.Point(76, 15);
            this.eventsConfig_Video_QueryAmazon.Name = "eventsConfig_Video_QueryAmazon";
            this.eventsConfig_Video_QueryAmazon.Size = new System.Drawing.Size(95, 17);
            this.eventsConfig_Video_QueryAmazon.TabIndex = 37;
            this.eventsConfig_Video_QueryAmazon.Text = "Query Amazon";
            this.eventsConfig_Video_QueryAmazon.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Status string";
            // 
            // eventsConfig_Video_StatusString
            // 
            this.eventsConfig_Video_StatusString.Location = new System.Drawing.Point(74, 32);
            this.eventsConfig_Video_StatusString.Name = "eventsConfig_Video_StatusString";
            this.eventsConfig_Video_StatusString.Size = new System.Drawing.Size(493, 20);
            this.eventsConfig_Video_StatusString.TabIndex = 32;
            // 
            // events_Video
            // 
            this.events_Video.AutoSize = true;
            this.events_Video.Location = new System.Drawing.Point(6, 15);
            this.events_Video.Name = "events_Video";
            this.events_Video.Size = new System.Drawing.Size(65, 17);
            this.events_Video.TabIndex = 23;
            this.events_Video.Text = "Enabled";
            this.events_Video.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.eventsConfig_TV_QueryAmazon);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.eventsConfig_TV_StatusString);
            this.groupBox9.Controls.Add(this.events_TV);
            this.groupBox9.Location = new System.Drawing.Point(16, 372);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(581, 60);
            this.groupBox9.TabIndex = 38;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "TV";
            // 
            // eventsConfig_TV_QueryAmazon
            // 
            this.eventsConfig_TV_QueryAmazon.AutoSize = true;
            this.eventsConfig_TV_QueryAmazon.Location = new System.Drawing.Point(76, 15);
            this.eventsConfig_TV_QueryAmazon.Name = "eventsConfig_TV_QueryAmazon";
            this.eventsConfig_TV_QueryAmazon.Size = new System.Drawing.Size(95, 17);
            this.eventsConfig_TV_QueryAmazon.TabIndex = 36;
            this.eventsConfig_TV_QueryAmazon.Text = "Query Amazon";
            this.eventsConfig_TV_QueryAmazon.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Status string";
            // 
            // eventsConfig_TV_StatusString
            // 
            this.eventsConfig_TV_StatusString.Location = new System.Drawing.Point(74, 32);
            this.eventsConfig_TV_StatusString.Name = "eventsConfig_TV_StatusString";
            this.eventsConfig_TV_StatusString.Size = new System.Drawing.Size(493, 20);
            this.eventsConfig_TV_StatusString.TabIndex = 32;
            // 
            // events_TV
            // 
            this.events_TV.AutoSize = true;
            this.events_TV.Location = new System.Drawing.Point(6, 15);
            this.events_TV.Name = "events_TV";
            this.events_TV.Size = new System.Drawing.Size(65, 17);
            this.events_TV.TabIndex = 22;
            this.events_TV.Text = "Enabled";
            this.events_TV.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.eventsConfig_RecordingTV_QueryAmazon);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.eventsConfig_RecordingTV_StatusString);
            this.groupBox8.Controls.Add(this.events_RecordingTV);
            this.groupBox8.Location = new System.Drawing.Point(16, 305);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(581, 61);
            this.groupBox8.TabIndex = 37;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Recording TV";
            // 
            // eventsConfig_RecordingTV_QueryAmazon
            // 
            this.eventsConfig_RecordingTV_QueryAmazon.AutoSize = true;
            this.eventsConfig_RecordingTV_QueryAmazon.Location = new System.Drawing.Point(76, 15);
            this.eventsConfig_RecordingTV_QueryAmazon.Name = "eventsConfig_RecordingTV_QueryAmazon";
            this.eventsConfig_RecordingTV_QueryAmazon.Size = new System.Drawing.Size(95, 17);
            this.eventsConfig_RecordingTV_QueryAmazon.TabIndex = 35;
            this.eventsConfig_RecordingTV_QueryAmazon.Text = "Query Amazon";
            this.eventsConfig_RecordingTV_QueryAmazon.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Status string";
            // 
            // eventsConfig_RecordingTV_StatusString
            // 
            this.eventsConfig_RecordingTV_StatusString.Location = new System.Drawing.Point(74, 32);
            this.eventsConfig_RecordingTV_StatusString.Name = "eventsConfig_RecordingTV_StatusString";
            this.eventsConfig_RecordingTV_StatusString.Size = new System.Drawing.Size(493, 20);
            this.eventsConfig_RecordingTV_StatusString.TabIndex = 32;
            // 
            // events_RecordingTV
            // 
            this.events_RecordingTV.AutoSize = true;
            this.events_RecordingTV.Location = new System.Drawing.Point(7, 15);
            this.events_RecordingTV.Name = "events_RecordingTV";
            this.events_RecordingTV.Size = new System.Drawing.Size(65, 17);
            this.events_RecordingTV.TabIndex = 26;
            this.events_RecordingTV.Text = "Enabled";
            this.events_RecordingTV.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.eventsConfig_RecordedTV_QueryAmazon);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.eventsConfig_RecordedTV_StatusString);
            this.groupBox7.Controls.Add(this.events_RecordedTV);
            this.groupBox7.Location = new System.Drawing.Point(16, 239);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(581, 61);
            this.groupBox7.TabIndex = 36;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Recorded TV";
            // 
            // eventsConfig_RecordedTV_QueryAmazon
            // 
            this.eventsConfig_RecordedTV_QueryAmazon.AutoSize = true;
            this.eventsConfig_RecordedTV_QueryAmazon.Location = new System.Drawing.Point(76, 15);
            this.eventsConfig_RecordedTV_QueryAmazon.Name = "eventsConfig_RecordedTV_QueryAmazon";
            this.eventsConfig_RecordedTV_QueryAmazon.Size = new System.Drawing.Size(95, 17);
            this.eventsConfig_RecordedTV_QueryAmazon.TabIndex = 35;
            this.eventsConfig_RecordedTV_QueryAmazon.Text = "Query Amazon";
            this.eventsConfig_RecordedTV_QueryAmazon.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Status string";
            // 
            // eventsConfig_RecordedTV_StatusString
            // 
            this.eventsConfig_RecordedTV_StatusString.Location = new System.Drawing.Point(74, 32);
            this.eventsConfig_RecordedTV_StatusString.Name = "eventsConfig_RecordedTV_StatusString";
            this.eventsConfig_RecordedTV_StatusString.Size = new System.Drawing.Size(493, 20);
            this.eventsConfig_RecordedTV_StatusString.TabIndex = 32;
            // 
            // events_RecordedTV
            // 
            this.events_RecordedTV.AutoSize = true;
            this.events_RecordedTV.Location = new System.Drawing.Point(6, 15);
            this.events_RecordedTV.Name = "events_RecordedTV";
            this.events_RecordedTV.Size = new System.Drawing.Size(65, 17);
            this.events_RecordedTV.TabIndex = 18;
            this.events_RecordedTV.Text = "Enabled";
            this.events_RecordedTV.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "currently playing media\'s title.";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.eventsConfig_Pictures_QueryAmazon);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.eventsConfig_Pictures_StatusString);
            this.groupBox6.Controls.Add(this.events_Pictures);
            this.groupBox6.Location = new System.Drawing.Point(16, 175);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(581, 61);
            this.groupBox6.TabIndex = 35;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Pictures";
            // 
            // eventsConfig_Pictures_QueryAmazon
            // 
            this.eventsConfig_Pictures_QueryAmazon.AutoSize = true;
            this.eventsConfig_Pictures_QueryAmazon.Location = new System.Drawing.Point(76, 17);
            this.eventsConfig_Pictures_QueryAmazon.Name = "eventsConfig_Pictures_QueryAmazon";
            this.eventsConfig_Pictures_QueryAmazon.Size = new System.Drawing.Size(95, 17);
            this.eventsConfig_Pictures_QueryAmazon.TabIndex = 34;
            this.eventsConfig_Pictures_QueryAmazon.Text = "Query Amazon";
            this.eventsConfig_Pictures_QueryAmazon.UseVisualStyleBackColor = true;
            this.eventsConfig_Pictures_QueryAmazon.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Status string";
            // 
            // eventsConfig_Pictures_StatusString
            // 
            this.eventsConfig_Pictures_StatusString.Location = new System.Drawing.Point(74, 35);
            this.eventsConfig_Pictures_StatusString.Name = "eventsConfig_Pictures_StatusString";
            this.eventsConfig_Pictures_StatusString.Size = new System.Drawing.Size(493, 20);
            this.eventsConfig_Pictures_StatusString.TabIndex = 32;
            // 
            // events_Pictures
            // 
            this.events_Pictures.AutoSize = true;
            this.events_Pictures.Location = new System.Drawing.Point(7, 17);
            this.events_Pictures.Name = "events_Pictures";
            this.events_Pictures.Size = new System.Drawing.Size(65, 17);
            this.events_Pictures.TabIndex = 21;
            this.events_Pictures.Text = "Enabled";
            this.events_Pictures.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.eventsConfig_Music_QueryAmazon);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.eventsConfig_Music_StatusString);
            this.groupBox5.Controls.Add(this.events_Music);
            this.groupBox5.Controls.Add(this.albumMode);
            this.groupBox5.Location = new System.Drawing.Point(15, 110);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(581, 63);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Music";
            // 
            // eventsConfig_Music_QueryAmazon
            // 
            this.eventsConfig_Music_QueryAmazon.AutoSize = true;
            this.eventsConfig_Music_QueryAmazon.Location = new System.Drawing.Point(168, 16);
            this.eventsConfig_Music_QueryAmazon.Name = "eventsConfig_Music_QueryAmazon";
            this.eventsConfig_Music_QueryAmazon.Size = new System.Drawing.Size(95, 17);
            this.eventsConfig_Music_QueryAmazon.TabIndex = 32;
            this.eventsConfig_Music_QueryAmazon.Text = "Query Amazon";
            this.eventsConfig_Music_QueryAmazon.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Status string";
            // 
            // eventsConfig_Music_StatusString
            // 
            this.eventsConfig_Music_StatusString.Location = new System.Drawing.Point(74, 36);
            this.eventsConfig_Music_StatusString.Name = "eventsConfig_Music_StatusString";
            this.eventsConfig_Music_StatusString.Size = new System.Drawing.Size(501, 20);
            this.eventsConfig_Music_StatusString.TabIndex = 32;
            // 
            // events_Music
            // 
            this.events_Music.AutoSize = true;
            this.events_Music.Location = new System.Drawing.Point(6, 16);
            this.events_Music.Name = "events_Music";
            this.events_Music.Size = new System.Drawing.Size(65, 17);
            this.events_Music.TabIndex = 20;
            this.events_Music.Text = "Enabled";
            this.events_Music.UseVisualStyleBackColor = true;
            // 
            // albumMode
            // 
            this.albumMode.AutoSize = true;
            this.albumMode.Location = new System.Drawing.Point(77, 16);
            this.albumMode.Name = "albumMode";
            this.albumMode.Size = new System.Drawing.Size(85, 17);
            this.albumMode.TabIndex = 27;
            this.albumMode.Text = "Album Mode";
            this.albumMode.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.eventsConfig_DVD_QueryAmazon);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.events_DVD);
            this.groupBox4.Controls.Add(this.eventsConfig_DVD_StatusString);
            this.groupBox4.Location = new System.Drawing.Point(15, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 63);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DVD";
            // 
            // eventsConfig_DVD_QueryAmazon
            // 
            this.eventsConfig_DVD_QueryAmazon.AutoSize = true;
            this.eventsConfig_DVD_QueryAmazon.Location = new System.Drawing.Point(77, 17);
            this.eventsConfig_DVD_QueryAmazon.Name = "eventsConfig_DVD_QueryAmazon";
            this.eventsConfig_DVD_QueryAmazon.Size = new System.Drawing.Size(95, 17);
            this.eventsConfig_DVD_QueryAmazon.TabIndex = 31;
            this.eventsConfig_DVD_QueryAmazon.Text = "Query Amazon";
            this.eventsConfig_DVD_QueryAmazon.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Status string";
            // 
            // events_DVD
            // 
            this.events_DVD.AutoSize = true;
            this.events_DVD.Location = new System.Drawing.Point(6, 17);
            this.events_DVD.Name = "events_DVD";
            this.events_DVD.Size = new System.Drawing.Size(65, 17);
            this.events_DVD.TabIndex = 19;
            this.events_DVD.Text = "Enabled";
            this.events_DVD.UseVisualStyleBackColor = true;
            // 
            // eventsConfig_DVD_StatusString
            // 
            this.eventsConfig_DVD_StatusString.Location = new System.Drawing.Point(74, 36);
            this.eventsConfig_DVD_StatusString.Name = "eventsConfig_DVD_StatusString";
            this.eventsConfig_DVD_StatusString.Size = new System.Drawing.Size(501, 20);
            this.eventsConfig_DVD_StatusString.TabIndex = 28;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(571, 13);
            this.label21.TabIndex = 24;
            this.label21.Text = "Enable or disable status updates on specific media types. Use %TITLE% in status s" +
    "tring definitions to indicate location of";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(554, 585);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 26);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(474, 585);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(392, 585);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // helpUrl
            // 
            this.helpUrl.AutoSize = true;
            this.helpUrl.Location = new System.Drawing.Point(13, 592);
            this.helpUrl.Name = "helpUrl";
            this.helpUrl.Size = new System.Drawing.Size(162, 13);
            this.helpUrl.TabIndex = 4;
            this.helpUrl.TabStop = true;
            this.helpUrl.Tag = "";
            this.helpUrl.Text = "http://www.jussipalo.com/fbmce";
            this.helpUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(641, 623);
            this.Controls.Add(this.helpUrl);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tool";
            this.Text = "Media Center Status Application Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tool_FormClosing);
            this.Load += new System.EventHandler(this.Tool_Load);
            this.tabControl.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabServices.ResumeLayout(false);
            this.i.ResumeLayout(false);
            this.i.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabExclusions.ResumeLayout(false);
            this.tabExclusions.PerformLayout();
            this.tabEvents.ResumeLayout(false);
            this.tabEvents.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabServices;
        private System.Windows.Forms.TabPage tabExclusions;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox debug;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pollingInterval;
        private System.Windows.Forms.CheckBox eventsEnabled_Service_Xml;
        private System.Windows.Forms.CheckBox eventsEnabled_Service_Facebook;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TextBox exclusions_DVD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox exclusions_TV;
        private System.Windows.Forms.TextBox exclusions_RecordedTV;
        private System.Windows.Forms.TextBox exclusions_Pictures;
        private System.Windows.Forms.TextBox exclusions_Music;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox exclusions_Video;
        private System.Windows.Forms.CheckBox events_Video;
        private System.Windows.Forms.CheckBox events_TV;
        private System.Windows.Forms.CheckBox events_Pictures;
        private System.Windows.Forms.CheckBox events_Music;
        private System.Windows.Forms.CheckBox events_DVD;
        private System.Windows.Forms.CheckBox events_RecordedTV;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowseXmlFilePath;
        private System.Windows.Forms.TextBox xmlFilePath;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnClearFacebookOfflineData;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox facebookEnabledBetweenEnd;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox facebookEnabledBetweenStart;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox xmlEnabledBetweenEnd;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox xmlEnabledBetweenStart;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnClearTwitterOfflineData;
        private System.Windows.Forms.GroupBox i;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox twitterEnabledBetweenEnd;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox twitterEnabledBetweenStart;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox eventsEnabled_Service_Twitter;
        private System.Windows.Forms.CheckBox eventsEnabled_Service_TwitterFriends;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox twitterFrequencyOfFriendStatusQueries;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox twitterFriends;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.CheckBox facebookConfirmUpdates;
        private System.Windows.Forms.CheckBox twitterConfirmUpdates;
        private System.Windows.Forms.TextBox exclusions_RecordingTV;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.CheckBox events_RecordingTV;
        private System.Windows.Forms.CheckBox albumMode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox eventsConfig_DVD_StatusString;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox eventsConfig_Pictures_StatusString;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox eventsConfig_Music_StatusString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox eventsConfig_RecordedTV_StatusString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox eventsConfig_Video_StatusString;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox eventsConfig_TV_StatusString;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox eventsConfig_RecordingTV_StatusString;
        private System.Windows.Forms.ComboBox amazonLocaleUrl;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label amazonLocaleUrl_Label;
        private System.Windows.Forms.CheckBox clearStatusOnExit;
        private System.Windows.Forms.CheckBox eventsConfig_Music_QueryAmazon;
        private System.Windows.Forms.CheckBox eventsConfig_DVD_QueryAmazon;
        private System.Windows.Forms.CheckBox eventsConfig_Pictures_QueryAmazon;
        private System.Windows.Forms.CheckBox eventsConfig_Video_QueryAmazon;
        private System.Windows.Forms.CheckBox eventsConfig_TV_QueryAmazon;
        private System.Windows.Forms.CheckBox eventsConfig_RecordingTV_QueryAmazon;
        private System.Windows.Forms.CheckBox eventsConfig_RecordedTV_QueryAmazon;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.LinkLabel helpUrl;
        private System.Windows.Forms.ListBox FacebookUpdateType;
        private System.Windows.Forms.CheckBox service_Xml_ClearStatusOnExit;
        private System.Windows.Forms.CheckBox service_Xml_ClearWhenNoMedia;
        private System.Windows.Forms.CheckBox service_Twitter_EnableSuspend;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox service_Twitter_SuspendTime;
    }
}