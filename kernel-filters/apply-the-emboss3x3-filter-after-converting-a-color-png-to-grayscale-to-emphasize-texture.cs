using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.png";
            string outputPath = "Output/sample_embossed.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel operations
                RasterImage raster = (RasterImage)image;

                // Convert to grayscale
                raster.Grayscale();

                // Apply Emboss3x3 filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the processed image as PNG
                using (PngOptions options = new PngOptions())
                {
                    raster.Save(outputPath, options);
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
 * 1. When a developer wants to convert a color PNG into a high‑contrast grayscale image and highlight surface details for a product catalog, they can use this code to apply the Emboss3x3 convolution filter.
 * 2. When building a C# desktop application that prepares scanned documents for OCR by emphasizing texture and removing color, the code shows how to load a PNG, grayscale it, and emboss it with Aspose.Imaging.
 * 3. When creating a web service that generates stylized thumbnails of user‑uploaded PNG photos, the developer can employ this snippet to produce a grayscale embossed preview that stands out visually.
 * 4. When automating a batch process that converts color PNG assets into grayscale textures for a game engine, the code demonstrates how to apply the Emboss3x3 filter to enhance depth perception.
 * 5. When developing a scientific imaging tool that needs to accentuate fine grain patterns in PNG microscopy images, the example provides the exact C# steps to grayscale the image and apply a 3×3 emboss convolution using Aspose.Imaging.
 */