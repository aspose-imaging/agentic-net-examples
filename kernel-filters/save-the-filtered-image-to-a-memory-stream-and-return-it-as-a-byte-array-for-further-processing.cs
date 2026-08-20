// HOW-TO: Convert BMP to Rotated PNG and Get Byte Array in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Process the image and obtain the byte array
            byte[] imageBytes = ProcessImage(inputPath, outputPath);

            // Example usage of the returned byte array
            Console.WriteLine($"Resulting byte array length: {imageBytes.Length}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] ProcessImage(string inputPath, string outputPath)
    {
        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Example filter: rotate the image 180 degrees
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            // Prepare PNG save options (default settings)
            PngOptions pngOptions = new PngOptions();

            // Save to the specified file path
            image.Save(outputPath, pngOptions);

            // Save to a memory stream and return as byte array
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, pngOptions);
                return ms.ToArray();
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to rotate an uploaded BMP image 180° and store the result as a PNG file on disk while also sending the image data over a web API.
 * 2. When a desktop application must convert user‑selected bitmap files to PNG format and keep the image in memory for further processing such as thumbnail generation.
 * 3. When an automated batch job processes a folder of BMP images, applies a rotation, saves the transformed PNGs, and passes the byte arrays to another service for storage in a database.
 * 4. When you want to display a rotated PNG in a UI component that requires the image as a byte[] rather than a file path.
 * 5. When integrating with a cloud function that expects image data as a byte array after applying simple transformations like rotate‑flip.
 */
