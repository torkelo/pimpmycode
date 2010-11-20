namespace GameLibrary.Framework
{
    using System.Windows;
    using System.Windows.Controls;

    public static class View
    {
        public static DependencyProperty ModelProperty =
            DependencyProperty.RegisterAttached(
                "Model",
                typeof(object),
                typeof(View),
                new PropertyMetadata(ModelChanged)
                );

        public static void SetModel(DependencyObject d, object value)
        {
            d.SetValue(ModelProperty, value);
        }

        public static object GetModel(DependencyObject d)
        {
            return d.GetValue(ModelProperty);
        }

        public static void ModelChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            if(args.NewValue == null || args.NewValue == args.OldValue)
                return;

            var view = ViewLocator.Locate(args.NewValue);
            ViewModelBinder.Bind(args.NewValue, view);

            ((ContentControl)sender).Content = view;
        }
    }
}