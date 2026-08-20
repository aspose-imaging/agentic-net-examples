// HOW-TO: Apply 5x5 Blur Box Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hard‑coded input and output paths.
            string inputPath = Path.Combine("templates", "input.png");
            string outputPath = Path.Combine("output", "blurred.png");

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities.
                RasterImage rasterImage = (RasterImage)image;

                // Apply a 5×5 blur box filter.
                // Aspose.Imaging does not provide a dedicated box filter, but a Gaussian blur with
                // a radius of 5 approximates a 5×5 blur effect.
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the processed image.
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
 * 1. When you need to soften edges of a PNG thumbnail before displaying it in a web gallery.
 * 2. When you want to reduce noise in a scanned PNG document by applying a small blur.
 * 3. When you are preparing product images for a mobile app and require a uniform 5×5 blur effect.
 * 4. When you need to create a background blur for overlay graphics in a PNG asset pipeline.
 * 5. When you are building an automated image‑processing service that must read PNG files, apply a box‑style blur, and save the result.
 */
