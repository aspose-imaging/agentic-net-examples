using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputPath = @"C:\temp\example.svg";

        // Output PNG file path (same folder, .png extension)
        string outputPath = Path.ChangeExtension(inputPath, ".png");

        // Load the SVG image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to SvgImage for SVG-specific operations
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options for SVG to PNG conversion
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the original SVG dimensions
                PageSize = svgImage.Size,
                // Optional: set background color if needed (default is white)
                BackgroundColor = Color.White
            };

            // Configure PNG export options and attach the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}