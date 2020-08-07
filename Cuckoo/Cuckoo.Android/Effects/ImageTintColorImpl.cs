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

[assembly: ResolutionGroupName(TintImageEffect.GroupName)]
[assembly: ExportEffect(typeof(TintImageEffectImpl), TintImageEffect.Name)]
namespace Cuckoo.Droid.Effects
{
    public class TintImageEffectImpl : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (TintImageEffect)Element.Effects.FirstOrDefault(e => e is TintImageEffect);

                if (effect == null || !(Control is ImageView image))
                    return;

                var filter = new PorterDuffColorFilter(effect.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                image.SetColorFilter(filter);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"An error occurred when setting the {typeof(TintImageEffect)} effect: {ex.Message}\n{ex.StackTrace}");
            }
        }

        protected override void OnDetached() { }
    }

}