using System.Net.Http.Headers;

namespace UploadImageToServer;

public partial class TakePicturePage : ContentPage
{
	public TakePicturePage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //HttpClient client = new HttpClient();

        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);
                localFileStream.Dispose();
                FileStream _stream = File.OpenRead(localFilePath);

                HttpContent fileStreamContent = new StreamContent(_stream);
                fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "Image", FileName = photo.FileName };
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
        }
    }
}