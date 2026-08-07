using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\sample_embossed.png";

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

                // Save the result as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to generate a stylized preview of a product photo by converting a color PNG to grayscale and applying an Emboss3x3 filter to highlight surface texture for an e‑commerce catalog.
 * 2. When a C# application must preprocess scanned PNG documents, turning them into grayscale and embossing them to enhance fine details before optical character recognition (OCR).
 * 3. When a game asset pipeline requires converting colorful PNG textures to grayscale and adding an emboss effect to create height‑map‑like visuals for terrain shading.
 * 4. When a medical imaging tool needs to emphasize subtle patterns in grayscale PNG X‑ray images by applying a convolution Emboss3x3 filter for better visual analysis.
 * 5. When an automated reporting system generates embossed grayscale PNG charts to give printed reports a tactile‑look feel without using additional graphic software.
 */