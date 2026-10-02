// HOW-TO: Resize EPS to 2000px Width and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                int originalWidth = epsImage.Width;
                int originalHeight = epsImage.Height;
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)originalHeight * newWidth / originalWidth);

                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = newWidth,
                    PageHeight = newHeight
                };

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
 * 1. When you need to display a high‑resolution EPS logo on a web page that only supports raster formats like PNG.
 * 2. When you must generate thumbnails of vector EPS drawings at a fixed width for a product catalog.
 * 3. When an automated pipeline converts print‑ready EPS files to PNG for inclusion in PDF reports while preserving aspect ratio.
 * 4. When a desktop application resizes large EPS illustrations to a manageable size before saving them as PNG for faster loading.
 * 5. When a batch process prepares EPS artwork for email newsletters by scaling it to 2000 px wide and exporting to PNG.
 */
