using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        // Output PNG file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the SVG image using unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for SVG to control output size and background
            var rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = image.Size;               // Preserve original dimensions
            rasterOptions.BackgroundColor = Aspose.Imaging.Color.White; // Set background color

            // Set PNG export options and attach the rasterization settings
            var pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rasterized image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}