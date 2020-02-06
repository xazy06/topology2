using System;
using System.Collections.Generic;


namespace Designer.Classes
{
    public class Model
    {
        public String Uuid { get; set; }
        public String BgColor { get; set; }
        public ModelHistory History { get; set; }
        public ModelItem[] Items { get; set; }
    }

    public enum Units
    {
        MM,
        SM,
        M,
    }

    public class ModelItem
    {        
        public String Uuid { get; set; }
        public String ClassName { get; set; }
        public Font Font { get; set; }
        public String Text { get; set; }
        public Int32 Layer { get; set; }
        public Frame Frame { get; set; }
        public Single Angle { get; set; }
        public String FrontColor { get; set; }
        public String BgColor { get; set; }
        public Dictionary<String, String> PropValues;
    }

    public class Font
    {
        public String Color { get; set; }
        public String FontName { get; set; }
        public Int32 Weight { get; set; }
        public Boolean Bold { get; set; }
        public Boolean Italic { get; set; }
        public Boolean Underline { get; set; }
    }

    public class ModelHistory
    {
        public Point Center { get; set; }
        public Single Scale { get; set; }
        public Units Unit { get; set; }
        public Boolean ShowGrid { get; set; }
        public Int32 GridScale { get; set; }       
        public Boolean SnapToGrid { get; set; }
        public Boolean SnapToNearest { get; set; }
        public Int32 SnapStrength { get; set; }
    }
}
