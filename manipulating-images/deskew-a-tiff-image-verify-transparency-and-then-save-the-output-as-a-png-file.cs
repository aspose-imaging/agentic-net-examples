using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Verify transparency
                bool hasTransparency = image.HasAlpha;
                Console.WriteLine(hasTransparency
                    ? "Image has transparency."
                    : "Image does not have transparency.");

                // Deskew the image (do not resize, use light gray background)
                image.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);

                // Save the result as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to correct the orientation of scanned TIFF documents while preserving any alpha channel before converting them to PNG for web display.
 * 2. When an application must automatically detect whether a multi‑page TIFF contains transparency and then deskew each page before saving as a lossless PNG.
 * 3. When a batch‑processing service processes incoming TIFF images from a scanner, removes skew, checks for alpha transparency, and outputs PNG files for downstream image analysis.
 * 4. When a C# program integrates Aspose.Imaging to ensure scanned forms are properly aligned and retain transparent backgrounds when converting from TIFF to PNG for archival.
 * 5. When a developer wants to validate the presence of an alpha channel in a TIFF, normalize its angle using a light‑gray background, and export the result as a PNG for use in a UI component.
 */