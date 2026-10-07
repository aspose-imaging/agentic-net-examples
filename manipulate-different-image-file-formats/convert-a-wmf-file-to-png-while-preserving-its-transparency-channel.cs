// HOW-TO: Convert WMF to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to display legacy WMF vector graphics on a web page that only supports PNG images with alpha transparency.
 * 2. When generating thumbnails of WMF icons for a Windows desktop application that requires PNG files with a transparent background.
 * 3. When converting WMF diagrams from a CAD export pipeline into PNG assets for inclusion in PDF reports while preserving their transparent background.
 * 4. When automating a batch process that extracts WMF logos from old documents and saves them as PNG files for use in mobile apps.
 * 5. When integrating Aspose.Imaging into a C# service that transforms WMF files into PNG format for email newsletters that need transparent images.
 */
