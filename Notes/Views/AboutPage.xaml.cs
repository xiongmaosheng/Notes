namespace Notes.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
		if (BindingContext is Models.About about)
		{
            //在系统浏览器中导航到指定的URL。
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
		}
    }
}