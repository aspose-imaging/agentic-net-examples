// HOW-TO: Apply 7‑Pixel Motion Blur At 30° To PNG With Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\template.png";
            string outputPath = @"C:\Images\output_motion_blur.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage raster = (RasterImage)image;

                // Apply a motion blur filter with size 7 and angle 30 degrees
                // MotionWienerFilterOptions constructor: (length, smooth, angle)
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(7, 1.0, 30.0));

                // Save the processed image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to add a realistic motion‑blur effect to a PNG template for a web banner or UI element.
 * 2. When generating a series of images that simulate camera movement, such as in a game UI or animated tutorial.
 * 3. When preprocessing product photos to create a stylized background blur before compositing them into marketing material.
 * 4. When automating the creation of motion‑blurred placeholders for loading screens in a .NET application.
 * 5. When applying consistent blur parameters to multiple PNG assets during a batch image‑processing pipeline.
 */
