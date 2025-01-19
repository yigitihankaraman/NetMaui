namespace RemarkPage;

public partial class MainPage : ContentPage
{
    bool btn = false;

    public MainPage()
	{
		InitializeComponent();
        imageAction.ScaleTo(1.05);
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        if (btn)
        {
            await DetailPage.TranslateTo(0, 0, 600, Easing.BounceOut);
            await RemarkPage.TranslateTo(-300, 40, 300, Easing.CubicInOut);
            await HeaderPage.TranslateTo(-200, 0, 200);
            await imageAction.ScaleTo(1.05, 100);
            btn = false;
            DetailPage.IsVisible = false;
        }
        else
        {
            await imageAction.ScaleTo(1, 100);
            await HeaderPage.TranslateTo(0, 0, 200);
            await RemarkPage.TranslateTo(0, 40, 300, Easing.CubicInOut);
            DetailPage.IsVisible = true;
            await DetailPage.TranslateTo(0, -40, 600, Easing.BounceOut);
            btn = true;
        }


    }

    private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
    {
        DisplayAlert("Uyarı", "Deneme Amaçlı Uyarı", "Devam");
    }
}

