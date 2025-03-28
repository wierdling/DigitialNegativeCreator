namespace DigitalNegativeCreator.HelperClasses
{
    internal class GrayscaleColorComparer : IComparer<Color>
    {
        public int Compare(Color x, Color y)
        {
            return x.R.CompareTo(y.R);
        }
    }
}
