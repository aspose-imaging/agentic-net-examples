using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = "input.svg";
        // Output PNG file path
        string outputPath = "output.png";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options to preserve transparency
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = image.Size;
            rasterOptions.BackgroundColor = Color.Transparent; // keep alpha channel

            // Set PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rasterized image as PNG preserving alpha channel
            image.Save(outputPath, pngOptions);
        }
    }
}