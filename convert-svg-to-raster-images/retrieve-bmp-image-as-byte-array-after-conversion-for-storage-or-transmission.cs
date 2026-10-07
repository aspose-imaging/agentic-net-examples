// HOW-TO: Convert BMP to PNG and Get Byte Array in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversionApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.bmp";
                string outputPath = "output.png";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Convert to PNG and retrieve byte array
                    using (var memoryStream = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        image.Save(memoryStream, pngOptions);
                        byte[] pngBytes = memoryStream.ToArray();

                        // Save PNG bytes to output file (optional, for verification)
                        File.WriteAllBytes(outputPath, pngBytes);

                        // At this point pngBytes contains the converted image data
                        // It can be used for storage or transmission as needed
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to store a converted PNG image in a database as a binary blob instead of a file on disk.
 * 2. When you want to send a PNG image over a network or API without writing it to the filesystem first.
 * 3. When you must embed a converted image into a JSON payload for a web service call.
 * 4. When you are processing user‑uploaded BMP files and need the PNG data in memory for further manipulation.
 * 5. When you are generating thumbnails on the fly and need the PNG byte array for caching or streaming.
 */
