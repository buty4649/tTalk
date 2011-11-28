namespace tTalk
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctl_timer_notify = new System.Windows.Forms.Timer(this.components);
            this.ctl_opnefiledialog_softalk = new System.Windows.Forms.OpenFileDialog();
            this.ctl_button_exe = new System.Windows.Forms.Button();
            this.ctl_notifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctl_menu_notifyicon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctl_menu_show_window = new System.Windows.Forms.ToolStripMenuItem();
            this.ctl_menu_hide_window = new System.Windows.Forms.ToolStripMenuItem();
            this.ctl_menu_exec = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctl_menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ctl_statusbar_information = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctl_checkbox_replace_url = new System.Windows.Forms.CheckBox();
            this.ctl_label_replace_url = new System.Windows.Forms.Label();
            this.ctl_textbox_replace_url = new System.Windows.Forms.TextBox();
            this.ctl_checkbox_reverse = new System.Windows.Forms.CheckBox();
            this.ctl_checkbox_other = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ctl_textbox_format = new System.Windows.Forms.TextBox();
            this.ctl_button_login = new System.Windows.Forms.Button();
            this.ctl_checkbox_autologin = new System.Windows.Forms.CheckBox();
            this.ctl_tab = new System.Windows.Forms.TabControl();
            this.ctl_tabPage_config = new System.Windows.Forms.TabPage();
            this.ctl_textbox_softalk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctl_button_open = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctl_tabPage_target = new System.Windows.Forms.TabPage();
            this.ctl_label_target_listname = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ctl_list = new System.Windows.Forms.ListBox();
            this.ctl_button_list_update = new System.Windows.Forms.Button();
            this.ctl_radio_list = new System.Windows.Forms.RadioButton();
            this.ctl_radio_mentions = new System.Windows.Forms.RadioButton();
            this.ctl_radio_home_timeline = new System.Windows.Forms.RadioButton();
            this.ctl_tabPage_detail1 = new System.Windows.Forms.TabPage();
            this.ctl_updown_interval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ctl_updown_count = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ctl_tabPage_detail2 = new System.Windows.Forms.TabPage();
            this.ctl_checkbox_startup = new System.Windows.Forms.CheckBox();
            this.ctl_checkbox_run_minimize = new System.Windows.Forms.CheckBox();
            this.ctl_label_no_icon = new System.Windows.Forms.Label();
            this.ctl_checkbox_no_tasktray_icon = new System.Windows.Forms.CheckBox();
            this.ctl_checkbox_tasktray = new System.Windows.Forms.CheckBox();
            this.ctl_checkbox_softalk_minimize = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctl_label_username = new System.Windows.Forms.Label();
            this.ctl_menu_notifyicon.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.ctl_tab.SuspendLayout();
            this.ctl_tabPage_config.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ctl_tabPage_target.SuspendLayout();
            this.ctl_tabPage_detail1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctl_updown_interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctl_updown_count)).BeginInit();
            this.ctl_tabPage_detail2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctl_timer_notify
            // 
            this.ctl_timer_notify.Interval = 60000;
            this.ctl_timer_notify.Tick += new System.EventHandler(this.ctl_timer_notify_Tick);
            // 
            // ctl_opnefiledialog_softalk
            // 
            this.ctl_opnefiledialog_softalk.DefaultExt = "exe";
            this.ctl_opnefiledialog_softalk.FileName = "softalk.exe";
            this.ctl_opnefiledialog_softalk.Filter = "SofTalkの実行ファイル|softalk.exe|すべてのファイル|*.*";
            this.ctl_opnefiledialog_softalk.Title = "SofTalkのパス";
            // 
            // ctl_button_exe
            // 
            this.ctl_button_exe.Location = new System.Drawing.Point(0, 242);
            this.ctl_button_exe.Name = "ctl_button_exe";
            this.ctl_button_exe.Size = new System.Drawing.Size(282, 23);
            this.ctl_button_exe.TabIndex = 1;
            this.ctl_button_exe.Text = "実行";
            this.ctl_button_exe.UseVisualStyleBackColor = true;
            this.ctl_button_exe.Click += new System.EventHandler(this.EventExecProcess);
            // 
            // ctl_notifyicon
            // 
            this.ctl_notifyicon.ContextMenuStrip = this.ctl_menu_notifyicon;
            this.ctl_notifyicon.Text = "TwitterTalk";
            this.ctl_notifyicon.DoubleClick += new System.EventHandler(this.ctl_notifyicon_DoubleClick);
            // 
            // ctl_menu_notifyicon
            // 
            this.ctl_menu_notifyicon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctl_menu_show_window,
            this.ctl_menu_hide_window,
            this.ctl_menu_exec,
            this.toolStripMenuItem1,
            this.ctl_menu_exit});
            this.ctl_menu_notifyicon.Name = "ctl_menu_notifyicon";
            this.ctl_menu_notifyicon.Size = new System.Drawing.Size(113, 98);
            // 
            // ctl_menu_show_window
            // 
            this.ctl_menu_show_window.Name = "ctl_menu_show_window";
            this.ctl_menu_show_window.Size = new System.Drawing.Size(112, 22);
            this.ctl_menu_show_window.Text = "表示";
            this.ctl_menu_show_window.Visible = false;
            this.ctl_menu_show_window.Click += new System.EventHandler(this.RestoreWindow);
            // 
            // ctl_menu_hide_window
            // 
            this.ctl_menu_hide_window.Name = "ctl_menu_hide_window";
            this.ctl_menu_hide_window.Size = new System.Drawing.Size(112, 22);
            this.ctl_menu_hide_window.Text = "非表示";
            this.ctl_menu_hide_window.Click += new System.EventHandler(this.MinimizeWindow);
            // 
            // ctl_menu_exec
            // 
            this.ctl_menu_exec.CheckOnClick = true;
            this.ctl_menu_exec.Name = "ctl_menu_exec";
            this.ctl_menu_exec.Size = new System.Drawing.Size(112, 22);
            this.ctl_menu_exec.Text = "実行";
            this.ctl_menu_exec.Click += new System.EventHandler(this.EventExecProcess);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 6);
            // 
            // ctl_menu_exit
            // 
            this.ctl_menu_exit.Name = "ctl_menu_exit";
            this.ctl_menu_exit.Size = new System.Drawing.Size(112, 22);
            this.ctl_menu_exit.Text = "終了";
            this.ctl_menu_exit.Click += new System.EventHandler(this.ctl_menu_exit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctl_statusbar_information});
            this.statusStrip1.Location = new System.Drawing.Point(0, 277);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(282, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ctl_statusbar_information
            // 
            this.ctl_statusbar_information.Name = "ctl_statusbar_information";
            this.ctl_statusbar_information.Size = new System.Drawing.Size(0, 17);
            // 
            // ctl_checkbox_replace_url
            // 
            this.ctl_checkbox_replace_url.AutoSize = true;
            this.ctl_checkbox_replace_url.Checked = true;
            this.ctl_checkbox_replace_url.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctl_checkbox_replace_url.Location = new System.Drawing.Point(17, 57);
            this.ctl_checkbox_replace_url.Name = "ctl_checkbox_replace_url";
            this.ctl_checkbox_replace_url.Size = new System.Drawing.Size(98, 16);
            this.ctl_checkbox_replace_url.TabIndex = 2;
            this.ctl_checkbox_replace_url.Tag = "つぶやき内のURLを置換します";
            this.ctl_checkbox_replace_url.Text = "URLを置換する";
            this.ctl_checkbox_replace_url.UseVisualStyleBackColor = true;
            this.ctl_checkbox_replace_url.CheckedChanged += new System.EventHandler(this.ctl_checkbox_replace_url_CheckedChanged);
            // 
            // ctl_label_replace_url
            // 
            this.ctl_label_replace_url.AutoSize = true;
            this.ctl_label_replace_url.Location = new System.Drawing.Point(38, 76);
            this.ctl_label_replace_url.Name = "ctl_label_replace_url";
            this.ctl_label_replace_url.Size = new System.Drawing.Size(87, 12);
            this.ctl_label_replace_url.TabIndex = 9;
            this.ctl_label_replace_url.Tag = "置換する文字列を設定します";
            this.ctl_label_replace_url.Text = "置換後の文字列";
            // 
            // ctl_textbox_replace_url
            // 
            this.ctl_textbox_replace_url.Location = new System.Drawing.Point(131, 73);
            this.ctl_textbox_replace_url.Name = "ctl_textbox_replace_url";
            this.ctl_textbox_replace_url.Size = new System.Drawing.Size(133, 19);
            this.ctl_textbox_replace_url.TabIndex = 3;
            this.ctl_textbox_replace_url.Tag = "置換する文字列を設定します";
            this.ctl_textbox_replace_url.Text = "URL";
            // 
            // ctl_checkbox_reverse
            // 
            this.ctl_checkbox_reverse.AutoSize = true;
            this.ctl_checkbox_reverse.Checked = true;
            this.ctl_checkbox_reverse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctl_checkbox_reverse.Location = new System.Drawing.Point(17, 98);
            this.ctl_checkbox_reverse.Name = "ctl_checkbox_reverse";
            this.ctl_checkbox_reverse.Size = new System.Drawing.Size(199, 28);
            this.ctl_checkbox_reverse.TabIndex = 4;
            this.ctl_checkbox_reverse.Tag = "読み上げる順序を反転させます";
            this.ctl_checkbox_reverse.Text = "読み上げ順を反転する\r\nオン: 過去→現在、オフ：現在→過去";
            this.ctl_checkbox_reverse.UseVisualStyleBackColor = true;
            // 
            // ctl_checkbox_other
            // 
            this.ctl_checkbox_other.AutoSize = true;
            this.ctl_checkbox_other.Checked = true;
            this.ctl_checkbox_other.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctl_checkbox_other.Location = new System.Drawing.Point(17, 36);
            this.ctl_checkbox_other.Name = "ctl_checkbox_other";
            this.ctl_checkbox_other.Size = new System.Drawing.Size(109, 16);
            this.ctl_checkbox_other.TabIndex = 1;
            this.ctl_checkbox_other.Tag = "自分の発言を除いて読み上げます";
            this.ctl_checkbox_other.Text = "自分の発言を除く";
            this.ctl_checkbox_other.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 12);
            this.label6.TabIndex = 15;
            this.label6.Tag = "読み上げるフォーマットを指定します";
            this.label6.Text = "読み上げフォーマット";
            // 
            // ctl_textbox_format
            // 
            this.ctl_textbox_format.Location = new System.Drawing.Point(121, 11);
            this.ctl_textbox_format.Name = "ctl_textbox_format";
            this.ctl_textbox_format.Size = new System.Drawing.Size(143, 19);
            this.ctl_textbox_format.TabIndex = 0;
            this.ctl_textbox_format.Tag = "読み上げるフォーマットを指定します";
            this.ctl_textbox_format.Text = "%T %s %t";
            // 
            // ctl_button_login
            // 
            this.ctl_button_login.Location = new System.Drawing.Point(6, 18);
            this.ctl_button_login.Name = "ctl_button_login";
            this.ctl_button_login.Size = new System.Drawing.Size(241, 23);
            this.ctl_button_login.TabIndex = 4;
            this.ctl_button_login.Tag = "Twitterへログインします";
            this.ctl_button_login.Text = "ログイン";
            this.ctl_button_login.UseVisualStyleBackColor = true;
            this.ctl_button_login.Click += new System.EventHandler(this.ctl_btn_login_Click);
            // 
            // ctl_checkbox_autologin
            // 
            this.ctl_checkbox_autologin.AutoSize = true;
            this.ctl_checkbox_autologin.Checked = true;
            this.ctl_checkbox_autologin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctl_checkbox_autologin.Location = new System.Drawing.Point(23, 47);
            this.ctl_checkbox_autologin.Name = "ctl_checkbox_autologin";
            this.ctl_checkbox_autologin.Size = new System.Drawing.Size(148, 16);
            this.ctl_checkbox_autologin.TabIndex = 3;
            this.ctl_checkbox_autologin.Tag = "TwitterTalkを起動した時に自動ログインします";
            this.ctl_checkbox_autologin.Text = "起動時に自動ログインする";
            this.ctl_checkbox_autologin.UseVisualStyleBackColor = true;
            // 
            // ctl_tab
            // 
            this.ctl_tab.Controls.Add(this.ctl_tabPage_config);
            this.ctl_tab.Controls.Add(this.ctl_tabPage_target);
            this.ctl_tab.Controls.Add(this.ctl_tabPage_detail1);
            this.ctl_tab.Controls.Add(this.ctl_tabPage_detail2);
            this.ctl_tab.Location = new System.Drawing.Point(0, 1);
            this.ctl_tab.Name = "ctl_tab";
            this.ctl_tab.SelectedIndex = 0;
            this.ctl_tab.Size = new System.Drawing.Size(282, 236);
            this.ctl_tab.TabIndex = 0;
            // 
            // ctl_tabPage_config
            // 
            this.ctl_tabPage_config.Controls.Add(this.ctl_textbox_softalk);
            this.ctl_tabPage_config.Controls.Add(this.label3);
            this.ctl_tabPage_config.Controls.Add(this.ctl_button_open);
            this.ctl_tabPage_config.Controls.Add(this.groupBox1);
            this.ctl_tabPage_config.Location = new System.Drawing.Point(4, 22);
            this.ctl_tabPage_config.Name = "ctl_tabPage_config";
            this.ctl_tabPage_config.Padding = new System.Windows.Forms.Padding(3);
            this.ctl_tabPage_config.Size = new System.Drawing.Size(274, 210);
            this.ctl_tabPage_config.TabIndex = 0;
            this.ctl_tabPage_config.Text = "基本設定";
            this.ctl_tabPage_config.UseVisualStyleBackColor = true;
            // 
            // ctl_textbox_softalk
            // 
            this.ctl_textbox_softalk.Location = new System.Drawing.Point(8, 170);
            this.ctl_textbox_softalk.Name = "ctl_textbox_softalk";
            this.ctl_textbox_softalk.Size = new System.Drawing.Size(202, 19);
            this.ctl_textbox_softalk.TabIndex = 1;
            this.ctl_textbox_softalk.Tag = "SofTalkへのパスを指定します";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 12);
            this.label3.TabIndex = 23;
            this.label3.Tag = "SofTalkへのパスを指定します";
            this.label3.Text = "SofTalkのパス";
            // 
            // ctl_button_open
            // 
            this.ctl_button_open.Location = new System.Drawing.Point(216, 166);
            this.ctl_button_open.Name = "ctl_button_open";
            this.ctl_button_open.Size = new System.Drawing.Size(52, 23);
            this.ctl_button_open.TabIndex = 2;
            this.ctl_button_open.Tag = "SofTalkへのパスを指定します";
            this.ctl_button_open.Text = "参照";
            this.ctl_button_open.UseVisualStyleBackColor = true;
            this.ctl_button_open.Click += new System.EventHandler(this.ctl_button_open_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctl_label_username);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ctl_button_login);
            this.groupBox1.Controls.Add(this.ctl_checkbox_autologin);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Twitter";
            // 
            // ctl_tabPage_target
            // 
            this.ctl_tabPage_target.Controls.Add(this.ctl_label_target_listname);
            this.ctl_tabPage_target.Controls.Add(this.label8);
            this.ctl_tabPage_target.Controls.Add(this.ctl_list);
            this.ctl_tabPage_target.Controls.Add(this.ctl_button_list_update);
            this.ctl_tabPage_target.Controls.Add(this.ctl_radio_list);
            this.ctl_tabPage_target.Controls.Add(this.ctl_radio_mentions);
            this.ctl_tabPage_target.Controls.Add(this.ctl_radio_home_timeline);
            this.ctl_tabPage_target.Location = new System.Drawing.Point(4, 22);
            this.ctl_tabPage_target.Name = "ctl_tabPage_target";
            this.ctl_tabPage_target.Size = new System.Drawing.Size(274, 210);
            this.ctl_tabPage_target.TabIndex = 2;
            this.ctl_tabPage_target.Text = "読み上げ対象";
            this.ctl_tabPage_target.UseVisualStyleBackColor = true;
            // 
            // ctl_label_target_listname
            // 
            this.ctl_label_target_listname.Location = new System.Drawing.Point(119, 66);
            this.ctl_label_target_listname.Name = "ctl_label_target_listname";
            this.ctl_label_target_listname.Size = new System.Drawing.Size(147, 12);
            this.ctl_label_target_listname.TabIndex = 6;
            this.ctl_label_target_listname.Tag = "現在選択されているリストです";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 12);
            this.label8.TabIndex = 5;
            this.label8.Tag = "現在選択されているリストです";
            this.label8.Text = "選択されたリスト：";
            // 
            // ctl_list
            // 
            this.ctl_list.FormattingEnabled = true;
            this.ctl_list.ItemHeight = 12;
            this.ctl_list.Location = new System.Drawing.Point(8, 110);
            this.ctl_list.Name = "ctl_list";
            this.ctl_list.ScrollAlwaysVisible = true;
            this.ctl_list.Size = new System.Drawing.Size(258, 88);
            this.ctl_list.TabIndex = 4;
            this.ctl_list.Tag = "読み上げるリストを選択します";
            this.ctl_list.SelectedIndexChanged += new System.EventHandler(this.ctl_list_SelectedIndexChanged);
            // 
            // ctl_button_list_update
            // 
            this.ctl_button_list_update.Location = new System.Drawing.Point(8, 81);
            this.ctl_button_list_update.Name = "ctl_button_list_update";
            this.ctl_button_list_update.Size = new System.Drawing.Size(258, 23);
            this.ctl_button_list_update.TabIndex = 3;
            this.ctl_button_list_update.Tag = "リスト一覧を更新します";
            this.ctl_button_list_update.Text = "リストを取得";
            this.ctl_button_list_update.UseVisualStyleBackColor = true;
            this.ctl_button_list_update.Click += new System.EventHandler(this.ctl_button_list_update_Click);
            // 
            // ctl_radio_list
            // 
            this.ctl_radio_list.AutoSize = true;
            this.ctl_radio_list.Location = new System.Drawing.Point(8, 47);
            this.ctl_radio_list.Name = "ctl_radio_list";
            this.ctl_radio_list.Size = new System.Drawing.Size(47, 16);
            this.ctl_radio_list.TabIndex = 2;
            this.ctl_radio_list.Tag = "リスト を読み上げます";
            this.ctl_radio_list.Text = "リスト";
            this.ctl_radio_list.UseVisualStyleBackColor = true;
            // 
            // ctl_radio_mentions
            // 
            this.ctl_radio_mentions.AutoSize = true;
            this.ctl_radio_mentions.Location = new System.Drawing.Point(8, 25);
            this.ctl_radio_mentions.Name = "ctl_radio_mentions";
            this.ctl_radio_mentions.Size = new System.Drawing.Size(105, 16);
            this.ctl_radio_mentions.TabIndex = 1;
            this.ctl_radio_mentions.Tag = "返信 (mentions) を読み上げます";
            this.ctl_radio_mentions.Text = "返信 (mentions)";
            this.ctl_radio_mentions.UseVisualStyleBackColor = true;
            // 
            // ctl_radio_home_timeline
            // 
            this.ctl_radio_home_timeline.AutoSize = true;
            this.ctl_radio_home_timeline.Checked = true;
            this.ctl_radio_home_timeline.Location = new System.Drawing.Point(8, 3);
            this.ctl_radio_home_timeline.Name = "ctl_radio_home_timeline";
            this.ctl_radio_home_timeline.Size = new System.Drawing.Size(159, 16);
            this.ctl_radio_home_timeline.TabIndex = 0;
            this.ctl_radio_home_timeline.TabStop = true;
            this.ctl_radio_home_timeline.Tag = "タイムライン (home_timeline) を読み上げます";
            this.ctl_radio_home_timeline.Text = "タイムライン (home_timeline)";
            this.ctl_radio_home_timeline.UseVisualStyleBackColor = true;
            // 
            // ctl_tabPage_detail1
            // 
            this.ctl_tabPage_detail1.Controls.Add(this.ctl_updown_interval);
            this.ctl_tabPage_detail1.Controls.Add(this.label5);
            this.ctl_tabPage_detail1.Controls.Add(this.ctl_updown_count);
            this.ctl_tabPage_detail1.Controls.Add(this.label4);
            this.ctl_tabPage_detail1.Controls.Add(this.ctl_textbox_replace_url);
            this.ctl_tabPage_detail1.Controls.Add(this.ctl_textbox_format);
            this.ctl_tabPage_detail1.Controls.Add(this.ctl_label_replace_url);
            this.ctl_tabPage_detail1.Controls.Add(this.label6);
            this.ctl_tabPage_detail1.Controls.Add(this.ctl_checkbox_replace_url);
            this.ctl_tabPage_detail1.Controls.Add(this.ctl_checkbox_other);
            this.ctl_tabPage_detail1.Controls.Add(this.ctl_checkbox_reverse);
            this.ctl_tabPage_detail1.Location = new System.Drawing.Point(4, 22);
            this.ctl_tabPage_detail1.Name = "ctl_tabPage_detail1";
            this.ctl_tabPage_detail1.Padding = new System.Windows.Forms.Padding(3);
            this.ctl_tabPage_detail1.Size = new System.Drawing.Size(274, 210);
            this.ctl_tabPage_detail1.TabIndex = 1;
            this.ctl_tabPage_detail1.Text = "詳細設定1";
            this.ctl_tabPage_detail1.UseVisualStyleBackColor = true;
            // 
            // ctl_updown_interval
            // 
            this.ctl_updown_interval.Location = new System.Drawing.Point(121, 156);
            this.ctl_updown_interval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.ctl_updown_interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ctl_updown_interval.Name = "ctl_updown_interval";
            this.ctl_updown_interval.Size = new System.Drawing.Size(46, 19);
            this.ctl_updown_interval.TabIndex = 7;
            this.ctl_updown_interval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctl_updown_interval.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 12);
            this.label5.TabIndex = 20;
            this.label5.Tag = "自動取得する間隔を指定します";
            this.label5.Text = "自動取得間隔(分)";
            // 
            // ctl_updown_count
            // 
            this.ctl_updown_count.Location = new System.Drawing.Point(121, 134);
            this.ctl_updown_count.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ctl_updown_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ctl_updown_count.Name = "ctl_updown_count";
            this.ctl_updown_count.Size = new System.Drawing.Size(46, 19);
            this.ctl_updown_count.TabIndex = 6;
            this.ctl_updown_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctl_updown_count.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 12);
            this.label4.TabIndex = 17;
            this.label4.Tag = "一度に取得するつぶやきの数を指定します";
            this.label4.Text = "一度に取得する数";
            // 
            // ctl_tabPage_detail2
            // 
            this.ctl_tabPage_detail2.Controls.Add(this.ctl_checkbox_startup);
            this.ctl_tabPage_detail2.Controls.Add(this.ctl_checkbox_run_minimize);
            this.ctl_tabPage_detail2.Controls.Add(this.ctl_label_no_icon);
            this.ctl_tabPage_detail2.Controls.Add(this.ctl_checkbox_no_tasktray_icon);
            this.ctl_tabPage_detail2.Controls.Add(this.ctl_checkbox_tasktray);
            this.ctl_tabPage_detail2.Controls.Add(this.ctl_checkbox_softalk_minimize);
            this.ctl_tabPage_detail2.Location = new System.Drawing.Point(4, 22);
            this.ctl_tabPage_detail2.Name = "ctl_tabPage_detail2";
            this.ctl_tabPage_detail2.Size = new System.Drawing.Size(274, 210);
            this.ctl_tabPage_detail2.TabIndex = 3;
            this.ctl_tabPage_detail2.Text = "詳細設定2";
            this.ctl_tabPage_detail2.UseVisualStyleBackColor = true;
            // 
            // ctl_checkbox_startup
            // 
            this.ctl_checkbox_startup.AutoSize = true;
            this.ctl_checkbox_startup.Location = new System.Drawing.Point(15, 14);
            this.ctl_checkbox_startup.Name = "ctl_checkbox_startup";
            this.ctl_checkbox_startup.Size = new System.Drawing.Size(136, 16);
            this.ctl_checkbox_startup.TabIndex = 5;
            this.ctl_checkbox_startup.Tag = "起動した時に自動で実行します";
            this.ctl_checkbox_startup.Text = "起動時に自動実行する";
            this.ctl_checkbox_startup.UseVisualStyleBackColor = true;
            // 
            // ctl_checkbox_run_minimize
            // 
            this.ctl_checkbox_run_minimize.AutoSize = true;
            this.ctl_checkbox_run_minimize.Checked = true;
            this.ctl_checkbox_run_minimize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctl_checkbox_run_minimize.Location = new System.Drawing.Point(15, 36);
            this.ctl_checkbox_run_minimize.Name = "ctl_checkbox_run_minimize";
            this.ctl_checkbox_run_minimize.Size = new System.Drawing.Size(124, 16);
            this.ctl_checkbox_run_minimize.TabIndex = 4;
            this.ctl_checkbox_run_minimize.Tag = "実行した時にウインドウを最小化します";
            this.ctl_checkbox_run_minimize.Text = "実行時に最小化する";
            this.ctl_checkbox_run_minimize.UseVisualStyleBackColor = true;
            // 
            // ctl_label_no_icon
            // 
            this.ctl_label_no_icon.AutoSize = true;
            this.ctl_label_no_icon.Location = new System.Drawing.Point(30, 132);
            this.ctl_label_no_icon.Name = "ctl_label_no_icon";
            this.ctl_label_no_icon.Size = new System.Drawing.Size(159, 24);
            this.ctl_label_no_icon.TabIndex = 3;
            this.ctl_label_no_icon.Text = "※ このオプションを有効にすると、\r\n　　多重起動できなくなります。";
            // 
            // ctl_checkbox_no_tasktray_icon
            // 
            this.ctl_checkbox_no_tasktray_icon.AutoSize = true;
            this.ctl_checkbox_no_tasktray_icon.Location = new System.Drawing.Point(32, 101);
            this.ctl_checkbox_no_tasktray_icon.Name = "ctl_checkbox_no_tasktray_icon";
            this.ctl_checkbox_no_tasktray_icon.Size = new System.Drawing.Size(172, 28);
            this.ctl_checkbox_no_tasktray_icon.TabIndex = 2;
            this.ctl_checkbox_no_tasktray_icon.Tag = "タスクトレイアイコンを表示しません";
            this.ctl_checkbox_no_tasktray_icon.Text = "タスクトレイアイコンを表示しない\r\n(再起動後から有効)";
            this.ctl_checkbox_no_tasktray_icon.UseVisualStyleBackColor = true;
            // 
            // ctl_checkbox_tasktray
            // 
            this.ctl_checkbox_tasktray.AutoSize = true;
            this.ctl_checkbox_tasktray.Checked = true;
            this.ctl_checkbox_tasktray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctl_checkbox_tasktray.Location = new System.Drawing.Point(15, 79);
            this.ctl_checkbox_tasktray.Name = "ctl_checkbox_tasktray";
            this.ctl_checkbox_tasktray.Size = new System.Drawing.Size(166, 16);
            this.ctl_checkbox_tasktray.TabIndex = 1;
            this.ctl_checkbox_tasktray.Tag = "最小化時にタスクトレイにしまいます";
            this.ctl_checkbox_tasktray.Text = "最小化時にタスクトレイにしまう";
            this.ctl_checkbox_tasktray.UseVisualStyleBackColor = true;
            this.ctl_checkbox_tasktray.CheckedChanged += new System.EventHandler(this.ctl_checkbox_tasktray_CheckedChanged);
            // 
            // ctl_checkbox_softalk_minimize
            // 
            this.ctl_checkbox_softalk_minimize.AutoSize = true;
            this.ctl_checkbox_softalk_minimize.Checked = true;
            this.ctl_checkbox_softalk_minimize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctl_checkbox_softalk_minimize.Location = new System.Drawing.Point(15, 58);
            this.ctl_checkbox_softalk_minimize.Name = "ctl_checkbox_softalk_minimize";
            this.ctl_checkbox_softalk_minimize.Size = new System.Drawing.Size(188, 16);
            this.ctl_checkbox_softalk_minimize.TabIndex = 0;
            this.ctl_checkbox_softalk_minimize.Tag = "SofTalkを最小化した状態で起動します";
            this.ctl_checkbox_softalk_minimize.Text = "SoftTalkを最小化した状態で起動";
            this.ctl_checkbox_softalk_minimize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "現在のユーザ";
            // 
            // ctl_label_username
            // 
            this.ctl_label_username.Location = new System.Drawing.Point(81, 66);
            this.ctl_label_username.Name = "ctl_label_username";
            this.ctl_label_username.Size = new System.Drawing.Size(166, 12);
            this.ctl_label_username.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 299);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ctl_tab);
            this.Controls.Add(this.ctl_button_exe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "tTalk";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.ctl_menu_notifyicon.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctl_tab.ResumeLayout(false);
            this.ctl_tabPage_config.ResumeLayout(false);
            this.ctl_tabPage_config.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ctl_tabPage_target.ResumeLayout(false);
            this.ctl_tabPage_target.PerformLayout();
            this.ctl_tabPage_detail1.ResumeLayout(false);
            this.ctl_tabPage_detail1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctl_updown_interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctl_updown_count)).EndInit();
            this.ctl_tabPage_detail2.ResumeLayout(false);
            this.ctl_tabPage_detail2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer ctl_timer_notify;
        private System.Windows.Forms.OpenFileDialog ctl_opnefiledialog_softalk;
        private System.Windows.Forms.Button ctl_button_exe;
        private System.Windows.Forms.NotifyIcon ctl_notifyicon;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ctl_statusbar_information;
        private System.Windows.Forms.ContextMenuStrip ctl_menu_notifyicon;
        private System.Windows.Forms.ToolStripMenuItem ctl_menu_show_window;
        private System.Windows.Forms.ToolStripMenuItem ctl_menu_hide_window;
        private System.Windows.Forms.ToolStripMenuItem ctl_menu_exec;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ctl_menu_exit;
        private System.Windows.Forms.CheckBox ctl_checkbox_replace_url;
        private System.Windows.Forms.Label ctl_label_replace_url;
        private System.Windows.Forms.TextBox ctl_textbox_replace_url;
        private System.Windows.Forms.CheckBox ctl_checkbox_reverse;
        private System.Windows.Forms.CheckBox ctl_checkbox_other;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ctl_textbox_format;
        private System.Windows.Forms.Button ctl_button_login;
        private System.Windows.Forms.CheckBox ctl_checkbox_autologin;
        private System.Windows.Forms.TabControl ctl_tab;
        private System.Windows.Forms.TabPage ctl_tabPage_config;
        private System.Windows.Forms.TabPage ctl_tabPage_detail1;
        private System.Windows.Forms.TextBox ctl_textbox_softalk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ctl_button_open;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage ctl_tabPage_target;
        private System.Windows.Forms.RadioButton ctl_radio_mentions;
        private System.Windows.Forms.RadioButton ctl_radio_home_timeline;
        private System.Windows.Forms.ListBox ctl_list;
        private System.Windows.Forms.Button ctl_button_list_update;
        private System.Windows.Forms.RadioButton ctl_radio_list;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ctl_updown_count;
        private System.Windows.Forms.NumericUpDown ctl_updown_interval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ctl_label_target_listname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage ctl_tabPage_detail2;
        private System.Windows.Forms.Label ctl_label_no_icon;
        private System.Windows.Forms.CheckBox ctl_checkbox_no_tasktray_icon;
        private System.Windows.Forms.CheckBox ctl_checkbox_tasktray;
        private System.Windows.Forms.CheckBox ctl_checkbox_softalk_minimize;
        private System.Windows.Forms.CheckBox ctl_checkbox_startup;
        private System.Windows.Forms.CheckBox ctl_checkbox_run_minimize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ctl_label_username;
    }
}

