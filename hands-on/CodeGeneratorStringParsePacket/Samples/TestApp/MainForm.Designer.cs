namespace PacketEnDeCodeGeneratorForm
{
    partial class MainForm
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
            this.textBoxCppProtocolFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxPacketStructInfo = new System.Windows.Forms.ListBox();
            this.listBoxPacketEnDecoder = new System.Windows.Forms.ListBox();
            this.listBoxCSharpPacketData = new System.Windows.Forms.ListBox();
            this.listBoxCSharpPacketEnDecoder = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxCSharpPacketProtocol = new System.Windows.Forms.ListBox();
            this.textBoxCSharpProtocolFile = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBoxCSharpPacketEnDecode = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCppProtocolFile
            // 
            this.textBoxCppProtocolFile.Location = new System.Drawing.Point(6, 6);
            this.textBoxCppProtocolFile.Name = "textBoxCppProtocolFile";
            this.textBoxCppProtocolFile.Size = new System.Drawing.Size(592, 21);
            this.textBoxCppProtocolFile.TabIndex = 0;
            this.textBoxCppProtocolFile.Text = "D:\\My\\MyDev\\SampleProjects\\trunk\\PacketEnDeCodeGenerator\\CppUnitTest\\SampleProtoc" +
    "ol.h";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "생성";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxPacketStructInfo
            // 
            this.listBoxPacketStructInfo.FormattingEnabled = true;
            this.listBoxPacketStructInfo.HorizontalScrollbar = true;
            this.listBoxPacketStructInfo.ItemHeight = 12;
            this.listBoxPacketStructInfo.Location = new System.Drawing.Point(6, 31);
            this.listBoxPacketStructInfo.Name = "listBoxPacketStructInfo";
            this.listBoxPacketStructInfo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxPacketStructInfo.Size = new System.Drawing.Size(660, 160);
            this.listBoxPacketStructInfo.TabIndex = 2;
            // 
            // listBoxPacketEnDecoder
            // 
            this.listBoxPacketEnDecoder.FormattingEnabled = true;
            this.listBoxPacketEnDecoder.HorizontalScrollbar = true;
            this.listBoxPacketEnDecoder.ItemHeight = 12;
            this.listBoxPacketEnDecoder.Location = new System.Drawing.Point(6, 208);
            this.listBoxPacketEnDecoder.Name = "listBoxPacketEnDecoder";
            this.listBoxPacketEnDecoder.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxPacketEnDecoder.Size = new System.Drawing.Size(660, 160);
            this.listBoxPacketEnDecoder.TabIndex = 3;
            // 
            // listBoxCSharpPacketData
            // 
            this.listBoxCSharpPacketData.FormattingEnabled = true;
            this.listBoxCSharpPacketData.HorizontalScrollbar = true;
            this.listBoxCSharpPacketData.ItemHeight = 12;
            this.listBoxCSharpPacketData.Location = new System.Drawing.Point(6, 374);
            this.listBoxCSharpPacketData.Name = "listBoxCSharpPacketData";
            this.listBoxCSharpPacketData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCSharpPacketData.Size = new System.Drawing.Size(660, 184);
            this.listBoxCSharpPacketData.TabIndex = 4;
            // 
            // listBoxCSharpPacketEnDecoder
            // 
            this.listBoxCSharpPacketEnDecoder.FormattingEnabled = true;
            this.listBoxCSharpPacketEnDecoder.HorizontalScrollbar = true;
            this.listBoxCSharpPacketEnDecoder.ItemHeight = 12;
            this.listBoxCSharpPacketEnDecoder.Location = new System.Drawing.Point(6, 564);
            this.listBoxCSharpPacketEnDecoder.Name = "listBoxCSharpPacketEnDecoder";
            this.listBoxCSharpPacketEnDecoder.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCSharpPacketEnDecoder.Size = new System.Drawing.Size(660, 220);
            this.listBoxCSharpPacketEnDecoder.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(683, 817);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxPacketStructInfo);
            this.tabPage1.Controls.Add(this.listBoxCSharpPacketEnDecoder);
            this.tabPage1.Controls.Add(this.textBoxCppProtocolFile);
            this.tabPage1.Controls.Add(this.listBoxCSharpPacketData);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.listBoxPacketEnDecoder);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(675, 791);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "C++";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxCSharpPacketProtocol);
            this.tabPage2.Controls.Add(this.textBoxCSharpProtocolFile);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.listBoxCSharpPacketEnDecode);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(675, 791);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "C#";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxCSharpPacketProtocol
            // 
            this.listBoxCSharpPacketProtocol.FormattingEnabled = true;
            this.listBoxCSharpPacketProtocol.HorizontalScrollbar = true;
            this.listBoxCSharpPacketProtocol.ItemHeight = 12;
            this.listBoxCSharpPacketProtocol.Location = new System.Drawing.Point(7, 33);
            this.listBoxCSharpPacketProtocol.Name = "listBoxCSharpPacketProtocol";
            this.listBoxCSharpPacketProtocol.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCSharpPacketProtocol.Size = new System.Drawing.Size(660, 160);
            this.listBoxCSharpPacketProtocol.TabIndex = 6;
            // 
            // textBoxCSharpProtocolFile
            // 
            this.textBoxCSharpProtocolFile.Location = new System.Drawing.Point(7, 8);
            this.textBoxCSharpProtocolFile.Name = "textBoxCSharpProtocolFile";
            this.textBoxCSharpProtocolFile.Size = new System.Drawing.Size(592, 21);
            this.textBoxCSharpProtocolFile.TabIndex = 4;
            this.textBoxCSharpProtocolFile.Text = "D:\\My\\MyDev\\SampleProjects\\trunk\\PacketEnDeCodeGenerator\\SampleProtocol.cs";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(605, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 20);
            this.button2.TabIndex = 5;
            this.button2.Text = "생성";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBoxCSharpPacketEnDecode
            // 
            this.listBoxCSharpPacketEnDecode.FormattingEnabled = true;
            this.listBoxCSharpPacketEnDecode.HorizontalScrollbar = true;
            this.listBoxCSharpPacketEnDecode.ItemHeight = 12;
            this.listBoxCSharpPacketEnDecode.Location = new System.Drawing.Point(7, 210);
            this.listBoxCSharpPacketEnDecode.Name = "listBoxCSharpPacketEnDecode";
            this.listBoxCSharpPacketEnDecode.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCSharpPacketEnDecode.Size = new System.Drawing.Size(660, 208);
            this.listBoxCSharpPacketEnDecode.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 836);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "테스트";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCppProtocolFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxPacketStructInfo;
        private System.Windows.Forms.ListBox listBoxPacketEnDecoder;
        private System.Windows.Forms.ListBox listBoxCSharpPacketData;
        private System.Windows.Forms.ListBox listBoxCSharpPacketEnDecoder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxCSharpPacketProtocol;
        private System.Windows.Forms.TextBox textBoxCSharpProtocolFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBoxCSharpPacketEnDecode;
    }
}

