// HOW-TO: Rotate BMP Image 45 Degrees with White Background in C# (Aspose.Imaging for .NET)
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
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access rotation functionality
                RasterImage raster = (RasterImage)image;

                // Rotate 45 degrees clockwise, resize canvas, fill background with white
                raster.Rotate(45f, true, Color.White);

                // Save the rotated image
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
 * 1. When you need to display a scanned document at a diagonal angle in a printable report, you can rotate the BMP file 45 degrees and fill the empty canvas with white.
 * 2. When generating thumbnails for a photo gallery that require a tilted orientation, this code rotates BMP images and adds a consistent white background.
 * 3. When preparing game UI assets where icons must be slanted, you can use the routine to rotate BMP sprites and keep the surrounding area white.
 * 4. When correcting the orientation of legacy BMP scans that were saved sideways, the method rotates them 45 degrees without cropping and pads the background with white.
 * 5. When creating a batch process that adds a uniform white border after rotating BMP images for a printing workflow, this code handles the rotation and background fill automatically.
 */
