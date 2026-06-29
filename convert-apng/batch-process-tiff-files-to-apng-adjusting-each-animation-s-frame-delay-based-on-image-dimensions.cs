using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image (may contain multiple frames)
                using (Image image = Image.Load(inputPath))
                {
                    // Calculate frame delay based on image dimensions (minimum 10 ms)
                    uint frameDelay = (uint)Math.Max(10, (image.Width + image.Height) / 2);

                    // Save as APNG with the calculated default frame time
                    image.Save(outputPath, new ApngOptions() { DefaultFrameTime = frameDelay });
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
 * 1. When a developer needs to batch‑convert a collection of multi‑page TIFF scans into animated PNGs for a web gallery, automatically setting each animation’s frame delay based on the image dimensions.
 * 2. When an image‑processing pipeline must generate APNG previews from high‑resolution TIFF files and ensure larger images display longer per‑frame by calculating a minimum delay from width and height.
 * 3. When a C# application processes satellite or aerial TIFF mosaics in bulk and outputs APNG files whose frame timing is derived from the image size to keep playback smooth across varying resolutions.
 * 4. When a digital archiving system migrates legacy TIFF documents to APNG format and wants to dynamically adjust the default frame time so that bigger pages are shown longer during animation.
 * 5. When a product‑catalog generation tool needs to convert dozens of TIFF assets to APNG and automatically compute a suitable frame delay to prevent overly fast animations on high‑resolution images.
 */