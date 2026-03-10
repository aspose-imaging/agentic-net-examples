using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SvgToRaster
{
    static void Main()
    {
        // Path to the source SVG file
        string inputFile = @"C:\Temp\example.svg";
        // Desired output raster file (PNG)
        string outputFile = @"C:\Temp\example.png";

        // Load the SVG image using Aspose.Imaging unified loader
        using (Image image = Image.Load(inputFile))
        {
            // Configure rasterization options – page size matches original SVG size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White,
                // Enable antialiasing for smoother output
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Set PNG save options and attach rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image to the specified PNG file
            image.Save(outputFile, pngOptions);
        }
    }
}