// HOW-TO: Sharpen TGA Texture With Strength 3 And Save As BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tga";
        string outputPath = "output/output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions();
                image.Filter(image.Bounds, sharpenOptions);

                var bmpOptions = new BmpOptions();
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
 * 1. When you need to enhance the details of a game asset stored as a TGA file before converting it to BMP for use in a Windows‑based rendering engine.
 * 2. When an automated pipeline must apply a medium‑strength sharpening effect to texture files and output them in BMP format for legacy tools that only accept BMP.
 * 3. When you are preparing high‑resolution screenshots saved as TGA for publication and want to improve clarity by sharpening before saving them as BMP for quick preview.
 * 4. When a batch process has to improve the visual quality of scanned technical drawings in TGA format and export them as BMP for inclusion in a .NET reporting application.
 * 5. When integrating Aspose.Imaging into a C# application that receives user‑uploaded TGA textures, applies a sharpening filter, and stores the processed images as BMP for consistent storage.
 */
