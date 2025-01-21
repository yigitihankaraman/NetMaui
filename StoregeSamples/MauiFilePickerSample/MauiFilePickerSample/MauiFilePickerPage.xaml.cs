namespace MauiFilePickerSample;

public partial class MauiFilePickerPage : ContentPage
{
	public MauiFilePickerPage()
	{
		InitializeComponent();
	}

    private async void ImageSelect_Clicked(object sender, EventArgs e)
    {
        /*
        var images = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Image",
            FileTypes = FilePickerFileType.Images
        });

        var imageSource = images.FullPath.ToString();
        barcodeImage.Source = imageSource;
        outputText.Text = imageSource;
        */
        //var customFileType = new FilePickerFileType(
        //        new Dictionary<DevicePlatform, IEnumerable<string>>
        //        {
        //            { DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
        //            { DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
        //            { DevicePlatform.WinUI, new[] { ".cbr", ".cbz" } }, // file extension
        //            { DevicePlatform.Tizen, new[] { "*/*" } },
        //            { DevicePlatform.macOS, new[] { "cbr", "cbz" } }, // UTType values
        //        });

        //PickOptions options = new()
        //{
        //    PickerTitle = "Please select a comic file",
        //    FileTypes = customFileType,
        //};
        
        PickOptions opt = new PickOptions
        {
            PickerTitle = "Pick Image",
            FileTypes = FilePickerFileType.Images
        };

        var fl = await PickAndShow(opt);
        var imageSource2 = fl.FullPath.ToString();
        barcodeImage.Source = imageSource2;
        outputText.Text = imageSource2;
    }

    private async Task<FileResult?> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }
}