using Android.Content;
using Android.Widget;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using CustomBindingSample.Droid.Binding;
using CustomBindingSample.Droid.Controls;

namespace CustomBindingSample.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterFactory(new MvxCustomBindingFactory<CompositeFormView>("Label", (view) => new FormLabelBinding(view)));
            registry.RegisterFactory(new MvxCustomBindingFactory<EditTextFormView>("Text", (view) => new FormTextBinding(view)));
            registry.RegisterFactory(new MvxCustomBindingFactory<SpinnerFormView>("ItemsSource", (view) => new FormSpinnerItemsBinding(view)));
            registry.RegisterFactory(new MvxCustomBindingFactory<SpinnerFormView>("SelectedItem", (view) => new FormSpinnerSelectionBinding(view)));
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}