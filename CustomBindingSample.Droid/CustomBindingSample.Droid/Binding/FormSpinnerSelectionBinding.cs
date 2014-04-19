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
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace CustomBindingSample.Droid.Binding
{
    public class FormSpinnerSelectionBinding : CustomBinding<Controls.SpinnerFormView, object>
    {
        private object _currentValue;

        public FormSpinnerSelectionBinding(Controls.SpinnerFormView view)
            : base(view)
        {
        }

        protected override void SetCustomValue(object value)
        {
            if (value == null)
            {
                MvxBindingTrace.Warning("Null values not permitted in spinner SelectedItem binding currently");
                return;
            }

            MvxSpinner spinner = (MvxSpinner)View.FieldView;
            int index = spinner.Adapter.GetPosition(value);
            if (index < 0)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value not found for spinner {0}", value.ToString());
                return;
            }

            _currentValue = value;
            spinner.SetSelection(index);
        }

        protected override bool SubscribeToCustomEvents()
        {
            if (View == null)
            {
                return false;
            }

            MvxSpinner spinner = (MvxSpinner)View.FieldView;
            spinner.ItemSelected += HandleItemSelected;
            return true;
        }

        protected override void UnsubscribeToCustomEvents()
        {
            ((MvxSpinner)View.FieldView).ItemSelected -= HandleItemSelected;
        }

        private void HandleItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (View == null) return;
            MvxSpinner spinner = (MvxSpinner)View.FieldView;
            object newValue = spinner.Adapter.GetRawItem(e.Position);

            bool changed;
            if (newValue == null)
            {
                changed = (_currentValue != null);
            }
            else
            {
                changed = !(newValue.Equals(_currentValue));
            }

            if (!changed)
            {
                return;
            }

            _currentValue = newValue;
            FireValueChanged(newValue);
        }
    }
}