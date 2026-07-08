using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tga";
        string outputPath = @"C:\Images\output.png";

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
            // Load the TGA image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Define circle parameters (centered in the image, radius 100)
                int radius = 100;
                int centerX = image.Width / 2;
                int centerY = image.Height / 2;

                // Create a circular mask
                CircleMask mask = new CircleMask(centerX, centerY, radius);

                // Apply the mask to the image (makes pixels outside the circle transparent)
                mask.ApplyTo(image);

                // Crop to the bounding rectangle of the circle
                Rectangle cropRect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                image.Crop(cropRect);

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
 * 1. When a game developer needs to convert legacy TGA sprite sheets into circular PNG icons for UI overlays, they can use this code to mask and crop the image.
 * 2. When a graphics pipeline requires generating round thumbnails from high‑resolution TGA textures for product catalogs, the snippet creates a transparent PNG thumbnail of a fixed 100‑pixel radius.
 * 3. When an e‑learning platform wants to display circular profile pictures derived from TGA assets, this C# routine masks the image and saves it as a web‑friendly PNG.
 * 4. When a scientific visualization tool must extract a circular region of interest from a TGA microscopy image and export it as a lossless PNG for publication, the code performs the cropping and format conversion.
 * 5. When a desktop application needs to batch‑process TGA logos into circular PNG badges with a consistent radius for branding, this example shows the necessary Aspose.Imaging operations.
 */