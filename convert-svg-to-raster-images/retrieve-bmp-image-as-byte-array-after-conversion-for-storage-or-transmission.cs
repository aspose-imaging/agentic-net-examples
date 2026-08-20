// HOW-TO: Convert BMP to 1‑Bit Monochrome and Get Byte Array in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.bmp";
        string outputPath = @"C:\Temp\output_converted.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Optionally, perform conversion or processing here
                // For example, convert to a 1‑bit monochrome BMP
                BmpImage bmpImage = (BmpImage)image;
                bmpImage.BinarizeOtsu();

                // Prepare BMP save options (monochrome palette)
                BmpOptions saveOptions = new BmpOptions
                {
                    Palette = ColorPaletteHelper.CreateMonochrome(),
                    BitsPerPixel = 1
                };

                // Save the converted image to a file
                image.Save(outputPath, saveOptions);

                // Save the converted image to a memory stream to obtain a byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, saveOptions);
                    byte[] imageBytes = ms.ToArray();

                    // The byte array can now be used for storage or transmission
                    Console.WriteLine($"Converted image byte size: {imageBytes.Length}");
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
 * 1. When you need to store a processed 1‑bit BMP in a database as a binary blob.
 * 2. When you must send a monochrome BMP over a network API that accepts byte arrays.
 * 3. When you want to embed a small black‑and‑white image into a PDF or email attachment without writing a temporary file.
 * 4. When you are building a thumbnail service that converts high‑resolution BMPs to low‑size 1‑bit images for caching.
 * 5. When you need to apply Otsu binarization to a BMP and immediately use the resulting bytes for further image analysis in memory.
 */
