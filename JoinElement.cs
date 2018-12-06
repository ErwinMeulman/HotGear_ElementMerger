using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Facet.Combinatorics;
using System.Collections.Generic;
using System.Windows.Forms;

[Transaction()]
[Regeneration()]
public class JoinElement
{
	public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
	{
		UIApplication application = commandData.get_Application();
		Document document = application.get_ActiveUIDocument().get_Document();
		Selection selection = application.get_ActiveUIDocument().get_Selection();
		ICollection<ElementId> elementIds = selection.GetElementIds();
		if (elementIds.Count != 0)
		{
			List<Element> list = Method.GeometryFilter(document, elementIds);
			int num = 0;
			if (list.Count > 1)
			{
				Combinations<Element> combinations = new Combinations<Element>(list, 2, GenerateOption.WithoutRepetition);
				Transaction val = new Transaction(document);
				val.Start("Merger Element");
				FailureHandlingOptions failureHandlingOptions = val.GetFailureHandlingOptions();
				MyFailuresPreProcessor myFailuresPreProcessor = new MyFailuresPreProcessor();
				failureHandlingOptions.SetFailuresPreprocessor(myFailuresPreProcessor);
				val.SetFailureHandlingOptions(failureHandlingOptions);
				foreach (List<Element> item in combinations)
				{
					if (!JoinGeometryUtils.AreElementsJoined(document, item[0], item[1]))
					{
						try
						{
							JoinGeometryUtils.JoinGeometry(document, item[0], item[1]);
							num++;
						}
						catch
						{
						}
					}
				}
				MessageBox.Show(num.ToString() + " Pairs Elements Successfully Join.", "ElementMerger");
				val.Commit();
			}
			else if (list.Count == 1)
			{
				TaskDialog.Show("ElementMerger", "Only One Element Selected");
			}
		}
		else
		{
			TaskDialog.Show("ElementMerger", "None Element Selected");
		}
		return 0;
	}
}
