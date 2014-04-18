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

namespace CustomBindingSample.Droid.Binding
{
    public class FormLabelBinding : CustomBinding<Controls.CompositeFormView, string>
    {
        public FormLabelBinding(Controls.CompositeFormView view) : base(view)
        {
        }

        protected override void SetCustomValue(string value)
        {
            View.Label = value ?? string.Empty;
        }

        protected override bool SubscribeToCustomEvents()
        {
            View.LabelView.TextChanged += HandleTextChanged;
            return true;
        }

        protected override void UnsubscribeToCustomEvents()
        {
            View.LabelView.TextChanged -= HandleTextChanged;
        }

        private void HandleTextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (View == null) return;
            FireValueChanged(View.Label);
        }
    }
}