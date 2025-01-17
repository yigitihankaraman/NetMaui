
using SQLiteTemplate.ViewModels;

namespace SQLiteTemplate.Views;

public partial class RecordPage : ContentPage
{
    RecordPageViewModel thisBinding = new RecordPageViewModel();
    public RecordPage()
	{
		InitializeComponent();
		BindingContext = thisBinding;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        thisBinding.EmtyVar();
    }
}