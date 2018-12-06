using Autodesk.Revit.DB;
using System.Collections.Generic;

public class Method
{
	private const double _inch_to_mm = 25.4;

	private const double _foot_to_mm = 304.79999999999995;

	public static string RealString(double a)
	{
		return a.ToString("0.##");
	}

	public static string PointStringMm(XYZ p)
	{
		return string.Format("{0},{1},{2}", Method.RealString(p.get_X() * 304.79999999999995), Method.RealString(p.get_Y() * 304.79999999999995), Method.RealString(p.get_Z() * 304.79999999999995));
	}

	public static List<Element> GeometryFilter(Document doc, ICollection<ElementId> id)
	{
		List<ElementCategoryFilter> list = new List<ElementCategoryFilter>();
		list.Add(new ElementCategoryFilter(-2000011));
		list.Add(new ElementCategoryFilter(-2000032));
		list.Add(new ElementCategoryFilter(-2000100));
		list.Add(new ElementCategoryFilter(-2000180));
		list.Add(new ElementCategoryFilter(-2000038));
		list.Add(new ElementCategoryFilter(-2001330));
		list.Add(new ElementCategoryFilter(-2001300));
		list.Add(new ElementCategoryFilter(-2000151));
		list.Add(new ElementCategoryFilter(-2000120));
		list.Add(new ElementCategoryFilter(-2001220));
		list.Add(new ElementCategoryFilter(-2001320));
		list.Add(new ElementCategoryFilter(-2000035));
		list.Add(new ElementCategoryFilter(-2003400));
		list.Add(new ElementCategoryFilter(-2000269));
		list.Add(new ElementCategoryFilter(-2001336));
		List<Element> list2 = new List<Element>();
		foreach (ElementCategoryFilter item in list)
		{
			FilteredElementCollector val = new FilteredElementCollector(doc, id);
			foreach (Element item2 in val.WherePasses(item).WhereElementIsNotElementType().ToElements())
			{
				list2.Add(item2);
			}
		}
		return list2;
	}

	public static List<Element> CategoryFilter(Document doc, List<ElementId> Cat_id)
	{
		List<ElementCategoryFilter> list = new List<ElementCategoryFilter>();
		foreach (ElementId item in Cat_id)
		{
			list.Add(new ElementCategoryFilter(item));
		}
		List<Element> list2 = new List<Element>();
		foreach (ElementCategoryFilter item2 in list)
		{
			FilteredElementCollector val = new FilteredElementCollector(doc);
			foreach (Element item3 in val.WherePasses(item2).WhereElementIsNotElementType().ToElements())
			{
				list2.Add(item3);
			}
		}
		return list2;
	}

	public static List<ElementId> CategoryFilter_ID(Document doc, List<ElementId> Cat_id)
	{
		List<ElementCategoryFilter> list = new List<ElementCategoryFilter>();
		foreach (ElementId item in Cat_id)
		{
			list.Add(new ElementCategoryFilter(item));
		}
		List<ElementId> list2 = new List<ElementId>();
		foreach (ElementCategoryFilter item2 in list)
		{
			FilteredElementCollector val = new FilteredElementCollector(doc);
			foreach (Element item3 in val.WherePasses(item2).WhereElementIsNotElementType().ToElements())
			{
				list2.Add(item3.get_Id());
			}
		}
		return list2;
	}
}
