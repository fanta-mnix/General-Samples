using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using CustomBindingSample.Droid.Controls;

namespace CustomBindingSample.Droid.Binding
{
    public class FormSpinnerItemsBinding : CustomBinding<Controls.SpinnerFormView, IEnumerable>
    {
        private class SpinnerObserver : DataSetObserver
        {
            private readonly FormSpinnerItemsBinding mBinding;

            public SpinnerObserver(FormSpinnerItemsBinding binding)
            {
                if (binding == null)
                {
                    throw new ArgumentNullException("binding");
                }
                mBinding = binding;
            }

            public override void OnChanged()
            {
                SpinnerFormView view = mBinding.View;
                if (view == null) return;
                mBinding.FireValueChanged(view.ItemsSource);
            }
        }

        private SpinnerObserver mObserver;

        public FormSpinnerItemsBinding(Controls.SpinnerFormView view)
            : base(view)
        {
        }

        protected override void SetCustomValue(IEnumerable value)
        {
            // TODO: Testar com value = null
            View.ItemsSource = value;
        }

        protected override bool SubscribeToCustomEvents()
        {
            if (View == null)
            {
                return false;
            }
            IMvxAdapter adapter = ((MvxSpinner)View.FieldView).Adapter;
            if (adapter == null)
            {
                return false;
            }
            mObserver = new SpinnerObserver(this);
            adapter.RegisterDataSetObserver(mObserver);
            return true;
        }

        protected override void UnsubscribeToCustomEvents()
        {
            ((MvxSpinner)View.FieldView).Adapter.UnregisterDataSetObserver(mObserver);
            // Fanta- Dispose observer?
            mObserver = null;
        }
    }
}