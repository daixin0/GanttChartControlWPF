using GanttChartControl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GanttChartControl
{
    public class GridCell : ContentControl
    {


        public bool IsDottedLine
        {
            get { return (bool)GetValue(IsDottedLineProperty); }
            set { SetValue(IsDottedLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDottedLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDottedLineProperty =
            DependencyProperty.Register("IsDottedLine", typeof(bool), typeof(GridCell));



        public double YPoint
        {
            get { return (double)GetValue(YPointProperty); }
            set { SetValue(YPointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YPoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YPointProperty =
            DependencyProperty.Register("YPoint", typeof(double), typeof(GridCell));



        public DateTime ProjectStartTime
        {
            get { return (DateTime)GetValue(ProjectStartTimeProperty); }
            set { SetValue(ProjectStartTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectStartTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectStartTimeProperty =
            DependencyProperty.Register("ProjectStartTime", typeof(DateTime), typeof(GridCell));


        public DateTime ProjectEndTime
        {
            get { return (DateTime)GetValue(ProjectEndTimeProperty); }
            set { SetValue(ProjectEndTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectEndTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectEndTimeProperty =
            DependencyProperty.Register("ProjectEndTime", typeof(DateTime), typeof(GridCell));

        public DateTime StartTime
        {
            get { return (DateTime)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.Register("StartTime", typeof(DateTime), typeof(GridCell));


        public DateTime EndTime
        {
            get { return (DateTime)GetValue(EndTimeProperty); }
            set { SetValue(EndTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.Register("EndTime", typeof(DateTime), typeof(GridCell));



        public Visibility IsVisibleLine
        {
            get { return (Visibility)GetValue(IsVisibleLineProperty); }
            set { SetValue(IsVisibleLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsVisibleLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsVisibleLineProperty =
            DependencyProperty.Register("IsVisibleLine", typeof(Visibility), typeof(GridCell), new PropertyMetadata(Visibility.Collapsed));



        public Visibility IsVisiableStartLine
        {
            get { return (Visibility)GetValue(IsVisiableStartLineProperty); }
            set { SetValue(IsVisiableStartLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsVisiableStartLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsVisiableStartLineProperty =
            DependencyProperty.Register("IsVisiableStartLine", typeof(Visibility), typeof(GridCell), new PropertyMetadata(Visibility.Collapsed));


        public Visibility IsVisiableEndLine
        {
            get { return (Visibility)GetValue(IsVisiableEndLineProperty); }
            set { SetValue(IsVisiableEndLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsVisiableEndLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsVisiableEndLineProperty =
            DependencyProperty.Register("IsVisiableEndLine", typeof(Visibility), typeof(GridCell), new PropertyMetadata(Visibility.Collapsed));



        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            DateTime defaultTime = new DateTime(2000, 1, 1);
            if (e.Property.Name == "ProjectStartTime" || e.Property.Name == "ProjectEndTime" || e.Property.Name == "StartTime" || e.Property.Name == "EndTime")
            {
                if (ProjectStartTime > defaultTime && ProjectEndTime > defaultTime && StartTime > defaultTime && EndTime > defaultTime)
                {
                    Drawing();
                }
            }
        }

        public void Drawing()
        {
            if (ProjectStartTime == StartTime)
            {
                IsVisiableStartLine = Visibility.Visible;
            }
            if (ProjectEndTime == EndTime)
            {
                IsVisiableEndLine = Visibility.Visible;
            }
            if (StartTime >= ProjectStartTime && EndTime <= ProjectEndTime)
            {
                IsVisibleLine = Visibility.Visible;
            }

        }

    }

    public enum ChartLineType
    {
        PolylineType,
        BezierType,
        PolylineKnotsType,
        BezierKnotsType,
        Knots,
        Number
    }
    public class RowsGridPresenter : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            ColumnsGridPresenter gridCell = new ColumnsGridPresenter();
            return gridCell;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is ColumnsGridPresenter;
            return _isITV;
        }
        public ObservableCollection<TimeItemModel> GanttColumnsItem
        {
            get { return (ObservableCollection<TimeItemModel>)GetValue(GanttColumnsItemProperty); }
            set { SetValue(GanttColumnsItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttColumnsItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttColumnsItemProperty =
            DependencyProperty.Register("GanttColumnsItem", typeof(ObservableCollection<TimeItemModel>), typeof(RowsGridPresenter));



        public ObservableCollection<LineService> LineServicesData
        {
            get { return (ObservableCollection<LineService>)GetValue(LineServicesDataProperty); }
            set { SetValue(LineServicesDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LineServicesData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineServicesDataProperty =
            DependencyProperty.Register("LineServicesData", typeof(ObservableCollection<LineService>), typeof(RowsGridPresenter));


        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name == "GanttColumnsItem" || e.Property.Name == "ItemsSource")
            {
                if (ItemsSource == null || GanttColumnsItem == null)
                    return;
                foreach (var item in this.ItemsSource)
                {
                    ColumnsGridPresenter col = this.ItemContainerGenerator.ContainerFromItem(item) as ColumnsGridPresenter;
                    col.GanttProjectRow = item as GanttProjectModel;
                    col.ItemsSource = GanttColumnsItem;
                }
            }

        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (LineServicesData == null)
                return;
            LoadData();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            BorderChart = this.Template.FindName("borderChart", this) as Canvas;
            
        }
        Canvas BorderChart { get; set; }
        private void ConvertToGraphData()
        {
            if (LineServicesData != null)
            {
                foreach (LineService info in this.LineServicesData)
                {
                    if (info.LineServicesData == null)
                        continue;
                    double num2 = 18;
                    double num3 = Convert.ToDouble(18) / Convert.ToDouble(10);
                    for (int i = 0; i < info.LineServicesData.Count; i++)
                    {
                        info.LineServicesData[i].PointX = num2 * ((info.LineServicesData[i].PointXDate.TimeOfDay.TotalMinutes - GanttColumnsItem[0].TimeName.TimeOfDay.TotalMinutes) / 5);
                        if (info.ChartLineType == ChartLineType.Number)
                        {
                            info.LineServicesData[i].ScreenPointY = info.TopItemIndex * 17;
                        }
                        else
                        {
                            info.LineServicesData[i].ScreenPointY = BorderChart.ActualHeight - (info.LineServicesData[i].PointY * num3);
                        }

                    }
                }
            }
        }

        private void DrawBezierChartData(SolidColorBrush color, Point[] points, Point[] firstControlPoints, Point[] secondControlPoints)
        {
            PathSegmentCollection segments = new PathSegmentCollection();
            for (int i = 0; i < (points.Length - 1); i++)
            {
                segments.Add(new BezierSegment(firstControlPoints[i], secondControlPoints[i], points[i + 1], true));
            }
            PathFigure figure = new PathFigure(points[0], segments, false);
            PathGeometry geometry = new PathGeometry(new PathFigure[] { figure });
            Path element = new Path
            {
                Stroke = color,
                Data = geometry
            };
            element.Style = base.Resources["pathStyleKey"] as Style;
            this.BorderChart.Children.Add(element);
        }

        private void DrawPolylineChartData(SolidColorBrush color, Point[] points)
        {
            Polyline element = new Polyline();
            for (int i = 0; i < points.Length; i++)
            {
                element.Points.Add(points[i]);
            }
            element.Stroke = color;
            this.BorderChart.Children.Add(element);
        }
        private void DrawPolylineKnotsChartData(SolidColorBrush color, Point[] points, string knots)
        {
            for (int i = 0; i < points.Length; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = knots;
                tb.Foreground = color;
                Canvas.SetLeft(tb, points[i].X - 3);
                Canvas.SetTop(tb, points[i].Y - 8);
                this.BorderChart.Children.Add(tb);
            }
        }
        private void DrawKnotsChartData(SolidColorBrush color, Point[] points, string knots)
        {
            for (int i = 0; i < points.Length; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = knots;
                tb.Foreground = color;
                Canvas.SetLeft(tb, points[i].X - 3);
                Canvas.SetTop(tb, points[i].Y + 42);
                this.BorderChart.Children.Add(tb);
            }
        }
        private void DrawPolylineNumberChartData(SolidColorBrush color, Point[] points, ObservableCollection<int> data)
        {
            for (int i = 0; i < points.Length; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = data[i].ToString();
                tb.Foreground = color;
                Canvas.SetLeft(tb, points[i].X);
                Canvas.SetTop(tb, points[i].Y);
                this.BorderChart.Children.Add(tb);
            }
        }
        public void LoadData()
        {
            this.ConvertToGraphData();
            if (this.LineServicesData != null)
            {
                foreach (LineService curve in this.LineServicesData)
                {
                    if (curve.LineServicesData == null)
                        continue;
                    Point[] array = new Point[curve.LineServicesData.Count];
                    for (int i = 0; i < curve.LineServicesData.Count; i++)
                    {
                        array[i] = new Point(curve.LineServicesData[i].PointX, curve.LineServicesData[i].ScreenPointY);
                    }
                    if ((curve.ChartLineType == ChartLineType.BezierType) || (curve.ChartLineType == ChartLineType.BezierKnotsType))
                    {
                        Point[] pointArray2;
                        Point[] pointArray3;
                        BezierSpline.GetCurveControlPoints(array, out pointArray2, out pointArray3);
                        this.DrawBezierChartData(curve.LineLegendItem.Color, array, pointArray2, pointArray3);
                        if (curve.ChartLineType == ChartLineType.BezierKnotsType)
                        {
                        }
                    }
                    else if ((curve.ChartLineType == ChartLineType.PolylineType) || (curve.ChartLineType == ChartLineType.PolylineKnotsType))
                    {
                        this.DrawPolylineChartData(curve.LineLegendItem.Color, array);
                        if (curve.ChartLineType == ChartLineType.PolylineKnotsType)
                        {
                            DrawPolylineKnotsChartData(curve.LineLegendItem.Color, array, curve.LineLegendItem.TitleIcon);
                        }
                    }
                    else if (curve.ChartLineType == ChartLineType.Knots)
                    {
                        DrawKnotsChartData(curve.LineLegendItem.Color, array, curve.LineLegendItem.TitleIcon);
                    }
                    else if (curve.ChartLineType == ChartLineType.Number)
                    {
                        ObservableCollection<int> dataList = new ObservableCollection<int>();
                        foreach (var item in curve.LineServicesData)
                        {
                            dataList.Add(item.DataValue);
                        }
                        DrawPolylineNumberChartData(curve.LineLegendTopItem.Color, array, dataList);
                    }
                }

            }
        }
    }
    public class ColumnsGridPresenter : ItemsControl
    {

        protected override DependencyObject GetContainerForItemOverride()
        {
            GridCell gridCell = new GridCell();
            return gridCell;
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool _isITV = item is GridCell;
            return _isITV;
        }


        public GanttProjectModel GanttProjectRow
        {
            get { return (GanttProjectModel)GetValue(GanttProjectRowProperty); }
            set { SetValue(GanttProjectRowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GanttProjectRow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttProjectRowProperty =
            DependencyProperty.Register("GanttProjectRow", typeof(GanttProjectModel), typeof(ColumnsGridPresenter));


        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            for (int i = 0; i < Items.Count; i++)
            {
                if (i + 1 == Items.Count)
                {
                    TimeItemModel timeItemModel1 = Items[i] as TimeItemModel;
                    GridCell gridCell = this.ItemContainerGenerator.ContainerFromIndex(i) as GridCell;
                    if (gridCell == null)
                        continue;
                    if ((i + 1) % 3 == 0)
                        gridCell.IsDottedLine = false;
                    else
                        gridCell.IsDottedLine = true;
                    gridCell.StartTime = timeItemModel1.TimeName;
                    gridCell.EndTime = timeItemModel1.TimeName.AddMinutes(5);
                    gridCell.ProjectEndTime = GanttProjectRow.EndTime;
                    gridCell.ProjectStartTime = GanttProjectRow.StartTime;
                    gridCell.Content = null;
                }
                else
                {
                    TimeItemModel timeItemModel1 = Items[i] as TimeItemModel;
                    TimeItemModel timeItemModel2 = Items[i + 1] as TimeItemModel;
                    GridCell gridCell = this.ItemContainerGenerator.ContainerFromIndex(i) as GridCell;
                    if (gridCell == null)
                        continue;
                    if ((i + 1) % 3 == 0)
                        gridCell.IsDottedLine = false;
                    else
                        gridCell.IsDottedLine = true;
                    gridCell.StartTime = timeItemModel1.TimeName;
                    gridCell.EndTime = timeItemModel2.TimeName;
                    gridCell.ProjectEndTime = GanttProjectRow.EndTime;
                    gridCell.ProjectStartTime = GanttProjectRow.StartTime;
                    gridCell.Content = null;
                }
            }
        }

    }

}
