using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of PNG files to process
            string[] pngFiles = new[]
            {
                "image1.png",
                "image2.png",
                "image3.png"
            };

            foreach (string fileName in pngFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".svg");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filter
                    if (image is RasterImage rasterImage)
                    {
                        // Apply sharpening filter to the whole image
                        rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
                    }

                    // Save as SVG using default SvgOptions
                    image.Save(outputPath, new SvgOptions());
                }
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
 * 1. When a developer needs to batch‑process a set of PNG assets, sharpen their details, and generate scalable SVG versions for responsive web design.
 * 2. When an e‑commerce platform must improve product photo clarity by applying a sharpening filter to multiple PNG thumbnails before converting them to SVG icons for faster page loads.
 * 3. When a GIS application requires converting high‑resolution PNG map tiles into sharpened SVG vectors to maintain visual quality at any zoom level.
 * 4. When an automated build pipeline has to transform a collection of PNG UI mockups into sharpened SVG graphics for inclusion in a cross‑platform mobile app.
 * 5. When a digital publishing workflow needs to enhance the sharpness of scanned PNG illustrations and export them as SVG files for print‑ready, resolution‑independent layouts.
 */