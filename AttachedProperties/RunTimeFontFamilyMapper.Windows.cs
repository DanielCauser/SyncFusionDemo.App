using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using PlatformLabelView = Microsoft.UI.Xaml.Controls.TextBlock;
//using PlatformComboBoxView = Syncfusion.UI.Xaml.Editors.SfComboBox;
using Syncfusion.Maui.Inputs;

namespace SyncFusionDemo.AttachedProperties
{
	public static partial class RunTimeFontFamilyMapper
	{
		private static void ChangeFont(Label control, object fontAlias)
		{
			var fontinfo = fontAlias.ToString().Split(';');
			var fontFamily = new FontFamily($"ms-appdata:///Local/{fontinfo[0]}#{fontinfo[1]}");
			var nativeView = (PlatformLabelView)control.Handler.PlatformView;
			nativeView.FontFamily = fontFamily;
		}

		private static void ChangeFont(SfComboBox control, object fontAlias)
		{
			var fontinfo = fontAlias.ToString().Split(';');
			var fontFamily = new FontFamily($"ms-appdata:///Local/{fontinfo[1]}#{fontinfo[0]}");
			//I want to convert the SFCombobox parameter into the native winUI component, with access to the native
			//FontFamily property.
			var nativeView = control.Handler.PlatformView;
			//nativeView.FontFamily = fontFamily;
		}
	}
}