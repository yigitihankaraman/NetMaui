using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Headers;
using UpImgWithCoomand.Models;

namespace UpImgWithCoomand.VewModels
{
    public partial class FromFolderView: ObservableObject
    {
        [ObservableProperty]
        string? buttonText;

        public FromFolderView()
        {
            ButtonText = "Take a picture from folder";
        }

        [RelayCommand]
        static async void ButtonFolder()
        {
            //await Shell.Current.DisplayAlert("Uyarı", "Devam......", "Devam");

            PickOptions opt = new PickOptions
            {
                PickerTitle = "Pick Image",
                FileTypes = FilePickerFileType.Images
            };

            var fl = await MediaImage.PickAndShow(opt);
            string imageSource = fl.FullPath.ToString();
            string imagename = fl.FileName.ToString();
            FileStream _stream = File.OpenRead(imageSource);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent fileStreamContent = new StreamContent(_stream);
                fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "Image", FileName = imagename };
                fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

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
