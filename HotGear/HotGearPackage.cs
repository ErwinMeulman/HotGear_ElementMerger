using Autodesk.Revit.UI;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HotGear
{
	public class HotGearPackage
	{
		private static string AddInPath = typeof(HotGearPackage).Assembly.Location;

		public Result OnStartup(UIControlledApplication application)
		{
			string text = "Hot Gear";
			try
			{
				application.CreateRibbonTab(text);
			}
			catch
			{
			}
			RibbonPanel val = application.CreateRibbonPanel(text, "Element Merger");
			ContextualHelp contextualHelp = new ContextualHelp(2, "https://hotgearproject.gitbooks.io/hotgear-project/content/element_merger.html");
			SplitButtonData val2 = new SplitButtonData("HotGear", "HotGear");
			SplitButton val3 = val.AddItem(val2) as SplitButton;
			PushButton val4 = val3.AddPushButton(new PushButtonData("JoinAll", "Join All", HotGearPackage.AddInPath, "JoinAll"));
			val4.set_ToolTip("Join All Selected Category in Project.");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.JoinAll.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.JoinAll_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("JoinPush", "Join Selection", HotGearPackage.AddInPath, "JoinElement"));
			val4.set_ToolTip("Join Revit Current Selection Element.");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Join.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Join_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("UnjoinPush", "Unjoin Selection", HotGearPackage.AddInPath, "UnjoinElement"));
			val4.set_ToolTip("Unjoin Revit Current Selection Element.");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Unjoin.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Unjoin_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("SwitchPush", "Switch Join Order", HotGearPackage.AddInPath, "SwitchJoinOrder"));
			val4.set_ToolTip("Switch Join Order of Revit Current Selection Element.");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Switch.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Switch_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("CutPush", "Cut Selection", HotGearPackage.AddInPath, "CutElement"));
			val4.set_ToolTip("Cut Revit Current Selection Element.");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Cut.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Cut_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("UnCutPush", "UnCut Selection", HotGearPackage.AddInPath, "UnCutElement"));
			val4.set_ToolTip("UnCut Revit Current Selection Element.");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.UnCut.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.UnCut_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("About", "About", HotGearPackage.AddInPath, "About"));
			val4.set_ToolTip("About HotGear Project");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.gear32.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.gear16.png"));
			val4.SetContextualHelp(contextualHelp);
			return 0;
		}

		public Result OnShutdown(UIControlledApplication application)
		{
			return 0;
		}

		public static ImageSource RetriveImage(string imagePath)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imagePath);
			switch (imagePath.Substring(imagePath.Length - 3))
			{
			case "jpg":
			{
				JpegBitmapDecoder jpegBitmapDecoder = new JpegBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return jpegBitmapDecoder.Frames[0];
			}
			case "bmp":
			{
				BmpBitmapDecoder bmpBitmapDecoder = new BmpBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return bmpBitmapDecoder.Frames[0];
			}
			case "png":
			{
				PngBitmapDecoder pngBitmapDecoder = new PngBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return pngBitmapDecoder.Frames[0];
			}
			case "ico":
			{
				IconBitmapDecoder iconBitmapDecoder = new IconBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return iconBitmapDecoder.Frames[0];
			}
			default:
				return null;
			}
		}
	}
}
