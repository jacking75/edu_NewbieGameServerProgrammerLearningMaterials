namespace PacketEnDeCodeGeneratorWinForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCppSourceFileFullPath = new System.Windows.Forms.TextBox();
            this.textBoxGenerateCppFileFullPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMaxBufferSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPacketNamePrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxGenerateCppFileNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGenerateCSharpPacketFileFullPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxGenerateCSharpEnDecodeFileFullPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxGenerateCSharpEnDecodeFileNamespace = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxGenerateCSharpPacketFileNamespace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxCSPacketNamePrefix = new System.Windows.Forms.TextBox();
            this.textBoxGenerateCsToCsEnDecodeFileFullPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCSharpSourceFileFullPath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPP 패킷 구조체 정의 파일:";
            // 
            // textBoxCppSourceFileFullPath
            // 
            this.textBoxCppSourceFileFullPath.Location = new System.Drawing.Point(237, 14);
            this.textBoxCppSourceFileFullPath.Name = "textBoxCppSourceFileFullPath";
            this.textBoxCppSourceFileFullPath.Size = new System.Drawing.Size(657, 21);
            this.textBoxCppSourceFileFullPath.TabIndex = 1;
            this.textBoxCppSourceFileFullPath.Text = "D:\\My\\MyDev\\SampleProjects\\trunk\\PacketEnDeCodeGenerator\\SampleProtocol.h";
            // 
            // textBoxGenerateCppFileFullPath
            // 
            this.textBoxGenerateCppFileFullPath.Location = new System.Drawing.Point(237, 41);
            this.textBoxGenerateCppFileFullPath.Name = "textBoxGenerateCppFileFullPath";
            this.textBoxGenerateCppFileFullPath.Size = new System.Drawing.Size(657, 21);
            this.textBoxGenerateCppFileFullPath.TabIndex = 3;
            this.textBoxGenerateCppFileFullPath.Text = "D:\\My\\MyDev\\SampleProjects\\trunk\\PacketEnDeCodeGenerator\\1OutputCode\\SampleProtoc" +
    "olEnDecode.h";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "(생성할)CPP 엔/디코드 파일:";
            // 
            // textBoxMaxBufferSize
            // 
            this.textBoxMaxBufferSize.Location = new System.Drawing.Point(220, 130);
            this.textBoxMaxBufferSize.Name = "textBoxMaxBufferSize";
            this.textBoxMaxBufferSize.Size = new System.Drawing.Size(44, 21);
            this.textBoxMaxBufferSize.TabIndex = 7;
            this.textBoxMaxBufferSize.Text = "4096";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "패킷 구조체 데이터 최대 버퍼 크기:";
            // 
            // textBoxPacketNamePrefix
            // 
            this.textBoxPacketNamePrefix.Location = new System.Drawing.Point(419, 131);
            this.textBoxPacketNamePrefix.Name = "textBoxPacketNamePrefix";
            this.textBoxPacketNamePrefix.Size = new System.Drawing.Size(44, 21);
            this.textBoxPacketNamePrefix.TabIndex = 9;
            this.textBoxPacketNamePrefix.Text = "PKT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "패킷 구조체 이름 Prefix:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(871, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "생성";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxGenerateCppFileNamespace
            // 
            this.textBoxGenerateCppFileNamespace.Location = new System.Drawing.Point(132, 14);
            this.textBoxGenerateCppFileNamespace.Name = "textBoxGenerateCppFileNamespace";
            this.textBoxGenerateCppFileNamespace.Size = new System.Drawing.Size(62, 21);
            this.textBoxGenerateCppFileNamespace.TabIndex = 12;
            this.textBoxGenerateCppFileNamespace.Text = "apedg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "C++ 엔/디코드 파일:";
            // 
            // textBoxGenerateCSharpPacketFileFullPath
            // 
            this.textBoxGenerateCSharpPacketFileFullPath.Location = new System.Drawing.Point(235, 68);
            this.textBoxGenerateCSharpPacketFileFullPath.Name = "textBoxGenerateCSharpPacketFileFullPath";
            this.textBoxGenerateCSharpPacketFileFullPath.Size = new System.Drawing.Size(659, 21);
            this.textBoxGenerateCSharpPacketFileFullPath.TabIndex = 14;
            this.textBoxGenerateCSharpPacketFileFullPath.Text = "D:\\My\\MyDev\\SampleProjects\\trunk\\PacketEnDeCodeGenerator\\1OutputCode\\SampleProtoc" +
    "ol.cs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "(생성할)CSharp 패킷 구조체 정의 파일:";
            // 
            // textBoxGenerateCSharpEnDecodeFileFullPath
            // 
            this.textBoxGenerateCSharpEnDecodeFileFullPath.Location = new System.Drawing.Point(237, 95);
            this.textBoxGenerateCSharpEnDecodeFileFullPath.Name = "textBoxGenerateCSharpEnDecodeFileFullPath";
            this.textBoxGenerateCSharpEnDecodeFileFullPath.Size = new System.Drawing.Size(657, 21);
            this.textBoxGenerateCSharpEnDecodeFileFullPath.TabIndex = 16;
            this.textBoxGenerateCSharpEnDecodeFileFullPath.Text = "D:\\My\\MyDev\\SampleProjects\\trunk\\PacketEnDeCodeGenerator\\1OutputCode\\SampleProtoc" +
    "olEnDecode.cs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "(생성할)CSharp 엔/디코드 파일:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxGenerateCSharpEnDecodeFileNamespace);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxGenerateCSharpPacketFileNamespace);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxGenerateCppFileNamespace);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(24, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 41);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "namespace";
            // 
            // textBoxGenerateCSharpEnDecodeFileNamespace
            // 
            this.textBoxGenerateCSharpEnDecodeFileNamespace.Location = new System.Drawing.Point(521, 15);
            this.textBoxGenerateCSharpEnDecodeFileNamespace.Name = "textBoxGenerateCSharpEnDecodeFileNamespace";
            this.textBoxGenerateCSharpEnDecodeFileNamespace.Size = new System.Drawing.Size(62, 21);
            this.textBoxGenerateCSharpEnDecodeFileNamespace.TabIndex = 16;
            this.textBoxGenerateCSharpEnDecodeFileNamespace.Text = "apedg";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(407, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "C# 엔/디코드 파일:";
            // 
            // textBoxGenerateCSharpPacketFileNamespace
            // 
            this.textBoxGenerateCSharpPacketFileNamespace.Location = new System.Drawing.Point(319, 14);
            this.textBoxGenerateCSharpPacketFileNamespace.Name = "textBoxGenerateCSharpPacketFileNamespace";
            this.textBoxGenerateCSharpPacketFileNamespace.Size = new System.Drawing.Size(62, 21);
            this.textBoxGenerateCSharpPacketFileNamespace.TabIndex = 14;
            this.textBoxGenerateCSharpPacketFileNamespace.Text = "apedg";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "C# 프로토콜 파일:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.textBoxCppSourceFileFullPath);
            this.groupBox2.Controls.Add(this.textBoxGenerateCSharpEnDecodeFileFullPath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxGenerateCppFileFullPath);
            this.groupBox2.Controls.Add(this.textBoxGenerateCSharpPacketFileFullPath);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxMaxBufferSize);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxPacketNamePrefix);
            this.groupBox2.Location = new System.Drawing.Point(4, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(911, 259);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "C++ 코드 베이스";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.textBoxCSPacketNamePrefix);
            this.groupBox3.Controls.Add(this.textBoxGenerateCsToCsEnDecodeFileFullPath);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBoxCSharpSourceFileFullPath);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(4, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(911, 157);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "C# 코드 베이스";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(881, 32);
            this.button2.TabIndex = 23;
            this.button2.Text = "생성";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "패킷 구조체 이름 Prefix:";
            // 
            // textBoxCSPacketNamePrefix
            // 
            this.textBoxCSPacketNamePrefix.Location = new System.Drawing.Point(153, 82);
            this.textBoxCSPacketNamePrefix.Name = "textBoxCSPacketNamePrefix";
            this.textBoxCSPacketNamePrefix.Size = new System.Drawing.Size(44, 21);
            this.textBoxCSPacketNamePrefix.TabIndex = 22;
            this.textBoxCSPacketNamePrefix.Text = "PKT";
            // 
            // textBoxGenerateCsToCsEnDecodeFileFullPath
            // 
            this.textBoxGenerateCsToCsEnDecodeFileFullPath.Location = new System.Drawing.Point(197, 47);
            this.textBoxGenerateCsToCsEnDecodeFileFullPath.Name = "textBoxGenerateCsToCsEnDecodeFileFullPath";
            this.textBoxGenerateCsToCsEnDecodeFileFullPath.Size = new System.Drawing.Size(676, 21);
            this.textBoxGenerateCsToCsEnDecodeFileFullPath.TabIndex = 20;
            this.textBoxGenerateCsToCsEnDecodeFileFullPath.Text = "D:\\My\\MyDev\\SampleProjects\\trunk\\PacketEnDeCodeGenerator\\1OutputCode\\CsToCsProtoc" +
    "olEnDecode.cs";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "(생성할)CSharp 엔/디코드 파일:";
            // 
            // textBoxCSharpSourceFileFullPath
            // 
            this.textBoxCSharpSourceFileFullPath.Location = new System.Drawing.Point(195, 20);
            this.textBoxCSharpSourceFileFullPath.Name = "textBoxCSharpSourceFileFullPath";
            this.textBoxCSharpSourceFileFullPath.Size = new System.Drawing.Size(678, 21);
            this.textBoxCSharpSourceFileFullPath.TabIndex = 18;
            this.textBoxCSharpSourceFileFullPath.Text = "D:\\My\\MyDev\\SampleProjects\\trunk\\PacketEnDeCodeGenerator\\SampleProtocol.cs";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "CSharp 패킷 구조체 정의 파일:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 476);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "패킷 데이터 인/디코딩 코스 생성 툴";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCppSourceFileFullPath;
        private System.Windows.Forms.TextBox textBoxGenerateCppFileFullPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMaxBufferSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPacketNamePrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxGenerateCppFileNamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGenerateCSharpPacketFileFullPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxGenerateCSharpEnDecodeFileFullPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxGenerateCSharpEnDecodeFileNamespace;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxGenerateCSharpPacketFileNamespace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxCSPacketNamePrefix;
        private System.Windows.Forms.TextBox textBoxGenerateCsToCsEnDecodeFileFullPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxCSharpSourceFileFullPath;
        private System.Windows.Forms.Label label11;
    }
}

