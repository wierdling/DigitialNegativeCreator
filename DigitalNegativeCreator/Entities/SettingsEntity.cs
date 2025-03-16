using System.Drawing.Imaging;

namespace DigitalNegativeCreator.Entities
{
    public class SettingsEntity
    {
        public string? DefaultOutputDirectory { get; set; }
        public string? DefaultInputDirectory { get; set; }
        public OutputTypeEnum OutputType { get; set; } = OutputTypeEnum.Tiff;
        public string? ColorMapFileName { get; set; }
        public SortedDictionary<Color, Point> SortedGrayscaleColorMapping { get; set; } = new SortedDictionary<Color, Point>(new GrayscaleColorComparer());
        public Dictionary<Point, Color> ColorPointMappings { get; set; }

        public Image ImageMap { get; set; }

        public SettingsEntity() {

        }


    }
}
