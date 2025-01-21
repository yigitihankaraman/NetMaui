using UpImgWithCoomand.VewModels;

namespace UpImgWithCoomand.Views;

public partial class FromFolder : ContentPage
{
	FromFolderView thisBindig = new FromFolderView();
    public FromFolder()
	{
		InitializeComponent();
        BindingContext = thisBindig;

    }
}