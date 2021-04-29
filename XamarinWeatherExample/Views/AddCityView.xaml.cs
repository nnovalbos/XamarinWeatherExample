
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Animations.Base;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Pages;
using XamarinWeatherExample.ViewModels;

namespace XamarinWeatherExample.Views
{
    public partial class AddCityView : PopupPage
    {
        public AddCityView()
        {
            InitializeComponent();
            Animation = new MoveAnimation(MoveAnimationOptions.Bottom, MoveAnimationOptions.Top);
            (Animation as BaseAnimation).DurationIn = 1200;
        }

        protected override bool OnBackgroundClicked()
        {
            var vm = BindingContext as AddCityViewModel;

            if (!vm.IsBusy)
            {
                vm.CancelCommand.Execute(null);
            }

            return false;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var vm = BindingContext as AddCityViewModel;
            vm.Listener = null;
        }
    }
}
