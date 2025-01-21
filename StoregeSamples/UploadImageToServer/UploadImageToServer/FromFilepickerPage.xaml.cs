using System.Net.Http.Headers;

namespace UploadImageToServer;

public partial class FromFilepickerPage : ContentPage
{
	public FromFilepickerPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        PickOptions opt = new PickOptions
        {
            PickerTitle = "Pick Image",
            FileTypes = FilePickerFileType.Images
        };

        var fl = await PickAndShow(opt);
        string imageSource = fl.FullPath.ToString();
        string imagename = fl.FileName.ToString();  
        FileStream _stream = File.OpenRead(imageSource);

        HttpContent fileStreamContent = new StreamContent(_stream);
        fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "Image", FileName = imagename };
        fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent);
                var response = await client.PostAsync($"api/Fileupload", formData);
                //Console.WriteLine(fileStreamContent.Headers);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (responseContent != null)
                    {
                        Console.WriteLine(responseContent);
                    }
                }
            }
            client.Dispose();
        }
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
            await DisplayAlert("Uyarı", ex.Message, "Devam");
        }

        return null;
    }
}