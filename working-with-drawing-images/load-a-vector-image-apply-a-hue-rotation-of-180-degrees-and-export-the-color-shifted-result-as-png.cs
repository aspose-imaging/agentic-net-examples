// HOW-TO: Convert SVG to PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };
                pngOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When you need to generate web‑ready PNG thumbnails from user‑uploaded SVG logos in a C# web application.
 * 2. When you must batch‑process design assets, converting scalable vector graphics to raster PNGs for inclusion in mobile app resources.
 * 3. When an e‑commerce platform requires product illustrations stored as SVG to be rendered as PNGs with a white background for email newsletters.
 * 4. When a reporting tool creates charts as SVG and you need to embed them as PNG images in PDF documents using .NET.
 * 5. When a legacy system only accepts PNG files, and you have to programmatically transform vector icons into PNG format during data migration.
 */
