// HOW-TO: Convert TGA Image to BMP with Alpha Channel and Original Bit Depth in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tga";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Preserve original bit depth
                ushort bitsPerPixel = (ushort)tgaImage.BitsPerPixel;

                // Preserve resolution
                double horizontalResolution = tgaImage.HorizontalResolution;
                double verticalResolution = tgaImage.VerticalResolution;

                // Create BMP image from the TGA raster, keeping alpha channel if present
                using (BmpImage bmpImage = new BmpImage(
                    tgaImage,
                    bitsPerPixel,
                    BitmapCompression.Rgb,
                    horizontalResolution,
                    verticalResolution))
                {
                    // Save as BMP
                    bmpImage.Save(outputPath);
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
 * 1. When you need to import legacy TGA textures into a Windows application that only supports BMP while keeping transparency.
 * 2. When a game asset pipeline requires converting high‑color‑depth TGA sprites to BMP for compatibility with older tools without losing the original bit depth.
 * 3. When generating thumbnails for a web service that stores images as BMP but must preserve the source image’s resolution and alpha information.
 * 4. When migrating a batch of scientific imaging data from TGA to BMP for archival in a format that retains the exact pixel depth.
 * 5. When a CAD program exports drawings as TGA and you must programmatically convert them to BMP for further processing in .NET without discarding the alpha channel.
 */
