using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output\\output.bmp";

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

            // Load the BMP image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using MagicWandTool with a low threshold (e.g., 10)
                // Reference point (50,50) is arbitrary; adjust as needed for the target region
                MagicWandTool
                    .Select(image, new MagicWandSettings(50, 50) { Threshold = 10 })
                    .Apply();

                // Save the resulting image (preserving BMP format)
                image.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to extract a small, uniformly colored logo from a legacy BMP file to reuse it in a branding toolkit, the low‑threshold MagicWand mask isolates the exact region.
 * 2. When an automated quality‑control system must isolate tiny defects on a printed‑circuit‑board scan saved as BMP to flag them for review, the code creates a precise color mask around the defect.
 * 3. When a game‑asset pipeline requires cutting out exact character silhouettes from BMP sprites to generate masks for collision detection, the MagicWandSettings with a low threshold provides the needed precision.
 * 4. When a medical‑imaging application has to separate a specific stained region in a BMP microscopy slide for quantitative analysis, the low‑threshold mask isolates that region without affecting surrounding tissue.
 * 5. When a document‑archiving tool must remove a watermark that occupies a narrow color range in a BMP scan without altering surrounding content, the code’s precise color mask makes the removal possible.
 */