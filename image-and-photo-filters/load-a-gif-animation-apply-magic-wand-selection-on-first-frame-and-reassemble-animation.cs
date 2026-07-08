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
        string inputPath = "input\\Animation.gif";
        string outputPath = "output\\Result.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the animated GIF
            using (GifImage gifImage = (GifImage)Image.Load(inputPath))
            {
                // Proceed only if the GIF has at least one frame
                if (gifImage.PageCount > 0)
                {
                    // Access the first frame as a RasterImage
                    RasterImage firstFrame = (RasterImage)gifImage.Pages[0];

                    // Apply Magic Wand selection on a sample point (10,10) with default settings
                    MagicWandTool
                        .Select(firstFrame, new MagicWandSettings(10, 10))
                        .Apply();
                }

                // Save the modified animation
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
 * 1. When a developer needs to programmatically remove a solid‑color background from the first frame of an animated GIF before re‑saving the animation for web use.
 * 2. When a developer wants to isolate a specific object in the initial frame of a GIF using the Magic Wand tool to create a mask that can be applied to subsequent frames.
 * 3. When a developer must batch‑process animated GIFs to select and highlight a region (e.g., a logo) on the first frame for branding or watermarking purposes.
 * 4. When a developer is building an image‑editing feature that lets users click a point (10,10) on the first frame of a GIF and automatically selects contiguous pixels of similar color for further manipulation.
 * 5. When a developer needs to load a GIF, apply a Magic Wand selection to the first frame to generate a selection path, and then save the modified animation without altering the frame order or timing.
 */