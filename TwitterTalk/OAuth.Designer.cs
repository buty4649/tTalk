namespace tTalk
{
    partial class OAuth
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctl_textbox_pin = new System.Windows.Forms.TextBox();
            this.ctl_button_ok = new System.Windows.Forms.Button();
            this.ctl_button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "アクセス許可後に表示された暗証番号(PIN)を、以下に入力してください。";
            // 
            // ctl_textbox_pin
            // 
            this.ctl_textbox_pin.Location = new System.Drawing.Point(14, 47);
            this.ctl_textbox_pin.Name = "ctl_textbox_pin";
            this.ctl_textbox_pin.Size = new System.Drawing.Size(258, 19);
            this.ctl_textbox_pin.TabIndex = 1;
            // 
            // ctl_button_ok
            // 
            this.ctl_button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctl_button_ok.Location = new System.Drawing.Point(14, 72);
            this.ctl_button_ok.Name = "ctl_button_ok";
            this.ctl_button_ok.Size = new System.Drawing.Size(127, 25);
            this.ctl_button_ok.TabIndex = 2;
            this.ctl_button_ok.Text = "OK";
            this.ctl_button_ok.UseVisualStyleBackColor = true;
            // 
            // ctl_button_cancel
            // 
            this.ctl_button_cancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ctl_button_cancel.Location = new System.Drawing.Point(145, 72);
            this.ctl_button_cancel.Name = "ctl_button_cancel";
            this.ctl_button_cancel.Size = new System.Drawing.Size(127, 25);
            this.ctl_button_cancel.TabIndex = 3;
            this.ctl_button_cancel.Text = "キャンセル";
            this.ctl_button_cancel.UseVisualStyleBackColor = true;
            // 
            // OAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ctl_button_cancel;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.ctl_button_cancel);
            this.Controls.Add(this.ctl_button_ok);
            this.Controls.Add(this.ctl_textbox_pin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OAuth";
            this.Text = "暗証番号(PIN)の入力";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ctl_textbox_pin;
        private System.Windows.Forms.Button ctl_button_ok;
        private System.Windows.Forms.Button ctl_button_cancel;
    }
}