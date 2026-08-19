// HOW-TO: Convert OTG to BMP with White Background Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with white background
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Set up BMP save options and attach rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display an OpenDocument graphic (OTG) in a Windows application that only supports BMP files, you can rasterize it with a white background using Aspose.Imaging for .NET.
 * 2. When generating printable assets from vector OTG diagrams and require a solid white canvas to avoid transparent areas, this code converts the vector to a BMP raster image.
 * 3. When automating a batch process that converts legacy OTG icons to BMP thumbnails for a file‑explorer UI, the rasterization options ensure consistent background color.
 * 4. When integrating OTG content into a legacy reporting system that only accepts BMP images, you can programmatically load, rasterize with a white background, and save the result in C#.
 * 5. When preparing OTG artwork for a game engine that does not support vector formats, this snippet converts the vector to a BMP with a white background to prevent rendering artifacts.
 */
