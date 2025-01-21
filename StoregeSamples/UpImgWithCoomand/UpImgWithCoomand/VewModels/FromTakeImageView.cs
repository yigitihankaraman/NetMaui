using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UpImgWithCoomand.Models;

namespace UpImgWithCoomand.VewModels
{
    public partial class FromTakeImageView : ObservableObject
    {
        [ObservableProperty]
        string? buttonText;

        public FromTakeImageView()
        {
            ButtonText = "Take a image from camera";
        }

        [RelayCommand]
        static async void ButtonImage()
        {
            string? str = await MediaImage.ImageSave();
            if (str != null) 
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, str);
                FileStream _stream = File.OpenRead(localFilePath);

                    HttpContent fileStreamContent = new StreamContent(_stream);
                    fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "Image", FileName = str };
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
