using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomBindingSample.Droid.Controls;

namespace CustomBindingSample.Droid.Binding
{
    public class CompoundViewBinding : CustomBinding<CompoundView, string>
    {
        public CompoundViewBinding(CompoundView source)
            : base(source) { }

        protected override void SetCustomValue(string value)
        {
            Source.Label = value ?? string.Empty;
        }

        protected override bool SubscribeToCustomEvents()
        {
            Source.LabelTextChanged += HandleTextChange;
            return true;
        }

        private void HandleTextChange(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (Source == null) return;
            FireValueChanged(Source.Label);
        }

        protected override void UnsubscribeToCustomEvents()
        {
            Source.LabelTextChanged -= HandleTextChange;
        }
    }
}