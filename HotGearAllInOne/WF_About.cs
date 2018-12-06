using HotGearAllInOne.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace HotGearAllInOne
{
	public class WF_About : Form
	{
		private IContainer components = null;

		private Label labelCopyright;

		private Label labelProductName;

		private Label labelVersion;

		private Label labelCompanyName;

		private PictureBox pictureBox1;

		private Label textBoxDescription;

		private Label labelFileVersion;

		private Label labelConfig;

		private TableLayoutPanel tableLayoutPanel1;

		private Label license;

		private Label label2;

		private LinkLabel linkLabel2;

		private LinkLabel linkLabel1;

		private Label label3;

		public static Assembly ExecutingAssembly
		{
			get
			{
				return Assembly.GetExecutingAssembly();
			}
		}

		public static string AssemblyTitle
		{
			get
			{
				object firstCustomAttribute = WF_About.GetFirstCustomAttribute(typeof(AssemblyTitleAttribute));
				if (firstCustomAttribute != null)
				{
					AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)firstCustomAttribute;
					if (assemblyTitleAttribute.Title != "")
					{
						return assemblyTitleAttribute.Title;
					}
				}
				return Path.GetFileNameWithoutExtension(WF_About.ExecutingAssembly.CodeBase);
			}
		}

		public static string AssemblyVersion
		{
			get
			{
				return WF_About.ExecutingAssembly.GetName().Version.ToString();
			}
		}

		public static string AssemblyDescription
		{
			get
			{
				object firstCustomAttribute = WF_About.GetFirstCustomAttribute(typeof(AssemblyDescriptionAttribute));
				return (firstCustomAttribute == null) ? string.Empty : ((AssemblyDescriptionAttribute)firstCustomAttribute).Description;
			}
		}

		public static string AssemblyProduct
		{
			get
			{
				object firstCustomAttribute = WF_About.GetFirstCustomAttribute(typeof(AssemblyProductAttribute));
				return (firstCustomAttribute == null) ? string.Empty : ((AssemblyProductAttribute)firstCustomAttribute).Product;
			}
		}

		public static string AssemblyCopyright
		{
			get
			{
				object firstCustomAttribute = WF_About.GetFirstCustomAttribute(typeof(AssemblyCopyrightAttribute));
				return (firstCustomAttribute == null) ? string.Empty : ((AssemblyCopyrightAttribute)firstCustomAttribute).Copyright;
			}
		}

		public static string AssemblyCompany
		{
			get
			{
				object firstCustomAttribute = WF_About.GetFirstCustomAttribute(typeof(AssemblyCompanyAttribute));
				return (firstCustomAttribute == null) ? string.Empty : ((AssemblyCompanyAttribute)firstCustomAttribute).Company;
			}
		}

		public static string FileVersion
		{
			get
			{
				object firstCustomAttribute = WF_About.GetFirstCustomAttribute(typeof(AssemblyFileVersionAttribute));
				return (firstCustomAttribute == null) ? string.Empty : ((AssemblyFileVersionAttribute)firstCustomAttribute).Version;
			}
		}

		public static string Config
		{
			get
			{
				object firstCustomAttribute = WF_About.GetFirstCustomAttribute(typeof(AssemblyConfigurationAttribute));
				return (firstCustomAttribute == null) ? string.Empty : ((AssemblyConfigurationAttribute)firstCustomAttribute).Configuration.ToString();
			}
		}

		public WF_About()
		{
			this.InitializeComponent();
			this.Text = "About " + WF_About.AssemblyTitle;
			this.labelProductName.Text = "Product Name : " + WF_About.AssemblyProduct;
			this.labelVersion.Text = "Revit Version : 2014 - 2019";
			this.labelFileVersion.Text = "FileVersion : " + WF_About.FileVersion;
			this.labelCopyright.Text = "Copyright : " + WF_About.AssemblyCopyright;
			this.labelConfig.Text = "Config : " + WF_About.Config;
			this.labelCompanyName.Text = "Project Name : " + WF_About.AssemblyCompany;
			this.textBoxDescription.Text = "Description : " + WF_About.AssemblyDescription;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private static object GetFirstCustomAttribute(Type t)
		{
			Assembly executingAssembly = WF_About.ExecutingAssembly;
			object[] customAttributes = executingAssembly.GetCustomAttributes(t, false);
			return (customAttributes.Length != 0) ? customAttributes[0] : null;
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("mailto:hotgearproject@gmail.com");
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://hotgearproject.wordpress.com/");
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Process.Start("https://hotgearproject.wordpress.com/donation/");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(WF_About));
			this.labelCopyright = new Label();
			this.labelProductName = new Label();
			this.labelConfig = new Label();
			this.labelFileVersion = new Label();
			this.textBoxDescription = new Label();
			this.labelCompanyName = new Label();
			this.labelVersion = new Label();
			this.license = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.linkLabel2 = new LinkLabel();
			this.linkLabel1 = new LinkLabel();
			this.pictureBox1 = new PictureBox();
			this.tableLayoutPanel1.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.labelCopyright.AutoSize = true;
			this.labelCopyright.Location = new Point(3, 150);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new Size(73, 13);
			this.labelCopyright.TabIndex = 2;
			this.labelCopyright.Text = "labelCopyright";
			this.labelProductName.AutoSize = true;
			this.labelProductName.Location = new Point(3, 30);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new Size(94, 13);
			this.labelProductName.TabIndex = 3;
			this.labelProductName.Text = "labelProductName";
			this.labelConfig.AutoSize = true;
			this.labelConfig.Location = new Point(3, 90);
			this.labelConfig.Name = "labelConfig";
			this.labelConfig.Size = new Size(59, 13);
			this.labelConfig.TabIndex = 12;
			this.labelConfig.Text = "labelConfig";
			this.labelFileVersion.AutoSize = true;
			this.labelFileVersion.Location = new Point(3, 120);
			this.labelFileVersion.Name = "labelFileVersion";
			this.labelFileVersion.Size = new Size(80, 13);
			this.labelFileVersion.TabIndex = 11;
			this.labelFileVersion.Text = "labelFileVersion";
			this.textBoxDescription.AutoSize = true;
			this.textBoxDescription.Location = new Point(3, 180);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new Size(95, 13);
			this.textBoxDescription.TabIndex = 10;
			this.textBoxDescription.Text = "textBoxDescription";
			this.labelCompanyName.AutoSize = true;
			this.labelCompanyName.Location = new Point(3, 0);
			this.labelCompanyName.Name = "labelCompanyName";
			this.labelCompanyName.Size = new Size(101, 13);
			this.labelCompanyName.TabIndex = 8;
			this.labelCompanyName.Text = "labelCompanyName";
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new Point(3, 60);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new Size(64, 13);
			this.labelVersion.TabIndex = 6;
			this.labelVersion.Text = "labelVersion";
			this.license.AutoSize = true;
			this.license.Location = new Point(3, 210);
			this.license.Name = "license";
			this.license.Size = new Size(74, 13);
			this.license.TabIndex = 13;
			this.license.Text = "License : Free";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(12, 265);
			this.label2.Name = "label2";
			this.label2.Size = new Size(81, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Support Email : ";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(12, 278);
			this.label3.Name = "label3";
			this.label3.Size = new Size(60, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Web Site : ";
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel1.Controls.Add(this.labelCompanyName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBoxDescription, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.labelFileVersion, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelConfig, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelProductName, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelVersion, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelCopyright, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.license, 0, 7);
			this.tableLayoutPanel1.Location = new Point(268, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 8;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel1.Size = new Size(314, 228);
			this.tableLayoutPanel1.TabIndex = 13;
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new Point(99, 265);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new Size(133, 13);
			this.linkLabel2.TabIndex = 20;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "hotgearproject@gmail.com";
			this.linkLabel2.LinkClicked += this.linkLabel2_LinkClicked;
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new Point(99, 278);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new Size(190, 13);
			this.linkLabel1.TabIndex = 22;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://hotgearproject.wordpress.com/";
			this.linkLabel1.LinkClicked += this.linkLabel1_LinkClicked;
			this.pictureBox1.ErrorImage = null;
			this.pictureBox1.Image = Resources.gear;
			this.pictureBox1.Location = new Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(250, 250);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(601, 302);
			base.Controls.Add(this.linkLabel1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.linkLabel2);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.tableLayoutPanel1);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "WF_About";
			this.Text = "About";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
