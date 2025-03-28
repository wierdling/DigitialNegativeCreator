namespace DigitalNegativeCreator.HelperClasses
{
    internal class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.X.CompareTo(y.X);
        }
    }
}
