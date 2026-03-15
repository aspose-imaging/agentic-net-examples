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
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        // Output PNG file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage for vector-specific properties
            SvgImage svgImage = (SvgImage)image;

            // Configure rasterization options to preserve visual fidelity
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Set PNG export options and attach rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}