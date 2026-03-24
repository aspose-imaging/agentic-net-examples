using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\example.svg";
        string outputPath = @"C:\temp\example.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for SVG → PNG conversion
            var rasterOptions = new SvgRasterizationOptions
            {
                // Dimensions (preserve original size)
                PageSize = image.Size,
                // Alternative explicit dimensions:
                // PageWidth = 800,
                // PageHeight = 600,
                // Scale factors (1.0 = 100%)
                ScaleX = 1.0f,
                ScaleY = 1.0f,

                // Background color of the rasterized image
                BackgroundColor = Aspose.Imaging.Color.White,

                // Rendering settings
                SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias,

                // Optional margins
                BorderX = 0,
                BorderY = 0
            };

            // Configure PNG-specific options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                BitDepth = 8,
                Progressive = false,
                PngCompressionLevel = PngOptions.DefaultCompressionLevel
            };

            // Save the rasterized PNG
            image.Save(outputPath, pngOptions);
        }

        // Enumerate supported SVG input options for PNG conversion
        Console.WriteLine("Supported SVG input options for PNG conversion:");
        Console.WriteLine("- Dimensions: PageSize, PageWidth, PageHeight, ScaleX, ScaleY");
        Console.WriteLine("- BackgroundColor");
        Console.WriteLine("- Rendering settings: SmoothingMode, TextRenderingHint, BorderX, BorderY");
        Console.WriteLine("- Additional PNG options: BitDepth, Progressive, PngCompressionLevel");
    }
}