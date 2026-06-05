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
        string inputPath = "Input/sample.png";
        string outputPath = "Output/sample_embossed.png";

        try
        {
            // Verify input file exists
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
 * 1. When creating a product catalog website that needs to highlight surface texture of product photos, a developer can load a color PNG, convert it to grayscale, and apply the Emboss3x3 filter with Aspose.Imaging for .NET to generate stylized images.
 * 2. When preparing scanned documents for a digital archive where subtle embossing helps differentiate printed patterns, a C# program can convert the PNG scans to grayscale and run the Emboss3x3 convolution to enhance texture.
 * 3. When building a mobile app that offers artistic filters, a developer can use this code to transform user‑uploaded PNG images into grayscale and apply the Emboss3x3 filter to create a classic embossed effect before saving.
 * 4. When generating training data for a machine‑learning model that detects embossed patterns, a developer can programmatically convert color PNG samples to grayscale and apply the Emboss3x3 filter using Aspose.Imaging to produce labeled images.
 * 5. When automating batch processing of PNG assets for a game’s UI, a developer can employ this C# routine to grayscale each image and emboss it, ensuring consistent texture emphasis across all UI elements.
 */