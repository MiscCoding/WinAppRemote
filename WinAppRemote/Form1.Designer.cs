namespace WinAppRemote
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtBxAppRunRemote = new System.Windows.Forms.TextBox();
            this.txtBxFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppRun = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnAppRunRemote = new System.Windows.Forms.Button();
            this.btnSnapshotRevert = new System.Windows.Forms.Button();
            this.lblIPAddr = new System.Windows.Forms.Label();
            this.txtBxIPAddr = new System.Windows.Forms.TextBox();
            this.strConvert = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxStrPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFileExists = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(75, 161);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBxAppRunRemote
            // 
            this.txtBxAppRunRemote.Location = new System.Drawing.Point(129, 92);
            this.txtBxAppRunRemote.Name = "txtBxAppRunRemote";
            this.txtBxAppRunRemote.Size = new System.Drawing.Size(100, 20);
            this.txtBxAppRunRemote.TabIndex = 1;
            // 
            // txtBxFilename
            // 
            this.txtBxFilename.Location = new System.Drawing.Point(129, 64);
            this.txtBxFilename.Name = "txtBxFilename";
            this.txtBxFilename.Size = new System.Drawing.Size(100, 20);
            this.txtBxFilename.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File Name";
            // 
            // lblAppRun
            // 
            this.lblAppRun.AutoSize = true;
            this.lblAppRun.Location = new System.Drawing.Point(72, 95);
            this.lblAppRun.Name = "lblAppRun";
            this.lblAppRun.Size = new System.Drawing.Size(44, 13);
            this.lblAppRun.TabIndex = 4;
            this.lblAppRun.Text = "App run";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(75, 201);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnAppRunRemote
            // 
            this.btnAppRunRemote.Location = new System.Drawing.Point(184, 161);
            this.btnAppRunRemote.Name = "btnAppRunRemote";
            this.btnAppRunRemote.Size = new System.Drawing.Size(100, 23);
            this.btnAppRunRemote.TabIndex = 6;
            this.btnAppRunRemote.Text = "Run app";
            this.btnAppRunRemote.UseVisualStyleBackColor = true;
            this.btnAppRunRemote.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnSnapshotRevert
            // 
            this.btnSnapshotRevert.Location = new System.Drawing.Point(184, 201);
            this.btnSnapshotRevert.Name = "btnSnapshotRevert";
            this.btnSnapshotRevert.Size = new System.Drawing.Size(100, 23);
            this.btnSnapshotRevert.TabIndex = 7;
            this.btnSnapshotRevert.Text = "Snapshot revert";
            this.btnSnapshotRevert.UseVisualStyleBackColor = true;
            this.btnSnapshotRevert.Click += new System.EventHandler(this.btnSnapshotRevert_Click);
            // 
            // lblIPAddr
            // 
            this.lblIPAddr.AutoSize = true;
            this.lblIPAddr.Location = new System.Drawing.Point(72, 121);
            this.lblIPAddr.Name = "lblIPAddr";
            this.lblIPAddr.Size = new System.Drawing.Size(52, 13);
            this.lblIPAddr.TabIndex = 9;
            this.lblIPAddr.Text = "IP ( host )";
            // 
            // txtBxIPAddr
            // 
            this.txtBxIPAddr.Location = new System.Drawing.Point(129, 118);
            this.txtBxIPAddr.Name = "txtBxIPAddr";
            this.txtBxIPAddr.Size = new System.Drawing.Size(100, 20);
            this.txtBxIPAddr.TabIndex = 8;
            // 
            // strConvert
            // 
            this.strConvert.Location = new System.Drawing.Point(75, 241);
            this.strConvert.Name = "strConvert";
            this.strConvert.Size = new System.Drawing.Size(75, 27);
            this.strConvert.TabIndex = 10;
            this.strConvert.Text = "String convert";
            this.strConvert.UseVisualStyleBackColor = true;
            this.strConvert.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Str Path";
            // 
            // txtBxStrPath
            // 
            this.txtBxStrPath.Location = new System.Drawing.Point(129, 38);
            this.txtBxStrPath.Name = "txtBxStrPath";
            this.txtBxStrPath.Size = new System.Drawing.Size(100, 20);
            this.txtBxStrPath.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "Delete remotely";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // btnFileExists
            // 
            this.btnFileExists.Location = new System.Drawing.Point(304, 161);
            this.btnFileExists.Name = "btnFileExists";
            this.btnFileExists.Size = new System.Drawing.Size(100, 23);
            this.btnFileExists.TabIndex = 14;
            this.btnFileExists.Text = "File exists";
            this.btnFileExists.UseVisualStyleBackColor = true;
            this.btnFileExists.Click += new System.EventHandler(this.btnFileExists_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 321);
            this.Controls.Add(this.btnFileExists);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxStrPath);
            this.Controls.Add(this.strConvert);
            this.Controls.Add(this.lblIPAddr);
            this.Controls.Add(this.txtBxIPAddr);
            this.Controls.Add(this.btnSnapshotRevert);
            this.Controls.Add(this.btnAppRunRemote);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblAppRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxFilename);
            this.Controls.Add(this.txtBxAppRunRemote);
            this.Controls.Add(this.btnUpload);
            this.Name = "Form1";
            this.Text = "Copy File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtBxAppRunRemote;
        private System.Windows.Forms.TextBox txtBxFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAppRun;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnAppRunRemote;
        private System.Windows.Forms.Button btnSnapshotRevert;
        private System.Windows.Forms.Label lblIPAddr;
        private System.Windows.Forms.TextBox txtBxIPAddr;
        private System.Windows.Forms.Button strConvert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxStrPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFileExists;
    }
}

