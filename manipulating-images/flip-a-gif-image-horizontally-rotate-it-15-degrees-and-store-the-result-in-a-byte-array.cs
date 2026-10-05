// HOW-TO: Flip GIF Horizontally and Rotate 15 Degrees to Byte Array in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                if (img is RasterImage rasterImage)
                {
                    // Flip horizontally
                    rasterImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    // Rotate 15 degrees
                    rasterImage.Rotate(15);

                    // Save to file
                    rasterImage.Save(outputPath);

                    // Save to memory and obtain byte array
                    using (var ms = new MemoryStream())
                    {
                        rasterImage.Save(ms);
                        byte[] resultBytes = ms.ToArray();
                        Console.WriteLine($"Result byte array length: {resultBytes.Length}");
                    }
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
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
 * 1. When you need to mirror a GIF for a web animation and then rotate it slightly before sending it over a network as a byte array.
 * 2. When generating custom thumbnails for user‑uploaded GIFs that require a horizontal flip and a 15‑degree tilt, stored in memory for further processing.
 * 3. When creating animated stickers where the original GIF must be flipped, rotated, and saved directly to a byte buffer for embedding in a chat app.
 * 4. When preprocessing GIF assets for a game engine that expects the image data as a byte array after applying flip and rotation transformations.
 * 5. When implementing a server‑side image service that receives a GIF, applies a horizontal flip and a small rotation, and returns the transformed image as a byte array response.
 */
