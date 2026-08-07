using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.gif";
            string outputPath = @"C:\temp\sample.adjusted.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Apply gamma correction with a coefficient of 1.5
                gifImage.AdjustGamma(1.5f);

                // Save the modified image as a new GIF
                gifImage.Save(outputPath, new GifOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to improve the brightness and contrast of an animated GIF for a web banner by applying a gamma correction of 1.5 and saving the result as a new GIF file.
 * 2. When a C# application must preprocess user‑uploaded GIFs to ensure consistent visual appearance across different browsers by adjusting gamma before storing them.
 * 3. When an image‑processing pipeline uses Aspose.Imaging to batch‑process GIF assets for a mobile game, increasing gamma to 1.5 to make colors pop on low‑light screens.
 * 4. When a developer wants to create a lighter version of an existing GIF for email newsletters, applying gamma correction with Aspose.Imaging and saving the adjusted frame as a separate GIF.
 * 5. When a .NET service automatically generates thumbnails from GIF animations and needs to enhance their visual quality by adjusting gamma to 1.5 before delivering the new GIF to clients.
 */