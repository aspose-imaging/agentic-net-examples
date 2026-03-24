using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Prerequisites:
        // - Install Aspose.Imaging for .NET via NuGet.
        // - (Optional) Apply a valid Aspose.Imaging license for full functionality.
        // - Target a supported .NET runtime (e.g., .NET 6, .NET 7 with appropriate Aspose version).

        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image (any format supported by Aspose.Imaging)
        using (Image image = Image.Load(inputPath))
        {
            // Configure BMP options for raster output
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24 // 24‑bpp RGB raster image
            };

            // Save the image as a raster BMP file
            image.Save(outputPath, bmpOptions);
        }

        Console.WriteLine("Image conversion to raster format completed.");
    }
}