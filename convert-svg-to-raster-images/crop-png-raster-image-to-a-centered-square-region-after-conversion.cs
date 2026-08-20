// HOW-TO: Crop PNG Image to Centered Square Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_cropped.png";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access raster-specific methods
                RasterImage rasterImage = (RasterImage)image;

                // Determine the size of the centered square
                int side = Math.Min(rasterImage.Width, rasterImage.Height);
                int left = (rasterImage.Width - side) / 2;
                int top = (rasterImage.Height - side) / 2;

                // Define the cropping rectangle
                Rectangle cropArea = new Rectangle(left, top, side, side);

                // Perform the crop
                rasterImage.Crop(cropArea);

                // Save the cropped image
                rasterImage.Save(outputPath);
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
 * 1. When you need to generate square thumbnails from user‑uploaded PNG photos for a profile gallery.
 * 2. When preparing PNG assets for a mobile app that requires a centered square image to fit a circular avatar mask.
 * 3. When standardizing product images by cropping varied‑size PNGs to a uniform square before uploading to an e‑commerce platform.
 * 4. When creating consistent icons from larger PNG designs by extracting the central square region programmatically in C#.
 * 5. When automating batch processing of PNG screenshots to remove excess borders and keep only the central square content.
 */
