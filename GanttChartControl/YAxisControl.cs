using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GanttChartControl
{
    public class YAxisControl : ItemsControl
    {

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(YAxisControl));

        protected override DependencyObject GetContainerForItemOverride()
        {
            YAxisTitleControl gridCell = new YAxisTitleControl();
            return gridCell;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is YAxisTitleControl;
            return _isITV;
        }

    }
    public class YAxisTitleControl : ContentControl
    {



    }
}
