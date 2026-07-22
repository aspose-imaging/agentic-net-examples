using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX vector image
            using (CmxImage image = (CmxImage)Image.Load(inputPath))
            {
                // Apply scaling factor of 2.0
                int newWidth = (int)(image.Width * 2.0);
                int newHeight = (int)(image.Height * 2.0);
                image.Resize(newWidth, newHeight);

                // Prepare BMP save options for 24‑bit color
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24
                };

                // Save the scaled image as BMP
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
 * 1. When a CAD system needs to generate high‑resolution bitmap thumbnails of legacy CorelDRAW CMX drawings for a web preview gallery.
 * 2. When an engineering workflow requires converting scaled‑up CMX schematics to 24‑bit BMP files for inclusion in printed technical manuals.
 * 3. When a document management application must batch‑process CMX vector logos, double their size, and store them as BMP images for compatibility with older Windows applications.
 * 4. When a GIS tool needs to enlarge CMX map overlays and export them as BMP files with true‑color depth for raster‑based spatial analysis.
 * 5. When a legacy reporting service has to render CMX diagrams at double size and save them as 24‑bit BMPs to embed in PDF reports that only accept bitmap images.
 */