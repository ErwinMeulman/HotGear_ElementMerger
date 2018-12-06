using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HotGearAllInOne;

[Transaction()]
[Regeneration()]
public class About
{
	public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
	{
		WF_About wF_About = new WF_About();
		wF_About.Show();
		return 0;
	}
}
