using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

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
            // Configure rasterization options (custom size, background, etc.)
            var rasterOptions = new SvgRasterizationOptions
            {
                // Set desired output size (e.g., 800x600)
                PageSize = new SizeF(800, 600),
                // Optional: set background color
                BackgroundColor = Color.White,
                // Optional: improve rendering quality
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            // Configure PNG export options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // Set color depth and type
                BitDepth = 8,
                ColorType = PngColorType.TruecolorWithAlpha,
                // Set compression level (maximum compression)
                PngCompressionLevel = PngCompressionLevel.ZipLevel9
            };

            // Save the rasterized PNG image
            image.Save(outputPath, pngOptions);
        }
    }
}