using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteTemplate.DataItem;
using SQLiteTemplate.Models;
using SQLiteTemplate.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTemplate.ViewModels
{
    public partial class ListPageViewModel : ObservableObject
    {
        UserDataItem dataItem = new UserDataItem();

        [ObservableProperty]
        ObservableCollection<User>? userList;

        [ObservableProperty]
        bool isRefresh;
        public ListPageViewModel()
        {
            Init();
        }

        [RelayCommand]
        private async void Detailuser(int myId)
        {
            await Shell.Current.Navigation.PushAsync(new DetailPage(await dataItem.GetById(myId)));
        }

        [RelayCommand]
        private void Refresh()
        {
            Init();
        } 
        public async void Init()
        {
            IsRefresh = true;
            await Task.Delay(500);
            //await Shell.Current.Navigation.PopAsync();
            UserList = new ObservableCollection<User>(await dataItem.GetItemsAsync());
            IsRefresh = false;
        }
    }
}
