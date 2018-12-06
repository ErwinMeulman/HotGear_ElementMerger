using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace HotGearAllInOne.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					ResourceManager resourceManager = Resources.resourceMan = new ResourceManager("HotGearAllInOne.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static Bitmap Cut
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Cut", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Cut_s
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Cut_s", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap gear
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("gear", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap gear16
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("gear16", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap gear32
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("gear32", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Join
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Join", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Join_s
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Join_s", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap JoinAll
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("JoinAll", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap JoinAll_s
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("JoinAll_s", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Switch
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Switch", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Switch_s
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Switch_s", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap UnCut
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("UnCut", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap UnCut_s
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("UnCut_s", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Unjoin
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Unjoin", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Unjoin_s
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Unjoin_s", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal Resources()
		{
		}
	}
}
