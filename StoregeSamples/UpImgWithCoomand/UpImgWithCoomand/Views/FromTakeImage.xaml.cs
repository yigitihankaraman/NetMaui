using UpImgWithCoomand.VewModels;

namespace UpImgWithCoomand.Views;

public partial class FromTakeImage : ContentPage
{
	FromTakeImageView thisBindig = new FromTakeImageView();

    public FromTakeImage()
	{
		InitializeComponent();
        BindingContext = thisBindig;
    }
}