// HOW-TO: Resize EPS to 2000x2000 and Save as PNG Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output/high_res.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                int targetWidth = 2000;
                int targetHeight = 2000;

                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = targetWidth,
                    PageHeight = targetHeight
                };

                epsImage.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                epsImage.Save(outputPath, pngOptions);
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
 * 1. When you need to convert a vector EPS logo to a high‑resolution PNG for web display.
 * 2. When preparing print‑ready assets, you must rasterize an EPS illustration at a specific pixel size before saving as PNG.
 * 3. When automating a batch process that generates thumbnails from EPS files at a fixed 2000 × 2000 resolution.
 * 4. When integrating EPS to PNG conversion into a C# application that requires precise control over image dimensions and rasterization options.
 * 5. When a client requires a PNG version of an EPS diagram with nearest‑neighbour scaling to preserve sharp edges.
 */
