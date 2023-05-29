using ReactiveUI.Fody.Helpers;
using SixLabors.Fonts;
using SyncFusionDemo.AttachedProperties;

namespace SyncFusionDemo;

public partial class MainPage : ContentPage
{
	static string FontInfo;

	public MainPage()
	{
		InitializeComponent();


		comboBox.ItemsSource = new string[] { "One", "Two" };
	}

	private async void FontPickerFont_Clicked(object sender, EventArgs e)
	{
		var file = await FilePicker.PickAsync();

		if (file == null) { return; }

		var stream = await file.OpenReadAsync();

		FontCollection collection = new FontCollection();
		collection.Install(stream);

		using var fileStream = File.Create($"{FileSystem.AppDataDirectory}/{file.FileName}");
		stream.Seek(0, SeekOrigin.Begin);
		stream.CopyTo(fileStream);
		stream.Seek(0, SeekOrigin.Begin);

		stream.Close();
		fileStream.Close();

		FontInfo = $"{file.FileName};{collection.Families.First().Name}";
		FontPickedSpan.Text = FontInfo;
	}
	private void OnLabelSetFontClicked(object sender, EventArgs e)
	{
		RunTimeFontFamilyMapper.SetFontFamily(Label, FontInfo);
	}
	private void OnComboBoxSetFontCLicked(object sender, EventArgs e)
	{
		RunTimeFontFamilyMapper.SetFontFamily(comboBox, FontInfo);
	}
}

