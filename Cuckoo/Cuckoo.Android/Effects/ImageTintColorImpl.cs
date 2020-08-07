using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cuckoo.Droid.Effects;
using Cuckoo.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(TintImageImpl), nameof(TintImage))]
namespace Cuckoo.Droid.Effects
{
    public class TintImageImpl : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (TintImage)Element.Effects.FirstOrDefault(e => e is TintImage);

                if (effect == null || !(Control is ImageView image))
                    return;

                var filter = new PorterDuffColorFilter(effect.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                image.SetColorFilter(filter);
            }
            catch
            {

            }
        }

        protected override void OnDetached() { }
    }

}