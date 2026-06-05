using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (BmpOptions options = new BmpOptions())
                {
                    options.BitsPerPixel = 24;
                    image.Save(outputPath, options);
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
 * 1. When a developer needs to generate a 24‑bit BMP preview of a CorelDRAW (.cdr) design for legacy Windows applications.
 * 2. When an automated batch‑processing tool must convert multiple CDR files to BMP images for inclusion in a PDF report.
 * 3. When a web service receives user‑uploaded CorelDRAW files and must store them as BMP thumbnails for quick display in a gallery.
 * 4. When a migration script has to transform archived CDR assets into BMP format to ensure compatibility with a new imaging pipeline.
 * 5. When a desktop application needs to load a CDR vector file, rasterize it at 24‑bit color depth, and save it as BMP for printing on devices that only accept bitmap files.
 */