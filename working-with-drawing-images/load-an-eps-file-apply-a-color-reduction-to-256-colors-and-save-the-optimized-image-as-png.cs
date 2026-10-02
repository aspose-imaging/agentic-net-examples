// HOW-TO: Convert EPS to PNG with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/optimized.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage eps = (EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = eps.Width,
                    PageHeight = eps.Height
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Source = new FileCreateSource(outputPath, false)
                };

                eps.Save(outputPath, pngOptions);
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
 * 1. When you need to display a vector EPS logo on a website that only supports raster PNG images, you can rasterize the EPS to PNG with a white background using Aspose.Imaging in C#.
 * 2. When preparing print‑ready assets, converting EPS artwork to PNG while preserving dimensions and setting a solid background ensures consistent appearance across PDF generators.
 * 3. When automating a batch process that ingests EPS files from designers and creates thumbnail PNG previews for a content management system, this code provides fast conversion in .NET.
 * 4. When integrating a legacy design workflow that supplies EPS files into a modern C# application, rasterizing them to PNG allows you to use standard image controls without additional plugins.
 * 5. When generating email newsletters that require embedded PNG images instead of EPS, this snippet converts the vector files on the server side with Aspose.Imaging to meet email client restrictions.
 */
