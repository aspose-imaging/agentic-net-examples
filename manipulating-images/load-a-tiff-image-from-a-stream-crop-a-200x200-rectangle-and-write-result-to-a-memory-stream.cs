// HOW-TO: Crop A 200x200 Area From A TIFF And Get PNG In Memory C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input file path
            string inputPath = "input.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (Image image = Image.Load(inputStream))
            {
                // Cast to TiffImage to access TIFF-specific methods
                TiffImage tiffImage = (TiffImage)image;

                // Define a 200x200 rectangle starting at the top‑left corner
                Rectangle cropArea = new Rectangle(0, 0, 200, 200);

                // Crop the image
                tiffImage.Crop(cropArea);

                // Save the cropped image to a memory stream (PNG format used as an example)
                using (MemoryStream outputStream = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    tiffImage.Save(outputStream, pngOptions);

                    // The memory stream now contains the cropped image data
                    // For demonstration, output the size of the resulting stream
                    Console.WriteLine($"Cropped image size in bytes: {outputStream.Length}");
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
 * 1. When you need to extract a thumbnail from a large multi‑page TIFF without writing intermediate files.
 * 2. When a web service must return a cropped portion of a TIFF as a PNG byte array.
 * 3. When processing scanned documents and you want to isolate a specific 200 × 200 region for OCR.
 * 4. When generating preview images for a PDF generator that only accepts PNG data from a memory stream.
 * 5. When building a Windows desktop app that loads TIFFs from a network stream, crops them, and displays the result directly from memory.
 */
