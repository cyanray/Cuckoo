using System;
using Xamarin.Forms;

namespace Cuckoo.Controls
{
    public class BetterFrame : Frame
    {
        public int BorderStroke { get; set; }

        public static readonly BindableProperty BorderStrokeProperty =
            BindableProperty.Create(
                        propertyName: "BorderStroke",
                        returnType: typeof(int),
                        declaringType: typeof(BetterFrame),
                        defaultValue: 0,
                        defaultBindingMode: BindingMode.TwoWay,
                        propertyChanged: BorderStrokePropertyChanged);

        private static void BorderStrokePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BetterFrame)bindable;
            control.BorderStroke = Convert.ToInt32(newValue);
        }

        public BetterFrame()
        {
            BorderStroke = 0;
        }

    }
}
