namespace Client
{
    partial class ClientForm
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
            this.bt_send = new System.Windows.Forms.Button();
            this.tb_msg = new System.Windows.Forms.TextBox();
            this.lb_msgs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(261, 12);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(65, 23);
            this.bt_send.TabIndex = 5;
            this.bt_send.Text = "보내기";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // tb_msg
            // 
            this.tb_msg.Location = new System.Drawing.Point(12, 12);
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.Size = new System.Drawing.Size(243, 21);
            this.tb_msg.TabIndex = 4;
            // 
            // lb_msgs
            // 
            this.lb_msgs.FormattingEnabled = true;
            this.lb_msgs.ItemHeight = 12;
            this.lb_msgs.Location = new System.Drawing.Point(12, 41);
            this.lb_msgs.Name = "lb_msgs";
            this.lb_msgs.Size = new System.Drawing.Size(313, 280);
            this.lb_msgs.TabIndex = 3;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 337);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.tb_msg);
            this.Controls.Add(this.lb_msgs);
            this.Name = "ClientForm";
            this.Text = "클라이언트";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientForm_FormClosed);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.TextBox tb_msg;
        private System.Windows.Forms.ListBox lb_msgs;
    }
}

