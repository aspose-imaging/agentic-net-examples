using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Prerequisites:
        // - .NET (any recent version, e.g., .NET 6.0 or later)
        // - Aspose.Imaging for .NET library (install via NuGet: Aspose.Imaging)
        // - A valid Aspose.Imaging license (optional for full features, otherwise evaluation mode)

        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
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
            // Configure rasterization options based on the SVG size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure BMP save options (e.g., 24 bits per pixel)
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}