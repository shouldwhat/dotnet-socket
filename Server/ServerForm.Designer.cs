namespace About_Sock
{
    partial class ServerForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_msgs = new System.Windows.Forms.ListBox();
            this.tb_msg = new System.Windows.Forms.TextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.서버ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.서버개설ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_msgs
            // 
            this.lb_msgs.FormattingEnabled = true;
            this.lb_msgs.ItemHeight = 12;
            this.lb_msgs.Location = new System.Drawing.Point(12, 27);
            this.lb_msgs.Name = "lb_msgs";
            this.lb_msgs.Size = new System.Drawing.Size(313, 280);
            this.lb_msgs.TabIndex = 0;
            // 
            // tb_msg
            // 
            this.tb_msg.Location = new System.Drawing.Point(11, 315);
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.Size = new System.Drawing.Size(243, 21);
            this.tb_msg.TabIndex = 1;
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(260, 315);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(65, 23);
            this.bt_send.TabIndex = 2;
            this.bt_send.Text = "보내기";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.서버ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(338, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 서버ToolStripMenuItem
            // 
            this.서버ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.서버개설ToolStripMenuItem});
            this.서버ToolStripMenuItem.Name = "서버ToolStripMenuItem";
            this.서버ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.서버ToolStripMenuItem.Text = "서버";
            // 
            // 서버개설ToolStripMenuItem
            // 
            this.서버개설ToolStripMenuItem.Name = "서버개설ToolStripMenuItem";
            this.서버개설ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.서버개설ToolStripMenuItem.Text = "서버개설";
            this.서버개설ToolStripMenuItem.Click += new System.EventHandler(this.서버개설ToolStripMenuItem_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 349);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.tb_msg);
            this.Controls.Add(this.lb_msgs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerForm";
            this.Text = "서버";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_msgs;
        private System.Windows.Forms.TextBox tb_msg;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 서버ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 서버개설ToolStripMenuItem;
    }
}

