using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
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

            // Load the TGA image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                RasterImage rasterImage = (RasterImage)image;

                // Determine center of the image
                int centerX = rasterImage.Width / 2;
                int centerY = rasterImage.Height / 2;
                int radius = 100;

                // Create a circular mask
                CircleMask circleMask = new CircleMask(centerX, centerY, radius);

                // Apply the mask to the raster image (makes outside area transparent)
                circleMask.ApplyTo(rasterImage);

                // Save the result as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a game developer needs to extract a circular avatar from a high‑resolution TGA texture and save it as a transparent PNG for UI overlays.
 * 2. When a scientific imaging application must isolate a circular region of interest from a TGA microscopy image and export it as a PNG for reporting.
 * 3. When a web service processes user‑uploaded TGA logos, crops them to a 100‑pixel radius circle, and returns PNG files for website branding.
 * 4. When an e‑learning platform converts legacy TGA diagrams into circular PNG icons to fit within course thumbnails.
 * 5. When a desktop utility batch‑processes TGA screenshots, applying a circular mask of radius 100 pixels and saving the results as PNGs for social media sharing.
 */