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
    public class FormTextBinding : CustomBinding<Controls.EditTextFormView, string>
    {
        public FormTextBinding(Controls.EditTextFormView view)
            : base(view)
        {
        }

        protected override void SetCustomValue(string value)
        {
            View.Text = value ?? string.Empty;
        }

        protected override bool SubscribeToCustomEvents()
        {
            ((EditText)View.FieldView).TextChanged += HandleTextChanged;
            return true;
        }

        protected override void UnsubscribeToCustomEvents()
        {
            ((EditText)View.FieldView).TextChanged -= HandleTextChanged;
        }

        private void HandleTextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (View == null) return;
            FireValueChanged(View.Text);
        }
    }
}