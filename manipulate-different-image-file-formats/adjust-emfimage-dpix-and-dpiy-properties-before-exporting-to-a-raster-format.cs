// HOW-TO: Convert EMF to PNG with Custom DPI Settings in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.emf");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to display a vector EMF logo on a website that only supports PNG images, you can load the EMF with Aspose.Imaging, set the desired DPI, and save it as a PNG.
 * 2. When generating printable PDFs from EMF diagrams, adjusting DpiX and DpiY before rasterizing ensures the PNG output matches the required print resolution.
 * 3. When converting EMF files received from legacy Windows applications into PNG thumbnails for a file‑preview feature, setting the DPI controls the thumbnail size and clarity.
 * 4. When creating a batch process that transforms a collection of EMF icons into PNG assets for a mobile app, customizing DPI avoids blurry icons on high‑density screens.
 * 5. When integrating EMF graphics into a reporting system that outputs PNG charts, modifying the DPI before export guarantees consistent scaling across different report layouts.
 */
