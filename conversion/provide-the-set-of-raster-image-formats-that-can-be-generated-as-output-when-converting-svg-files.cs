using System;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Raster image formats that Aspose.Imaging can produce when converting an SVG.
        // These correspond to the values of the SvgImageType enumeration (excluding Unknown).
        var rasterFormats = new[]
        {
            SvgImageType.Jpeg, // JPEG JFIF
            SvgImageType.Png,  // Portable Network Graphics
            SvgImageType.Bmp,  // Windows Bitmap
            SvgImageType.Gif,  // GIF image format
            SvgImageType.Tiff  // TIFF image format
        };

        Console.WriteLine("Raster image formats available for SVG conversion:");
        foreach (var format in rasterFormats)
        {
            Console.WriteLine("- " + format);
        }
    }
}