
using Android.App;
using Android.Widget;
using Cuckoo.Controls;
using Cuckoo.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ToastImpl))]
namespace Cuckoo.Droid
{
    public class ToastImpl : IToast
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}