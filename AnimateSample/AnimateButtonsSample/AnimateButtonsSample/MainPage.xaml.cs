namespace AnimateButtonsSample
{
    public partial class MainPage : ContentPage
    {
        bool colorTF = true;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void translateButton_Clicked(object sender, EventArgs e)
        {

            await translateButton.TranslateTo(0, -5, 10);
            await translateButton.TranslateTo(0, 0);
            await translateButton.TranslateTo(0, 5, 10);
            await translateButton.TranslateTo(0, 0);

            try
            {
                scaleButton.AbortAnimation("ScaleTo");
                await fadeButton.FadeTo(1, 1000, Easing.SinInOut);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private async void scaleButton_Clicked(object sender, EventArgs e)
        {
            //await scaleButton.ScaleTo(3, 1000);
            scaleButton.Text = "";
            await scaleButton.ScaleTo(0.30, 30);
            await scaleButton.ScaleTo(1, 30);
            scaleButton.Text = "Scale Me";
        }

        private async void rotateButton_Clicked(object sender, EventArgs e)
        {
            await rotateButton.RotateTo(180);
            await rotateButton.RotateTo(0, 500, Easing.SpringOut);
        }

        private async void fadeButton_Clicked(object sender, EventArgs e)
        {
            await fadeButton.FadeTo(0, 1000, Easing.SinInOut);
        }

        private async void submitDark_Clicked(object sender, EventArgs e)
        {
            //submitBlue.IsVisible = true;
            //submitDark.IsVisible = false;
            if (colorTF)
            {
                colorTF = false;
                await submitDark.TranslateTo(0, 45);
                await submitDark.FadeTo(0, 0);
                submitDark.BackgroundColor = Color.FromRgb(255, 0, 0);
                await submitDark.TranslateTo(0, 0);
                await submitDark.FadeTo(1, 500);
            }
            else
            {
                colorTF = true;
                await submitDark.TranslateTo(0, -45);
                await submitDark.FadeTo(0, 0);
                submitDark.BackgroundColor = Color.FromRgb(0, 0, 0);
                await submitDark.TranslateTo(0, 0);
                await submitDark.FadeTo(1, 500);
            }
        }
    }

}
