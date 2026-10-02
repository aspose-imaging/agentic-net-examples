// HOW-TO: Apply Gaussian Blur to JPEG and Save with Quality in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                image.Filter(image.Bounds, filterOptions);

                var jpegOptions = new JpegOptions { Quality = 90 };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically blur sensitive areas of a photo before publishing it online.
 * 2. When you want to reduce image detail to create a soft‑focus effect for a marketing brochure.
 * 3. When you must convert a high‑resolution JPEG to a smaller file while applying a blur to hide background distractions.
 * 4. When you are building a batch‑processing tool that applies a Gaussian blur to user‑uploaded images and saves them with a specific JPEG quality.
 * 5. When you need to programmatically enhance privacy by blurring faces in images before storing them in a database.
 */
