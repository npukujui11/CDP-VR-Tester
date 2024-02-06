namespace CDP_VR_Tester
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.Btn_Disconnect = new System.Windows.Forms.Button();
            this.Btn_Darkness = new System.Windows.Forms.Button();
            this.Btn_Seethrough = new System.Windows.Forms.Button();
            this.Btn_FreezePitch = new System.Windows.Forms.Button();
            this.Btn_SetPitch = new System.Windows.Forms.Button();
            this.tb_pitch = new System.Windows.Forms.TrackBar();
            this.tb_scene = new System.Windows.Forms.TrackBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbBattery = new System.Windows.Forms.Label();
            this.pbBattery = new System.Windows.Forms.ProgressBar();
            this.Btn_SetScene = new System.Windows.Forms.Button();
            this.Cb_bluetooth = new System.Windows.Forms.CheckBox();
            this.Btn_FindDevice = new System.Windows.Forms.Button();
            this.lb_devicelist = new System.Windows.Forms.ListBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_scene)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Connect.Location = new System.Drawing.Point(40, 282);
            this.Btn_Connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(163, 64);
            this.Btn_Connect.TabIndex = 0;
            this.Btn_Connect.Text = "Connect";
            this.Btn_Connect.UseVisualStyleBackColor = true;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // Btn_Disconnect
            // 
            this.Btn_Disconnect.Enabled = false;
            this.Btn_Disconnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Disconnect.Location = new System.Drawing.Point(265, 282);
            this.Btn_Disconnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Disconnect.Name = "Btn_Disconnect";
            this.Btn_Disconnect.Size = new System.Drawing.Size(165, 64);
            this.Btn_Disconnect.TabIndex = 1;
            this.Btn_Disconnect.Text = "Disconnect";
            this.Btn_Disconnect.UseVisualStyleBackColor = true;
            this.Btn_Disconnect.Click += new System.EventHandler(this.Btn_Disconnect_Click);
            // 
            // Btn_Darkness
            // 
            this.Btn_Darkness.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Darkness.Location = new System.Drawing.Point(40, 510);
            this.Btn_Darkness.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Darkness.Name = "Btn_Darkness";
            this.Btn_Darkness.Size = new System.Drawing.Size(163, 64);
            this.Btn_Darkness.TabIndex = 2;
            this.Btn_Darkness.Text = "Darkness";
            this.Btn_Darkness.UseVisualStyleBackColor = true;
            this.Btn_Darkness.Click += new System.EventHandler(this.Btn_Darkness_Click);
            // 
            // Btn_Seethrough
            // 
            this.Btn_Seethrough.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Seethrough.Location = new System.Drawing.Point(263, 510);
            this.Btn_Seethrough.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Seethrough.Name = "Btn_Seethrough";
            this.Btn_Seethrough.Size = new System.Drawing.Size(165, 64);
            this.Btn_Seethrough.TabIndex = 3;
            this.Btn_Seethrough.Text = "Seethrough";
            this.Btn_Seethrough.UseVisualStyleBackColor = true;
            this.Btn_Seethrough.Click += new System.EventHandler(this.Btn_Seethrough_Click);
            // 
            // Btn_FreezePitch
            // 
            this.Btn_FreezePitch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_FreezePitch.Location = new System.Drawing.Point(41, 582);
            this.Btn_FreezePitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_FreezePitch.Name = "Btn_FreezePitch";
            this.Btn_FreezePitch.Size = new System.Drawing.Size(163, 64);
            this.Btn_FreezePitch.TabIndex = 4;
            this.Btn_FreezePitch.Text = "Freeze Pitch";
            this.Btn_FreezePitch.UseVisualStyleBackColor = true;
            this.Btn_FreezePitch.Click += new System.EventHandler(this.Btn_FreezePitch_Click);
            // 
            // Btn_SetPitch
            // 
            this.Btn_SetPitch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SetPitch.Location = new System.Drawing.Point(263, 582);
            this.Btn_SetPitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_SetPitch.Name = "Btn_SetPitch";
            this.Btn_SetPitch.Size = new System.Drawing.Size(165, 64);
            this.Btn_SetPitch.TabIndex = 5;
            this.Btn_SetPitch.Text = "Set Pitch";
            this.Btn_SetPitch.UseVisualStyleBackColor = true;
            this.Btn_SetPitch.Click += new System.EventHandler(this.Btn_SetPitch_Click);
            // 
            // tb_pitch
            // 
            this.tb_pitch.Location = new System.Drawing.Point(41, 654);
            this.tb_pitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_pitch.Minimum = -10;
            this.tb_pitch.Name = "tb_pitch";
            this.tb_pitch.Size = new System.Drawing.Size(388, 45);
            this.tb_pitch.TabIndex = 6;
            // 
            // tb_scene
            // 
            this.tb_scene.Location = new System.Drawing.Point(40, 731);
            this.tb_scene.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_scene.Maximum = 3;
            this.tb_scene.Minimum = 1;
            this.tb_scene.Name = "tb_scene";
            this.tb_scene.Size = new System.Drawing.Size(388, 45);
            this.tb_scene.TabIndex = 7;
            this.tb_scene.Value = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(42, 353);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(384, 150);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(54, 87);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(43, 15);
            this.lbVersion.TabIndex = 10;
            this.lbVersion.Text = "版本号";
            // 
            // lbBattery
            // 
            this.lbBattery.AutoSize = true;
            this.lbBattery.Location = new System.Drawing.Point(54, 32);
            this.lbBattery.Name = "lbBattery";
            this.lbBattery.Size = new System.Drawing.Size(31, 15);
            this.lbBattery.TabIndex = 11;
            this.lbBattery.Text = "电量";
            // 
            // pbBattery
            // 
            this.pbBattery.Location = new System.Drawing.Point(133, 29);
            this.pbBattery.Name = "pbBattery";
            this.pbBattery.Size = new System.Drawing.Size(297, 23);
            this.pbBattery.TabIndex = 12;
            // 
            // Btn_SetScene
            // 
            this.Btn_SetScene.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.Btn_SetScene.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SetScene.Location = new System.Drawing.Point(42, 808);
            this.Btn_SetScene.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_SetScene.Name = "Btn_SetScene";
            this.Btn_SetScene.Size = new System.Drawing.Size(388, 64);
            this.Btn_SetScene.TabIndex = 13;
            this.Btn_SetScene.Text = "Set Scene";
            this.Btn_SetScene.UseVisualStyleBackColor = true;
            this.Btn_SetScene.Click += new System.EventHandler(this.Btn_SetScene_Click);
            // 
            // Cb_bluetooth
            // 
            this.Cb_bluetooth.AutoSize = true;
            this.Cb_bluetooth.Location = new System.Drawing.Point(58, 143);
            this.Cb_bluetooth.Name = "Cb_bluetooth";
            this.Cb_bluetooth.Size = new System.Drawing.Size(50, 19);
            this.Cb_bluetooth.TabIndex = 15;
            this.Cb_bluetooth.Text = "蓝牙";
            this.Cb_bluetooth.UseVisualStyleBackColor = true;
            this.Cb_bluetooth.CheckedChanged += new System.EventHandler(this.Cb_bluetooth_CheckedChanged);
            // 
            // Btn_FindDevice
            // 
            this.Btn_FindDevice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_FindDevice.Location = new System.Drawing.Point(265, 120);
            this.Btn_FindDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_FindDevice.Name = "Btn_FindDevice";
            this.Btn_FindDevice.Size = new System.Drawing.Size(163, 64);
            this.Btn_FindDevice.TabIndex = 16;
            this.Btn_FindDevice.Text = "Find Device";
            this.Btn_FindDevice.UseVisualStyleBackColor = true;
            this.Btn_FindDevice.Click += new System.EventHandler(this.Btn_FindDevice_Click);
            // 
            // lb_devicelist
            // 
            this.lb_devicelist.FormattingEnabled = true;
            this.lb_devicelist.ItemHeight = 15;
            this.lb_devicelist.Location = new System.Drawing.Point(42, 191);
            this.lb_devicelist.Name = "lb_devicelist";
            this.lb_devicelist.Size = new System.Drawing.Size(386, 79);
            this.lb_devicelist.TabIndex = 17;
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(133, 84);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(297, 21);
            this.tbVersion.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 897);
            this.Controls.Add(this.tbVersion);
            this.Controls.Add(this.lb_devicelist);
            this.Controls.Add(this.Btn_FindDevice);
            this.Controls.Add(this.Cb_bluetooth);
            this.Controls.Add(this.Btn_SetScene);
            this.Controls.Add(this.pbBattery);
            this.Controls.Add(this.lbBattery);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tb_scene);
            this.Controls.Add(this.tb_pitch);
            this.Controls.Add(this.Btn_SetPitch);
            this.Controls.Add(this.Btn_FreezePitch);
            this.Controls.Add(this.Btn_Seethrough);
            this.Controls.Add(this.Btn_Darkness);
            this.Controls.Add(this.Btn_Disconnect);
            this.Controls.Add(this.Btn_Connect);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "CDP-VR Tester app";
            ((System.ComponentModel.ISupportInitialize)(this.tb_pitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_scene)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.Button Btn_Disconnect;
        private System.Windows.Forms.Button Btn_Darkness;
        private System.Windows.Forms.Button Btn_Seethrough;
        private System.Windows.Forms.Button Btn_FreezePitch;
        private System.Windows.Forms.Button Btn_SetPitch;
        private System.Windows.Forms.TrackBar tb_pitch;
        private System.Windows.Forms.TrackBar tb_scene;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbBattery;
        private System.Windows.Forms.ProgressBar pbBattery;
        private System.Windows.Forms.Button Btn_SetScene;
        private System.Windows.Forms.CheckBox Cb_bluetooth;
        private System.Windows.Forms.Button Btn_FindDevice;
        private System.Windows.Forms.ListBox lb_devicelist;
        private System.Windows.Forms.TextBox tbVersion;
    }
}

