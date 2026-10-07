// HOW-TO: Convert SVG to 8-Bit BMP with Indexed Palette in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.svg";
            string outputPath = "Output\\image.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    bmpOptions.BitsPerPixel = 8;
                    image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate low-size BMP thumbnails from vector SVG assets for legacy Windows applications that only support 8-bit indexed colors.
 * 2. When a game developer must convert scalable SVG icons into 256-color BMP sprites to meet the texture format requirements of an older engine.
 * 3. When an automated reporting tool creates BMP charts from SVG diagrams and must limit the file size by using an 8-bit palette.
 * 4. When a batch-processing script prepares SVG logos for printing on devices that only accept BMP files with indexed palettes.
 * 5. When a migration utility transforms SVG UI elements into BMP resources for a .NET desktop application that relies on indexed-color images.
 */
