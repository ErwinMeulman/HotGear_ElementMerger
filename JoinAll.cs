using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HotGearAllInOne;
using System.Collections.Generic;
using System.Linq;

[Transaction()]
[Regeneration()]
public class JoinAll
{
	public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
	{
		UIApplication application = commandData.get_Application();
		Document document = application.get_ActiveUIDocument().get_Document();
		UIDocument activeUIDocument = application.get_ActiveUIDocument();
		Application application2 = commandData.get_Application().get_Application();
		List<string> list = new List<string>();
		foreach (Document document2 in application2.get_Documents())
		{
			list.Add(document2.get_Title());
		}
		GlobalVar.G_Doc_Selection = list;
		CategorySelection categorySelection = new CategorySelection();
		categorySelection.InitializeComponent(commandData);
		categorySelection.ShowDialog();
		List<Element> g_Ele = GlobalVar.G_Ele;
		List<string> g_Cat_Selection = GlobalVar.G_Cat_Selection;
		Document g_Sel_Doc = GlobalVar.G_Sel_Doc;
		if (g_Cat_Selection == null)
		{
			return 0;
		}
		List<ElementId> list2 = new List<ElementId>();
		foreach (Element item in g_Ele)
		{
			foreach (string item2 in g_Cat_Selection)
			{
				if (item.get_Category().get_Name() == item2)
				{
					list2.Add(item.get_Category().get_Id());
				}
			}
		}
		List<ElementId> cat_id = ((IEnumerable<ElementId>)list2).Distinct<ElementId>().ToList<ElementId>();
		List<Element> list3 = Method.CategoryFilter(g_Sel_Doc, cat_id);
		WP_ProcessBar wP_ProcessBar = new WP_ProcessBar(g_Sel_Doc, list3, list3.Count);
		return 0;
	}
}
