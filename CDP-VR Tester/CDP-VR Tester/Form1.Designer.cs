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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnDarkness = new System.Windows.Forms.Button();
            this.btnSeethrough = new System.Windows.Forms.Button();
            this.btnFreezePitch = new System.Windows.Forms.Button();
            this.btnSetPitch = new System.Windows.Forms.Button();
            this.tb_pitch = new System.Windows.Forms.TrackBar();
            this.tb_scene = new System.Windows.Forms.TrackBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbBattery = new System.Windows.Forms.Label();
            this.pbBattery = new System.Windows.Forms.ProgressBar();
            this.btnSetScene = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_scene)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(42, 133);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(163, 64);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(266, 133);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(165, 64);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnDarkness
            // 
            this.btnDarkness.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDarkness.Location = new System.Drawing.Point(42, 327);
            this.btnDarkness.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDarkness.Name = "btnDarkness";
            this.btnDarkness.Size = new System.Drawing.Size(163, 64);
            this.btnDarkness.TabIndex = 2;
            this.btnDarkness.Text = "Darkness";
            this.btnDarkness.UseVisualStyleBackColor = true;
            // 
            // btnSeethrough
            // 
            this.btnSeethrough.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeethrough.Location = new System.Drawing.Point(266, 327);
            this.btnSeethrough.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSeethrough.Name = "btnSeethrough";
            this.btnSeethrough.Size = new System.Drawing.Size(165, 64);
            this.btnSeethrough.TabIndex = 3;
            this.btnSeethrough.Text = "Seethrough";
            this.btnSeethrough.UseVisualStyleBackColor = true;
            // 
            // btnFreezePitch
            // 
            this.btnFreezePitch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreezePitch.Location = new System.Drawing.Point(42, 428);
            this.btnFreezePitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFreezePitch.Name = "btnFreezePitch";
            this.btnFreezePitch.Size = new System.Drawing.Size(163, 64);
            this.btnFreezePitch.TabIndex = 4;
            this.btnFreezePitch.Text = "Freeze Pitch";
            this.btnFreezePitch.UseVisualStyleBackColor = true;
            this.btnFreezePitch.Click += new System.EventHandler(this.btnFreezePitch_Click);
            // 
            // btnSetPitch
            // 
            this.btnSetPitch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPitch.Location = new System.Drawing.Point(266, 428);
            this.btnSetPitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetPitch.Name = "btnSetPitch";
            this.btnSetPitch.Size = new System.Drawing.Size(165, 64);
            this.btnSetPitch.TabIndex = 5;
            this.btnSetPitch.Text = "Set Pitch";
            this.btnSetPitch.UseVisualStyleBackColor = true;
            this.btnSetPitch.Click += new System.EventHandler(this.btnSetPitch_Click);
            // 
            // tb_pitch
            // 
            this.tb_pitch.Location = new System.Drawing.Point(42, 548);
            this.tb_pitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_pitch.Minimum = -10;
            this.tb_pitch.Name = "tb_pitch";
            this.tb_pitch.Size = new System.Drawing.Size(388, 69);
            this.tb_pitch.TabIndex = 6;
            // 
            // tb_scene
            // 
            this.tb_scene.Location = new System.Drawing.Point(42, 632);
            this.tb_scene.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_scene.Maximum = 3;
            this.tb_scene.Minimum = 1;
            this.tb_scene.Name = "tb_scene";
            this.tb_scene.Size = new System.Drawing.Size(388, 69);
            this.tb_scene.TabIndex = 7;
            this.tb_scene.Value = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(42, 231);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(389, 72);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(54, 92);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(63, 20);
            this.lbVersion.TabIndex = 10;
            this.lbVersion.Text = "版本号";
            // 
            // lbBattery
            // 
            this.lbBattery.AutoSize = true;
            this.lbBattery.Location = new System.Drawing.Point(54, 32);
            this.lbBattery.Name = "lbBattery";
            this.lbBattery.Size = new System.Drawing.Size(45, 20);
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
            // btnSetScene
            // 
            this.btnSetScene.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.btnSetScene.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetScene.Location = new System.Drawing.Point(42, 709);
            this.btnSetScene.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetScene.Name = "btnSetScene";
            this.btnSetScene.Size = new System.Drawing.Size(388, 64);
            this.btnSetScene.TabIndex = 13;
            this.btnSetScene.Text = "Set Scene";
            this.btnSetScene.UseVisualStyleBackColor = true;
            this.btnSetScene.Click += new System.EventHandler(this.btnSetScene_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 803);
            this.Controls.Add(this.btnSetScene);
            this.Controls.Add(this.pbBattery);
            this.Controls.Add(this.lbBattery);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tb_scene);
            this.Controls.Add(this.tb_pitch);
            this.Controls.Add(this.btnSetPitch);
            this.Controls.Add(this.btnFreezePitch);
            this.Controls.Add(this.btnSeethrough);
            this.Controls.Add(this.btnDarkness);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "CDP-VR Tester app";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_pitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_scene)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnDarkness;
        private System.Windows.Forms.Button btnSeethrough;
        private System.Windows.Forms.Button btnFreezePitch;
        private System.Windows.Forms.Button btnSetPitch;
        private System.Windows.Forms.TrackBar tb_pitch;
        private System.Windows.Forms.TrackBar tb_scene;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbBattery;
        private System.Windows.Forms.ProgressBar pbBattery;
        private System.Windows.Forms.Button btnSetScene;
    }
}

