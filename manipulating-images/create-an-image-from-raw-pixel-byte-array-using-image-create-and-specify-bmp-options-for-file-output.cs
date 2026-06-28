using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Raw pixel data (ARGB) for a 2x2 image
            int[] pixels = new int[]
            {
                unchecked((int)0xFFFF0000), // Red
                unchecked((int)0xFF00FF00), // Green
                unchecked((int)0xFF0000FF), // Blue
                unchecked((int)0xFFFFFFFF)  // White
            };
            int width = 2;
            int height = 2;

            // BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                // Define where the image will be saved
                Source = new FileCreateSource(outputPath, false)
            };

            // Create the image from the raw pixel array
            using (Image image = Image.Create(bmpOptions, width, height, pixels))
            {
                // Save the image (writes to the path defined in Source)
                image.Save();
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
 * 1. When a developer needs to generate a 2×2 BMP thumbnail directly from a raw ARGB pixel array using Image.Create and BmpOptions in C# without loading an existing image file.
 * 2. When an application must build a custom icon or sprite sheet at runtime by converting an integer pixel buffer into a 24‑bit BMP file with FileCreateSource for immediate file output.
 * 3. When a server‑side service receives raw pixel data from a hardware device and has to save it as a BMP image using Aspose.Imaging’s Image.Create method and BMP options.
 * 4. When a unit test requires creating deterministic bitmap images from hard‑coded pixel values to verify image‑processing logic in .NET.
 * 5. When integrating with a legacy system that only accepts BMP files with specific BitsPerPixel settings, and the developer needs to construct those files directly from a pixel array using Aspose.Imaging for .NET.
 */