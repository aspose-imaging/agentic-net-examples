using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output\\output.gif";

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

            // Load the GIF animation
            using (GifImage gifImage = (GifImage)Image.Load(inputPath))
            {
                // Get the first frame as a RasterImage
                RasterImage firstFrame = (RasterImage)gifImage.Pages[0];

                // Apply Magic Wand selection on the first frame
                // Example: select area around pixel (50, 50) with default threshold
                MagicWandTool
                    .Select(firstFrame, new MagicWandSettings(50, 50))
                    .Apply();

                // Save the modified GIF animation
                gifImage.Save(outputPath);
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
 * 1. When a developer needs to automatically remove a background color from the first frame of a GIF animation before re‑saving it for web use, they can load the GIF, apply a Magic Wand selection, and reassemble the animation with Aspose.Imaging for .NET.
 * 2. When creating an animated sticker where only the initial frame requires a transparent cut‑out around a logo, the code can load the GIF, use the Magic Wand tool to select the logo area, and save the modified animation.
 * 3. When processing user‑uploaded GIFs to isolate a specific region in the first frame for further analysis or watermarking, developers can employ this C# snippet to load the image, perform a Magic Wand selection, and preserve the animation.
 * 4. When optimizing a GIF for mobile devices by trimming unwanted pixels from the first frame using a threshold‑based Magic Wand selection, the code demonstrates how to load, edit, and re‑save the animation efficiently.
 * 5. When building a batch‑processing pipeline that needs to apply consistent region‑based edits to the first frame of multiple GIF files, this example shows how to load each GIF, apply the Magic Wand selection in C#, and reassemble the animation for output.
 */