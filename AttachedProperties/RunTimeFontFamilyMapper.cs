using Syncfusion.Maui.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFusionDemo.AttachedProperties
{
	public static partial class RunTimeFontFamilyMapper
	{
		public static readonly BindableProperty FontFamilyProperty =
		BindableProperty.CreateAttached("FontFamily", typeof(string), typeof(Label), null, propertyChanged: OnFontFamilyChanged);

		public static readonly BindableProperty SfComboBoxFontFamilyProperty =
		BindableProperty.CreateAttached("FontFamily", typeof(string), typeof(SfComboBox), null, propertyChanged: OnFontFamilyChanged);

		public static string GetFontFamily(SfComboBox view) => (string)view.GetValue(SfComboBoxFontFamilyProperty);

		public static void SetFontFamily(SfComboBox view, string value) => view.SetValue(SfComboBoxFontFamilyProperty, value);

		public static string GetFontFamily(Label view) => (string)view.GetValue(FontFamilyProperty);

		public static void SetFontFamily(Label view, string value) => view.SetValue(FontFamilyProperty, value);

		private static void OnFontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var view = (View)bindable;
			if (view.Handler is null || view.Handler.PlatformView is null)
			{
				// Workaround for when this executes the Handler and PlatformView is null
				view.HandlerChanged += OnHandlerChanged;
				return;
			};

			if (view is Label label)
			{
				ChangeFont(label, newValue);
			}
			else if (view is SfComboBox comboBox)
			{
				ChangeFont(comboBox, newValue);
			}

			void OnHandlerChanged(object s, EventArgs e)
			{
				OnFontFamilyChanged(view, oldValue, newValue);
				view.HandlerChanged -= OnHandlerChanged;
			}
		}
	}
}
