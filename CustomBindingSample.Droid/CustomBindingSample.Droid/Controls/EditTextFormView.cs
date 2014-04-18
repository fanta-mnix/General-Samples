using System;
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

namespace CustomBindingSample.Droid.Controls
{
    public class EditTextFormView : CompositeFormView
    {
        public string Text
        {
            get { return ((EditText)FieldView).Text; }
            set { ((EditText)FieldView).Text = value; }
        }

        public EditTextFormView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
        }

        public EditTextFormView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
        }

        protected override int LayoutId
        {
            get { return Resource.Layout.EditTextFormView; }
        }
    }
}