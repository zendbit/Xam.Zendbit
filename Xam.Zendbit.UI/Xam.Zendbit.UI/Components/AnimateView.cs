using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public class AnimateView
    {
        public static AnimateView Self { get; } = new AnimateView();

        public async Task TouchEffect(View view)
        {
            await view?.ScaleTo(0.8, 50);
            await view?.ScaleTo(1, 100);
        }
    }
}
