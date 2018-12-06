using Autodesk.Revit.DB;
using Facet.Combinatorics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HotGearAllInOne
{
	public class WP_ProcessBar : Form
	{
		internal List<Element> FL;

		internal List<ElementId> FLId;

		internal int PB;

		internal Document DOC;

		internal Transaction I_trans;

		private IContainer components = null;

		private ProgressBar progressBar1;

		private Button button2;

		private BindingSource bindingSource1;

		public WP_ProcessBar(Document doc, List<Element> filtereleList, int processbar)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			this.InitializeComponent();
			this.DOC = doc;
			this.FL = filtereleList;
			this.PB = processbar;
			this.WP_ProcessBar_Load();
		}

		private void WP_ProcessBar_Load()
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			this.progressBar1.Maximum = this.PB;
			Transaction val = this.I_trans = new Transaction(this.DOC);
			val.Start("JoinAll");
			FailureHandlingOptions failureHandlingOptions = val.GetFailureHandlingOptions();
			MyFailuresPreProcessor myFailuresPreProcessor = new MyFailuresPreProcessor();
			failureHandlingOptions.SetFailuresPreprocessor(myFailuresPreProcessor);
			val.SetFailureHandlingOptions(failureHandlingOptions);
			List<ElementId> list = new List<ElementId>();
			int num = 0;
			int num2 = 0;
			foreach (Element item in this.FL)
			{
				if (!val.HasStarted())
				{
					break;
				}
				num2++;
				this.Text = "HotGear Project Join All Process : " + num2.ToString() + "/" + this.PB;
				this.progressBar1.Value = num2;
				try
				{
					GeometryElement val2 = item.get_Geometry(new Options());
					Solid val3 = null;
					using (IEnumerator<GeometryObject> enumerator2 = val2.GetEnumerator())
					{
						if (enumerator2.MoveNext())
						{
							GeometryObject current2 = enumerator2.Current;
							val3 = (current2 as Solid);
							if (val3 != null)
							{
								list.Add(item.get_Id());
							}
						}
					}
					ElementIntersectsSolidFilter val4 = new ElementIntersectsSolidFilter(val3);
					IList<Element> values = new FilteredElementCollector(this.DOC, (ICollection<ElementId>)list).WhereElementIsNotElementType().WherePasses(val4).ToElements();
					Combinations<Element> combinations = new Combinations<Element>(values, 2, GenerateOption.WithoutRepetition);
					foreach (List<Element> item2 in combinations)
					{
						if (!JoinGeometryUtils.AreElementsJoined(this.DOC, item2[0], item2[1]))
						{
							try
							{
								JoinGeometryUtils.JoinGeometry(this.DOC, item2[0], item2[1]);
								num++;
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
				base.Show();
				Application.DoEvents();
			}
			if (val.HasStarted())
			{
				this.I_trans.Commit();
				base.Close();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			this.I_trans.RollBack();
			base.Close();
			MessageBox.Show("Process is Canceled");
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(WP_ProcessBar));
			this.progressBar1 = new ProgressBar();
			this.button2 = new Button();
			this.bindingSource1 = new BindingSource(this.components);
			((ISupportInitialize)this.bindingSource1).BeginInit();
			base.SuspendLayout();
			this.progressBar1.Location = new Point(12, 12);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new Size(600, 20);
			this.progressBar1.TabIndex = 0;
			this.button2.FlatStyle = FlatStyle.Flat;
			this.button2.Location = new Point(512, 38);
			this.button2.Name = "button2";
			this.button2.Size = new Size(100, 30);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += this.button2_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(624, 77);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "WP_ProcessBar";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "WP_ProcessBar";
			((ISupportInitialize)this.bindingSource1).EndInit();
			base.ResumeLayout(false);
		}
	}
}
