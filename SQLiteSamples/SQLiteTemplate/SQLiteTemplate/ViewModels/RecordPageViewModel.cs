using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteTemplate.DataItem;
using SQLiteTemplate.Models;
using SQLiteTemplate.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTemplate.ViewModels
{
    public partial class RecordPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string? varUser;

        [ObservableProperty]
        string? varEmail;

        [ObservableProperty]
        string? varPassword;

        [RelayCommand]
        async void Commititem()
        {
            
            User _user = new User { Username = VarUser, Mail = VarEmail, Password = VarPassword };

            UserDataItem dataItem = new UserDataItem();

            try
            {
                var result = await dataItem.InsertItemAsync(_user);
                await AppShell.Current.DisplayAlert("Uyarı", string.Format("Sonuç; {0}", result.ToString()), "Devam");
                EmtyVar();
            }
            catch (Exception ex)
            {
                await AppShell.Current.DisplayAlert("Uyarı", ex.Message, "Devam");
            }
            
        }

        public void EmtyVar()
        {
            VarUser = null;
            VarEmail = null;
            VarPassword = null;
        }
    }
}
