namespace GameLibrary.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Markup;

    public static class ViewModelBinder
    {
        private static readonly BooleanToVisibilityConverter _booleanToVisibilityConverter = new BooleanToVisibilityConverter();

        private static readonly Dictionary<Type, DependencyProperty> _boundProperties =
            new Dictionary<Type, DependencyProperty>
            {
                { typeof(TextBox), TextBox.TextProperty },
                { typeof(ContentControl), View.ModelProperty },
                { typeof(TransitioningContentControl), View.ModelProperty },
                { typeof(ItemsControl), ItemsControl.ItemsSourceProperty },
                { typeof(TextBlock), TextBlock.TextProperty },
                { typeof(BusyIndicator), BusyIndicator.IsBusyProperty },
                { typeof(Rating), Rating.ValueProperty },
                { typeof(Border), Border.VisibilityProperty }
            };

        private static readonly DataTemplate _defaultTemplate = (DataTemplate)XamlReader.Load(
            "<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' " +
                           "xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' " +
                           "xmlns:vm='clr-namespace:GameLibrary.Framework;assembly=GameLibrary'> " +
                "<ContentControl vm:View.Model=\"{Binding}\" />" +
            "</DataTemplate>"
            );

        public static void Bind(object viewModel, DependencyObject view)
        {
            var element = view as FrameworkElement;
            if(element == null)
                return;

            var viewType = viewModel.GetType();
            var properties = viewType.GetProperties();
            var methods = viewType.GetMethods();

            BindCommands(viewModel, element, methods, properties);
            BindProperties(element, properties);

            element.DataContext = viewModel;
        }

        private static void BindProperties(FrameworkElement view, IEnumerable<PropertyInfo> properties)
        {
            foreach (var property in properties)
            {
                var foundControl = view.FindName(property.Name) as DependencyObject;
                if(foundControl == null)
                    continue;

                DependencyProperty boundProperty;

                if(!_boundProperties.TryGetValue(foundControl.GetType(), out boundProperty))
                    continue;
                if(((FrameworkElement)foundControl).GetBindingExpression(boundProperty) != null)
                    continue;

                var binding = new Binding(property.Name)
                {
                    Mode = property.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay,
                    ValidatesOnDataErrors = Attribute.GetCustomAttributes(property, typeof(ValidationAttribute), true).Any()
                };

                if (boundProperty == UIElement.VisibilityProperty && typeof(bool).IsAssignableFrom(property.PropertyType))
                    binding.Converter = _booleanToVisibilityConverter;
                else if (typeof(DateTime).IsAssignableFrom(property.PropertyType))
                    binding.StringFormat = "{0:MM/dd/yyyy}";

                BindingOperations.SetBinding(foundControl, boundProperty, binding);

                var textBox = foundControl as TextBox;
                if(textBox != null && boundProperty == TextBox.TextProperty)
                {
                    textBox.TextChanged += delegate { textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource(); };
                    continue;
                }

                var itemsControl = foundControl as ItemsControl;
                if(itemsControl != null && string.IsNullOrEmpty(itemsControl.DisplayMemberPath) && itemsControl.ItemTemplate == null)
                {
                    itemsControl.ItemTemplate = _defaultTemplate;
                    continue;
                }
            }
        }

        private static void BindCommands(object viewModel, FrameworkElement view, IEnumerable<MethodInfo> methods, IEnumerable<PropertyInfo> properties)
        {
            foreach(var method in methods)
            {
                var foundControl = view.FindName(method.Name);
                if(foundControl == null)
                    continue;

                var foundProperty = properties
                    .FirstOrDefault(x => x.Name == "Can" + method.Name);

                var command = new ReflectiveCommand(viewModel, method, foundProperty);
                TrySetCommand(foundControl, command);
            }
        }

        private static void TrySetCommand(object control, ICommand command)
        {
            if(!TrySetCommandBinding<ButtonBase>(control, ButtonBase.CommandProperty, command))
                TrySetCommandBinding<Hyperlink>(control, Hyperlink.CommandProperty, command);
        }

        private static bool TrySetCommandBinding<T>(object control, DependencyProperty property, ICommand command)
            where T : DependencyObject
        {
            var commandSource = control as T;
            if(commandSource == null)
                return false;

            BindingOperations.SetBinding(commandSource, property, new Binding
            {
                Source = command
            });

            return true;
        }
    }
}