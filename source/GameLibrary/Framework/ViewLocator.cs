namespace GameLibrary.Framework
{
    using System;
    using System.Reflection;
    using System.Windows;

    public static class ViewLocator
    {
        public static UIElement Locate(object viewModel)
        {
            var viewTypeName = viewModel.GetType().AssemblyQualifiedName.Replace("Model", string.Empty);
            var viewType = Type.GetType(viewTypeName);

            if(viewType == null)
            {
                viewTypeName = "GameLibrary.Views." + viewModel.GetType().Name.Replace("DTO", "View");
                viewType = Assembly.GetExecutingAssembly().GetType(viewTypeName);
            }

            return (UIElement)Activator.CreateInstance(viewType);
        }
    }
}