// HOW-TO: Batch Apply Magic Wand Mask to JPEGs in Subfolders Using C# (Aspose.Imaging for .NET)
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
        try
        {
            // Hardcoded input and output directories
            string inputRoot = @"C:\Images\Input";
            string outputRoot = @"C:\Images\Output";

            // Get all JPEG files in subfolders
            string[] jpegFiles = Directory.GetFiles(inputRoot, "*.jpg", SearchOption.AllDirectories);

            foreach (string inputPath in jpegFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine relative path and corresponding output path
                string relativePath = Path.GetRelativePath(inputRoot, inputPath);
                string outputPath = Path.Combine(outputRoot, relativePath);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Create a mask using MagicWandTool with a default point and threshold
                    // (adjust the point and threshold as needed for your use case)
                    var settings = new MagicWandSettings(10, 10) { Threshold = 100 };
                    ImageBitMask mask = MagicWandTool.Select(image, settings);

                    // Apply the mask to the image
                    mask.Apply();

                    // Save the masked image as JPEG
                    image.Save(outputPath, new JpegOptions());
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
 * 1. When you need to automatically remove backgrounds from a large collection of JPEG photos stored in nested folders.
 * 2. When you want to generate consistent masked versions of product images for an e‑commerce catalog without manually editing each file.
 * 3. When you are preparing training data for a computer‑vision model and must apply the same threshold‑based selection to every image in a dataset.
 * 4. When you must preserve the original folder hierarchy while saving processed images to a separate output directory.
 * 5. When you require a C# solution that leverages Aspose.Imaging’s MagicWandTool to batch‑process images with a custom threshold.
 */
