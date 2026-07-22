using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    // Hard‑coded paths – no argument validation
    private const string InputPath = @"C:\temp\sample.bmp";
    private const string OutputPath = @"C:\temp\output.png";

    static void Main()
    {
        try
        {
            // Verify input file exists
            if (!File.Exists(InputPath))
            {
                Console.Error.WriteLine($"File not found: {InputPath}");
                return;
            }

            // Ensure output directory exists (even though we save to a stream)
            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));

            // Process the image and obtain the result as a byte array
            byte[] result = ProcessImageToByteArray(InputPath);

            // Example usage: write the size of the resulting byte array
            Console.WriteLine($"Resulting image byte array length: {result.Length}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Loads the image, applies a simple filter, saves to a MemoryStream and returns the bytes
    private static byte[] ProcessImageToByteArray(string inputPath)
    {
        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Example filter – rotate the image 180 degrees
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            // Prepare PNG save options (default settings are sufficient)
            PngOptions pngOptions = new PngOptions();

            // Save the processed image to a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, pngOptions);
                // Return the underlying byte array
                return ms.ToArray();
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web API receives a BMP file, rotates it 180° using Aspose.Imaging, and needs to return the processed PNG as a byte array without writing to disk.
 * 2. When a background service creates rotated PNG thumbnails from legacy bitmap images and stores the resulting byte arrays directly in a database.
 * 3. When a desktop C# application wants to preview a rotated image in memory before allowing the user to save the PNG file to a chosen location.
 * 4. When a cloud function converts uploaded BMP files to PNG format, applies a rotation filter, and streams the byte array to an image‑recognition pipeline that consumes raw bytes.
 * 5. When a unit test verifies that the image‑processing routine correctly rotates a BMP and produces a PNG byte array of the expected size, avoiding temporary file I/O.
 */