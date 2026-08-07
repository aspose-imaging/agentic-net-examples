using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image img = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Rotate method
                if (img is RasterImage rasterImage)
                {
                    // Rotate 45 degrees, resize canvas to fit, fill background with white
                    rasterImage.Rotate(45f, true, Color.White);

                    // Save the rotated image
                    rasterImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                }
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors and report them
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to automatically rotate user‑uploaded BMP screenshots by 45 degrees and fill the empty corners with a white background before saving them to disk.
 * 2. When a batch‑processing tool must re‑orient legacy BMP assets for a game’s UI, applying a 45° rotation and preserving image dimensions by expanding the canvas with white fill using C# and Aspose.Imaging.
 * 3. When an automated report generator creates BMP charts that must be displayed at a diagonal angle, requiring a 45‑degree rotation with white background padding and saving the result as a new BMP file.
 * 4. When a document‑conversion service receives BMP images and needs to correct their orientation by rotating them 45 degrees while ensuring the background remains white to meet publishing standards.
 * 5. When a Windows service monitors a folder of BMP scans and needs to rotate each image 45 degrees, resize the canvas to fit, fill the new area with white, and store the processed files for downstream processing.
 */