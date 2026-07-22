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
        string inputPath = @"C:\Images\sample.tga";
        string outputPath = @"C:\Images\sample_cropped.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TGA image as a raster image
            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                // Determine the center of the image
                int centerX = rasterImage.Width / 2;
                int centerY = rasterImage.Height / 2;
                int radius = 100; // Desired radius

                // Create a circular mask with the specified center and radius
                var circleMask = new CircleMask(centerX, centerY, radius);

                // Apply the mask to the raster image (makes pixels outside the circle transparent)
                circleMask.ApplyTo(rasterImage);

                // Save the resulting image as PNG
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
 * 1. When a game developer needs to extract a circular avatar from a high‑resolution TGA sprite sheet and export it as a transparent PNG for use in UI overlays.
 * 2. When a graphics pipeline requires converting legacy TGA textures into PNG thumbnails with a fixed 100‑pixel radius circular crop for preview generation.
 * 3. When an e‑commerce platform wants to display product logos stored as TGA files as round icons on a web page, needing C# code that masks and saves them as PNG with transparency.
 * 4. When a scientific imaging application must isolate a circular region of interest from a TGA microscopy image and store the result as a lossless PNG for further analysis.
 * 5. When a mobile app developer needs to create circular profile pictures from TGA assets, using Aspose.Imaging’s CircleMask in C# to produce PNG files that retain transparent backgrounds.
 */