namespace GameLibrary.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public bool IsValid
        {
            get { return string.IsNullOrEmpty(Error); }
        }

        public string Error
        {
            get
            {
                var context = new ValidationContext(this, null, null);
                var results = new List<ValidationResult>();

                return !Validator.TryValidateObject(this, context, results)
                    ? string.Join(Environment.NewLine, results.Select(x => x.ErrorMessage))
                    : null;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                var context = new ValidationContext(this, null, null)
                {
                    MemberName = propertyName
                };

                var results = new List<ValidationResult>();
                var value = GetType().GetProperty(propertyName).GetValue(this, null);

                return !Validator.TryValidateProperty(value, context, results)
                    ? string.Join(Environment.NewLine, results.Select(x => x.ErrorMessage))
                    : null;
            }
        }

        public void NotifyOfPropertyChange(string propertyName)
        {
            Execute.OnUIThread(() => PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
        }

        public void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property)
        {
            var lambda = (LambdaExpression)property;

            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else memberExpression = (MemberExpression)lambda.Body;

            NotifyOfPropertyChange(memberExpression.Member.Name);
        }
    }
}