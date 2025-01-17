using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteTemplate.DataItem;
using SQLiteTemplate.Models;
using SQLiteTemplate.Views;

namespace SQLiteTemplate.ViewModels
{
    public partial class DetailPageViewModel : ObservableObject
    {
        UserDataItem dataItem = new UserDataItem();

        [ObservableProperty]
        int varId;

        [ObservableProperty]
        string? varUser;

        [ObservableProperty]
        string? varEmail;

        [ObservableProperty]
        string? varPassword;

        public DetailPageViewModel(User myUser)
        {
            VarId = myUser.Id;
            VarUser = myUser.Username;
            VarEmail = myUser.Mail;
            VarPassword = myUser.Password;
        }

        [RelayCommand]
        async void Commititem()
        {
            User _user = new User {Id = VarId, Username = VarUser, Mail = VarEmail, Password = VarPassword };
            UserDataItem dataItem = new UserDataItem();

            try
            {
                var result = await dataItem.UpdateItemAsync(_user);
                await AppShell.Current.DisplayAlert("Uyarı", string.Format("Sonuç; {0}", result.ToString()), "Devam");
            }
            catch (Exception ex)
            {
                await AppShell.Current.DisplayAlert("Uyarı", ex.Message, "Devam");
            }
        }
    }
}
