using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for low quality (faster) conversion
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,                     // Preserve original size
                SmoothingMode = Aspose.Imaging.SmoothingMode.None,          // Disable anti‑aliasing
                TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel // Simple text rendering
            };

            // Set up BMP save options and attach the rasterization options
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}