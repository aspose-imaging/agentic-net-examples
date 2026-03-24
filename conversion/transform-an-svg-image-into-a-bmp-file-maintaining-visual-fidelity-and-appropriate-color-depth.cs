using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\output.bmp";

        // Verify that the input SVG file exists
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
            // Prepare rasterization options matching the source size
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure BMP save options (24 bits per pixel for good color fidelity)
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}