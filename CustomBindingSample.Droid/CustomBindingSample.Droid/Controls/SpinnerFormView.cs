using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace CustomBindingSample.Droid.Controls
{
    public class SpinnerFormView : CompositeFormView
    {
        public IEnumerable ItemsSource
        {
            get { return ((MvxSpinner)FieldView).ItemsSource; }
            set { ((MvxSpinner)FieldView).ItemsSource = value; }
        }

        public object SelectedItem
        {
            get { return ((MvxSpinner)FieldView).SelectedItem; }
        }

        public SpinnerFormView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
        }

        public SpinnerFormView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
        }

        protected override int LayoutId
        {
            get { return Resource.Layout.SpinnerFormView; }
        }
    }
}