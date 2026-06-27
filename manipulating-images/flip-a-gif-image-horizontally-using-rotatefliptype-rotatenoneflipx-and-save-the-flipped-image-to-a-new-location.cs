using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.gif";
        string outputPath = @"C:\Images\sample_flipped.gif";

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
                // Flip horizontally (no rotation)
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Save the flipped image
                image.Save(outputPath);
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
 * 1. When a web developer wants to mirror an animated GIF banner for a right‑to‑left language layout, they can use Aspose.Imaging for .NET to load the GIF, apply RotateFlipType.RotateNoneFlipX, and save the flipped file.
 * 2. When a game developer needs to create a horizontally reversed sprite sheet from an existing GIF animation for character movement, the code demonstrates how to load, flip, and export the new image using C#.
 * 3. When an e‑commerce platform must generate a mirrored product preview GIF for a 360° view on the opposite side of the product, the snippet shows how to perform the flip operation with Aspose.Imaging and save it to a new path.
 * 4. When a marketing automation script has to batch‑process user‑uploaded GIFs to ensure they face the correct direction in email newsletters, this example illustrates the C# RotateFlip method for horizontal flipping.
 * 5. When a desktop application needs to correct the orientation of a GIF captured from a camera that records mirrored images, the code provides a simple way to load, flip horizontally, and store the corrected GIF using Aspose.Imaging for .NET.
 */