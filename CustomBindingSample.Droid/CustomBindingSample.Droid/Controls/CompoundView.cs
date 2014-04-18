using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace CustomBindingSample.Droid.Controls
{
    public class CompoundView : LinearLayout
    {
        private readonly EditText mLabel;
        public String Label
        {
            get { return mLabel.Text; }
            set { mLabel.Text = value; }
        }

        public event EventHandler<TextChangedEventArgs> LabelTextChanged;
        
        public CompoundView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Orientation = Android.Widget.Orientation.Vertical;

            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            inflater.Inflate(Resource.Layout.CompoundView, this, true);

            mLabel = FindViewById<EditText>(Resource.Id.TxField);
            mLabel.TextChanged += HandleLableTextChanged;
        }

        private void HandleLableTextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (LabelTextChanged != null)
            {
                LabelTextChanged(this, e);
            }
        }
    }
}