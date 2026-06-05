using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the drawing image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

                // Apply Sharpen filter with kernel size 5 and sigma 4.0
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the result as PNG, preserving original brightness
                PngOptions options = new PngOptions();
                rasterImage.Save(outputPath, options);
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
 * 1. When a developer needs to enhance the edges of a scanned technical drawing saved as PNG without altering its overall brightness, they can load the image with Aspose.Imaging, apply a 5x5 Sharpen filter, and save the result.
 * 2. When an automated batch process must improve the clarity of architectural blueprint images before archiving them, the code can read each PNG, sharpen it using a 5‑pixel kernel, and write the output while keeping the original luminance.
 * 3. When a web application generates preview thumbnails of user‑uploaded vector illustrations and wants to make fine details more visible, the developer can use this C# snippet to apply a Sharpen5x5 filter and preserve the original brightness.
 * 4. When a document management system needs to preprocess engineering schematics for OCR by sharpening the lines without brightening the background, the code demonstrates how to load, filter, and save PNG files with Aspose.Imaging.
 * 5. When a desktop utility aims to improve the visual quality of hand‑drawn sketches stored as PNG files while ensuring the colors remain unchanged, the developer can employ this raster image filtering approach in C#.
 */