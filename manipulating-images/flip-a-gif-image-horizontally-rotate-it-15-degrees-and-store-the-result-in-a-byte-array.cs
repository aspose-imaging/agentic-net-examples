// HOW-TO: Flip GIF Horizontally and Rotate 15 Degrees to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.gif";
        string outputPath = @"C:\Images\output.png";

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

            // Load the GIF image
            using (GifImage image = (GifImage)Image.Load(inputPath))
            {
                // Flip horizontally
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Rotate 15 degrees clockwise, resize proportionally, transparent background
                image.Rotate(15f, true, Color.Transparent);

                // Save to a memory stream (PNG format) and also to file
                using (var ms = new MemoryStream())
                {
                    // Save to memory stream
                    image.Save(ms, new PngOptions());

                    // Get byte array of the transformed image
                    byte[] resultBytes = ms.ToArray();

                    // Write the byte array to the output file
                    File.WriteAllBytes(outputPath, resultBytes);

                    // Optionally, you can use resultBytes further in your application
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
 * 1. When you need to mirror a GIF animation and slightly tilt it before embedding it in a web page.
 * 2. When you must convert a transformed GIF into a PNG byte array for storage in a database.
 * 3. When you want to generate a thumbnail with a horizontal flip and custom rotation for a photo‑gallery app.
 * 4. When you are preprocessing animated assets for a game and require the result as a PNG stream.
 * 5. When you need to apply a flip and rotation to a GIF on the server side and send the resulting bytes to an API client.
 */
