using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "templates/input.png";
        string outputPath = "output/output.png";

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
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply the predefined Emboss3x3 convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a developer wants to add a classic emboss effect to a product photo stored as a PNG in a templates folder before publishing it on an e‑commerce site.
 * 2. When an application needs to automatically generate stylized thumbnails for user‑uploaded PNG images by applying a 3×3 emboss convolution filter.
 * 3. When a batch‑processing tool must convert scanned PNG documents into a raised‑relief look for print‑ready PDFs, using Aspose.Imaging’s ConvolutionFilter.
 * 4. When a game asset pipeline requires pre‑processing of PNG sprites with an emboss effect to create depth cues without manual Photoshop work.
 * 5. When a reporting service has to embed an embossed PNG logo into generated PDFs, applying the filter at runtime to ensure consistent visual branding.
 */