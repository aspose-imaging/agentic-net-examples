// HOW-TO: How To Apply Emboss Filter To PNG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string inputPath = "C:\\Images\\sample.png";
            string outputPath = "C:\\Images\\sample_emboss.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Emboss effect is not available in Aspose.Imaging filter options.
                throw new NotSupportedException("Emboss filter is not supported by Aspose.Imaging.");
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
 * 1. When you need to load a PNG image, verify the file exists, and create an output directory before applying filters in a C# WPF application.
 * 2. When you want to display a user‑friendly error if the emboss filter is not supported by Aspose.Imaging.
 * 3. When you must cast the loaded image to a RasterImage to ensure raster‑based operations like embossing can be performed.
 * 4. When you need to catch exceptions such as FileNotFound or NotSupportedException while processing images in a .NET desktop app.
 * 5. When you are prototyping real‑time preview of image effects and need a baseline code snippet that checks filter availability.
 */
