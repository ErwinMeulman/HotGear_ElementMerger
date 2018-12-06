using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotGearAllInOne
{
	public class CategorySelection : Form
	{
		internal List<Element> I_Ele;

		internal List<string> I_cat_name;

		internal ICollection<ElementId> I_Eleid;

		internal Document I_Doc;

		internal ExternalCommandData cmddata;

		internal Document HGDoc;

		internal UIApplication HGUiApp;

		internal Application HGApp;

		internal UIDocument HGUiDoc;

		internal View HGActiveView;

		private int count = 0;

		private int un_check = 2;

		private IContainer components = null;

		private TreeView treeView1;

		private Button button1;

		private Button button2;

		private Button button3;

		private ToolTip toolTip1;

		private ComboBox comboBox1;

		private Label label1;

		private Label label2;

		public CategorySelection()
		{
			this.InitializeComponent();
		}

		public void InitializeComponent(ExternalCommandData cmdData)
		{
			this.cmddata = cmdData;
			this.HGUiApp = cmdData.get_Application();
			this.HGDoc = this.HGUiApp.get_ActiveUIDocument().get_Document();
			this.HGUiDoc = this.HGUiApp.get_ActiveUIDocument();
			this.HGActiveView = this.HGDoc.get_ActiveView();
			this.HGApp = cmdData.get_Application().get_Application();
		}

		private void CategorySelection_Load(object sender, EventArgs e)
		{
			this.Text = "Element Merger : Category Selection";
			List<string> g_Doc_Selection = GlobalVar.G_Doc_Selection;
			foreach (string item in g_Doc_Selection)
			{
				this.comboBox1.Items.Add(item);
			}
			this.comboBox1.SelectedIndex = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			List<string> i_cat_name = this.I_cat_name;
			List<string> list = new List<string>();
			foreach (TreeNode node in this.treeView1.Nodes)
			{
				if (node.Checked)
				{
					list.Add(i_cat_name[node.Index]);
				}
			}
			this.count = list.Count;
			GlobalVar.G_Ele = this.I_Ele;
			GlobalVar.G_Cat_Selection = list;
			GlobalVar.G_Sel_Doc = this.I_Doc;
			GlobalVar.G_Eleid = this.I_Eleid;
			base.Close();
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			if (this.count == 0)
			{
				GlobalVar.G_Cat_Selection = null;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			GlobalVar.G_Cat_Selection = null;
			base.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (this.un_check % 2 != 0)
			{
				foreach (TreeNode node in this.treeView1.Nodes)
				{
					node.Checked = false;
				}
			}
			else
			{
				foreach (TreeNode node2 in this.treeView1.Nodes)
				{
					node2.Checked = true;
				}
			}
			this.un_check++;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.treeView1.Nodes.Clear();
			int selectedIndex = this.comboBox1.SelectedIndex;
			Application application = this.cmddata.get_Application().get_Application();
			List<Document> list = new List<Document>();
			foreach (Document document in application.get_Documents())
			{
				list.Add(document);
			}
			Document val = list[selectedIndex];
			if (val.get_IsFamilyDocument())
			{
				MessageBox.Show("This Function does not support Family Document.");
			}
			else if (val.get_IsLinked())
			{
				MessageBox.Show("This Function does not support Link Document.");
			}
			else
			{
				FilteredElementCollector val2 = null;
				val2 = new FilteredElementCollector(val).WhereElementIsNotElementType();
				IList<Element> list2 = val2.ToElements();
				ICollection<ElementId> i_Eleid = val2.ToElementIds();
				List<Element> list3 = new List<Element>();
				List<string> list4 = new List<string>();
				List<int> list5 = new List<int>();
				foreach (Element item in list2)
				{
					if ((object)item.get_Category() != null)
					{
						list3.Add(item);
					}
				}
				List<string> list6 = new List<string>();
				list6.Add("Ceilings");
				list6.Add("Columns");
				list6.Add("Floors");
				list6.Add("Generic Models");
				list6.Add("Mass");
				list6.Add("Parts");
				list6.Add("Ramps");
				list6.Add("Roads");
				list6.Add("Roofs");
				list6.Add("Stairs");
				list6.Add("Structural Columns");
				list6.Add("Structural Foundations");
				list6.Add("Structural Framing");
				list6.Add("Structural Trusses");
				list6.Add("Walls");
				var enumerable = from x in (IEnumerable<Element>)list3
				group x by x.get_Category().get_Name() into g
				let count = ((IEnumerable<Element>)g).Count<Element>()
				let name = ((IEnumerable<Element>)g).First<Element>().get_Category().get_Name()
				orderby name
				select new
				{
					Name = g.Key,
					Count = count
				};
				foreach (var item2 in enumerable)
				{
					foreach (string item3 in list6)
					{
						if (item2.Name == item3)
						{
							list4.Add(item2.Name);
							list5.Add(item2.Count);
						}
					}
				}
				for (int i = 0; i < list4.Count; i++)
				{
					this.treeView1.Nodes.Add(list4[i] + "(" + list5[i] + ")");
				}
				this.I_Ele = list3;
				this.I_cat_name = list4;
				this.I_Doc = val;
				this.I_Eleid = i_Eleid;
			}
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
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CategorySelection));
			this.treeView1 = new TreeView();
			this.button1 = new Button();
			this.button2 = new Button();
			this.button3 = new Button();
			this.toolTip1 = new ToolTip(this.components);
			this.comboBox1 = new ComboBox();
			this.label1 = new Label();
			this.label2 = new Label();
			base.SuspendLayout();
			this.treeView1.CheckBoxes = true;
			this.treeView1.Location = new Point(12, 78);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new Size(339, 439);
			this.treeView1.TabIndex = 0;
			this.button1.Location = new Point(195, 523);
			this.button1.Name = "button1";
			this.button1.Size = new Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += this.button1_Click;
			this.button2.Location = new Point(276, 523);
			this.button2.Name = "button2";
			this.button2.Size = new Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += this.button2_Click;
			this.button3.Location = new Point(12, 521);
			this.button3.Name = "button3";
			this.button3.Size = new Size(118, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "Check / Uncheck All";
			this.toolTip1.SetToolTip(this.button3, "Check or Uncheck all item In the list.");
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += this.button3_Click;
			this.comboBox1.BackColor = Color.White;
			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.FlatStyle = FlatStyle.Popup;
			this.comboBox1.ForeColor = Color.Black;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new Point(12, 27);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new Size(339, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += this.comboBox1_SelectedIndexChanged;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new Size(103, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Document Selection";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(12, 56);
			this.label2.Name = "label2";
			this.label2.Size = new Size(96, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Category Selection";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(363, 556);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.comboBox1);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.treeView1);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "CategorySelection";
			this.Text = "Category Selection";
			base.Load += this.CategorySelection_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
