using System;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // The SvgImageType enumeration defines the raster formats that can be produced
        // when an SVG image is rasterized (converted to a bitmap).
        // Iterate through the enum values and display the supported formats.
        foreach (SvgImageType format in Enum.GetValues(typeof(SvgImageType)))
        {
            // Skip the Unknown value as it does not represent a valid output format.
            if (format == SvgImageType.Unknown)
                continue;

            Console.WriteLine($"{format} ({(int)format})");
        }
    }
}