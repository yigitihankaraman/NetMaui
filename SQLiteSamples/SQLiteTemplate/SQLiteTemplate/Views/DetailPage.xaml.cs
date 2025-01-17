using SQLiteTemplate.Models;
using SQLiteTemplate.ViewModels;

namespace SQLiteTemplate.Views;

public partial class DetailPage : ContentPage
{
    
    public DetailPage(User varUser)
	{
        InitializeComponent();
        //txtId.Text = textId;
        DetailPageViewModel thisBinding = new DetailPageViewModel(varUser);
        BindingContext = thisBinding;
    }
}