using HTTPClient.ViewModels;

namespace HTTPClient.Views;

public partial class CreatePostView : ContentPage
{
	public CreatePostView()
	{
		InitializeComponent();
		BindingContext = new CreatePostViewModel();
    }
}