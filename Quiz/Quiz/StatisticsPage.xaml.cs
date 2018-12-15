using Xamarin.Forms;

namespace Quiz
{
    public partial class StatisticsPage : ContentPage
    {
        public StatisticsPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }
    }
}
