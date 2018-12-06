using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace HotGearAllInOne
{
	internal class GlobalVar
	{
		public static int G_ProcessBar
		{
			get;
			set;
		}

		public static Document G_Sel_Doc
		{
			get;
			set;
		}

		public static List<Element> G_Ele
		{
			get;
			set;
		}

		public static ICollection<ElementId> G_Eleid
		{
			get;
			set;
		}

		public static List<string> G_Doc_Selection
		{
			get;
			set;
		}

		public static List<int> G_Doc_Selection_index
		{
			get;
			set;
		}

		public static List<string> G_Cat_Selection
		{
			get;
			set;
		}

		public static List<int> G_Cat_Selection_index
		{
			get;
			set;
		}
	}
}
