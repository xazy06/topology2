using System;


namespace Designer.Classes
{
    public class Component
    {
        public String DisplayName { get; set; }
        public String ClassName { get; set; }
        public String GroupName { get; set; }
        public Frame Frame { get; set; }
        public Shape[] Graphics { get; set; }
        public Frame DefaultSize { get; set; }
        public Frame MinSize { get; set; }
        public Frame MaxSize { get; set; }
        public String DefaultText { get; set; }
        public ObjectProp[] Properties { get; set; }
        public ExternalMethod OnDblClick { get; set; }
        public ExternalMethod OnChange { get; set; }
    }

    public class ObjectProp
    {
          public ObjectProp(String DisplayName, String PropName, String GroupName, String PropType, 
            ExternalMethod DataSource, ExternalMethod OnChange )
        {
            this.DisplayName = DisplayName;
            this.PropName = PropName;
            this.GroupName = GroupName;
            this.PropType = PropType;
            this.DataSource = new ExternalMethod(DataSource.Url, DataSource.JsMethod);
            this.OnChange = new ExternalMethod(OnChange.Url, OnChange.JsMethod);
        }

        public String DisplayName { get; set; }
        public String PropName { get; set; }
        public String GroupName { get; set; }
        public String PropType { get; set; }
        public ExternalMethod DataSource { get; set; }
        public ExternalMethod OnChange { get; set; }
    }

    public enum Shapes
    {
        Point,
        Line,
        Rectangle,
        Circle,
        Image,
        Label
    }

    public class ValidationResult
    {
        public Boolean IsOk { get; set; }
        public String Message { get; set; }
    }

    public class Shape
    {
        public String ShapeName { get; protected set; }
    }

    public class Point : Shape
    {
        public Point()
        {
            ShapeName = Shapes.Point.ToString();
        }

        public Int32 X1 { get; set; }
        public Int32 Y1 { get; set; }
    }

    public class Rectangle: Shape
    {
        public Rectangle()
        {
            ShapeName = Shapes.Rectangle.ToString();
        }

        public Rectangle(Int32 X1, Int32 Y1, Int32 X2, Int32 Y2)
        {
            ShapeName = Shapes.Rectangle.ToString();
            Frame = new Frame(X1, Y1, X2, Y2);
        }

        public Frame Frame { get; private set; }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            ShapeName = Shapes.Circle.ToString();
        }

        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Int32 Radius { get; set; }
    }

    public class Line : Shape
    {
        public Line()
        {
            ShapeName = Shapes.Line.ToString();
        }

        public Int32 X1 { get; set; }
        public Int32 Y1 { get; set; }
        public Int32 X2 { get; set; }
        public Int32 Y2 { get; set; }
    }

    public class Image : Shape
    {
        public Image()
        {
            ShapeName = Shapes.Image.ToString();
        }
        public Frame Frame { get; set; }
        public ExternalMethod GetMethod { get; set; }
    }

    public class Label : Shape
    {
        public Label()
        {
            ShapeName = Shapes.Label.ToString();
        }

        public Frame Frame { get; set; }        
    }

    public class Frame
    {
        public Frame(Int32 X1, Int32 Y1, Int32 X2, Int32 Y2)
        {
            this.X1 = X1;
            this.Y1 = Y1;
            this.X2 = X2;
            this.Y2 = Y2;
        }

        public Int32 X1 { get; set; }
        public Int32 Y1 { get; set; }
        public Int32 X2 { get; set; }
        public Int32 Y2 { get; set; }
    }

    public class ExternalMethod
    {

        public ExternalMethod(String Url, String JsMethod)
        {
            this.Url = Url;
            this.JsMethod = JsMethod;
        }

        public String Url { get; set; }
        public String JsMethod { get; set; }
    }
}
