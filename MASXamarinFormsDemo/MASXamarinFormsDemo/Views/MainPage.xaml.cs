using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MASXamarinFormsDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
        public readonly NavMenuPage NavPageInstance = new NavMenuPage();

	    public MainPage()
	    {
	        Title = "MAS Ideas Sample App";
	        InitializeComponent();
	        Master = NavPageInstance;
	        Detail = new NavigationPage(new IdeasPage());
	    }
	}
}