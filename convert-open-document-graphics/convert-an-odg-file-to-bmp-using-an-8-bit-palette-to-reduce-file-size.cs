// HOW-TO: Convert ODG to 8‑Bit BMP with Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.odg";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Configure BMP save options for 8‑bit palette
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Use a standard 8‑bit grayscale palette (you could also compute a close palette)
                    Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false),
                    Compression = Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rgb,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0)
                };

                // Save the image as BMP using the specified options
                odgImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to embed a vector drawing from an OpenDocument file into a legacy Windows application that only accepts 8‑bit BMP images.
 * 2. When you want to reduce the file size of exported graphics by converting high‑color ODG files to a grayscale 256‑color BMP for faster loading over a network.
 * 3. When an automated batch process must convert multiple ODG diagrams to BMP format with a fixed palette for consistent printing on low‑resolution printers.
 * 4. When a reporting tool requires BMP images with a specific bits‑per‑pixel setting, and you must generate them directly from ODG source files in C#.
 * 5. When you are migrating assets from an OpenDocument workflow to a .NET image pipeline and need to preserve resolution while limiting colors to 8‑bit for memory‑constrained environments.
 */
