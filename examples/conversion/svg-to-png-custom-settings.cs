using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : @"C:\temp\input.svg";
        // Output PNG file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : @"C:\temp\output.png";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage to access SVG-specific properties
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options for SVG to PNG conversion
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set background color (optional)
                BackgroundColor = Color.Gray,
                // Preserve original size
                PageSize = svgImage.Size,
                // Enable antialiasing for smoother output
                SmoothingMode = SmoothingMode.AntiAlias,
                // Use antialiased text rendering
                TextRenderingHint = TextRenderingHint.AntiAlias,
                // Example scaling (10% of original size)
                ScaleX = 0.1f,
                ScaleY = 0.1f
            };

            // Set PNG export options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized PNG image
            image.Save(outputPath, pngOptions);
        }
    }
}