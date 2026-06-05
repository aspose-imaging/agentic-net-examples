using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\source.tif";
            string outputPath = @"C:\Images\result.png";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image (which may contain embedded EMF data)
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with vector rasterization.
                // EmfRasterizationOptions will rasterize vector content (including EMF)
                // while preserving text as shapes.
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Color.White,
                        RenderMode = EmfRenderMode.Auto
                    }
                };

                // Save the result as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert multi‑page TIFF documents that embed EMF graphics into high‑resolution PNGs while preserving the original text as scalable vector shapes for printing or web display.
 * 2. When an application must extract embedded EMF annotations from scanned TIFF files and render them as crisp PNG thumbnails without losing vector quality.
 * 3. When a reporting tool generates TIFF images containing vector‑based charts and the developer wants to produce PNG images for inclusion in HTML emails, keeping the chart text sharp.
 * 4. When a migration script processes legacy TIFF archives with embedded EMF watermarks and needs to output PNG files that retain the watermark as vector outlines for later editing.
 * 5. When a desktop utility reads TIFF files from a scanner, rasterizes any EMF text layers using Aspose.Imaging’s EmfRasterizationOptions, and saves the result as PNG for downstream image‑analysis pipelines.
 */