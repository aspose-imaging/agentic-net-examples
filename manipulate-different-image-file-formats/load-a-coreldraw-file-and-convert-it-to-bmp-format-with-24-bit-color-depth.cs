// HOW-TO: Convert CorelDRAW CDR to 24‑Bit BMP Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image cdrImage = Image.Load(inputPath))
            {
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    cdrImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a 24‑bit BMP thumbnail from a CorelDRAW design for legacy Windows applications.
 * 2. When an automated pipeline must convert CDR vector files to BMP raster images for printing on devices that only accept BMP.
 * 3. When you want to batch‑process CDR assets and store them as BMP files to embed in a .NET desktop application.
 * 4. When a web service receives CorelDRAW files and must deliver BMP versions to clients that cannot handle vector formats.
 * 5. When you are migrating a graphics library and require a reliable C# method to transform CDR files into BMP with full color depth.
 */
