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
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Droid.Target;

namespace CustomBindingSample.Droid.Binding
{
    public abstract class CustomBinding<TView, TTarget> : MvxAndroidTargetBinding where TView : View
    {
        protected bool Subscribed { get; private set; }

        public override Type TargetType
        {
            get { return typeof(TTarget); }
        }

        protected TView View
        {
            get { return (TView)Target; }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        public CustomBinding(TView source)
            : base(source)
        {
        }

        protected abstract void SetCustomValue(TTarget value);
        protected abstract bool SubscribeToCustomEvents();
        protected abstract void UnsubscribeToCustomEvents();

        protected override sealed void SetValueImpl(object target, object value)
        {
            if (Target == null) return;

            SetCustomValue((TTarget)value);
        }

        public override sealed void SubscribeToEvents()
        {
            if (Target == null) return;

            Subscribed = SubscribeToCustomEvents();
        }

        protected override sealed void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (Target != null && Subscribed)
                {
                    UnsubscribeToCustomEvents();
                    Subscribed = false;
                }
            }
            base.Dispose(isDisposing);
        }
    }
}