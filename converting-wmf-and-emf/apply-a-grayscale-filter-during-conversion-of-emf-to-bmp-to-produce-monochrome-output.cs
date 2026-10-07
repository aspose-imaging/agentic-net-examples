// HOW-TO: Convert EMF to BMP with Grayscale Filter in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.emf";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage rasterImage)
                {
                    rasterImage.Grayscale();
                    var bmpOptions = new BmpOptions();
                    rasterImage.Save(outputPath, bmpOptions);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image and cannot be grayscaled.");
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
 * 1. When you need to generate monochrome BMP thumbnails from vector EMF icons for legacy Windows applications.
 * 2. When converting EMF diagrams to BMP for printing on devices that only support grayscale images.
 * 3. When preparing EMF charts for inclusion in PDF reports that require black‑and‑white bitmap images.
 * 4. When automating batch processing of EMF assets to reduce file size by removing color information.
 * 5. When creating grayscale BMP assets for machine‑vision systems that expect single‑channel input.
 */
