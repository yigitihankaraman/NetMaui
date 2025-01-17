using SQLiteTemplate.ViewModels;

namespace SQLiteTemplate.Views;

public partial class ListPage : ContentPage
{
    //User myUser = new User { Id = 111, Username = "Yigit", Mail = "Karaman", Password = "111222333" };
    //User myUser = new User();// { Id = 111, Username = "Yigit", Mail = "Karaman", Password = "111222333" };
    ListPageViewModel thisBinding = new ListPageViewModel();
    public ListPage()
    {
        InitializeComponent();
        BindingContext = thisBinding;
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        thisBinding.Init();
    }
    
}