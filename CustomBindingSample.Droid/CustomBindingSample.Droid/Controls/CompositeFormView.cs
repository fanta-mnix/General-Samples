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
    public abstract class CompositeFormView : FrameLayout
    {
        public TextView LabelView { get; private set; }
        public View FieldView { get; private set; }

        public String Label
        {
            get { return LabelView.Text; }
            set { LabelView.Text = value; }
        }

        public CompositeFormView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize(context, attrs);
        }

        public CompositeFormView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize(context, attrs);
        }

        protected abstract int LayoutId { get; }

        private void Initialize(Android.Content.Context context, IAttributeSet attrs)
        {
            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(LayoutId, this, true);

            LabelView = FindViewById<TextView>(Resource.Id.FormLabel);
            FieldView = FindViewById<View>(Resource.Id.FormField);
        }
    }
}