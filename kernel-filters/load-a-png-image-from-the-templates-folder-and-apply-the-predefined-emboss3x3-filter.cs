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
            string inputPath = "templates/sample.png";
            string outputPath = "output/sample_embossed.png";

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
                RasterImage raster = (RasterImage)image;

                // Apply the predefined Emboss3x3 convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the processed image as PNG
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
 * 1. When a developer needs to generate a stylized preview of product photos by embossing PNG thumbnails for an e‑commerce catalog.
 * 2. When an application must automatically add a 3‑x‑3 emboss effect to user‑uploaded PNG avatars before storing them in a cloud repository.
 * 3. When a reporting tool requires converting scanned PNG diagrams into embossed images to enhance edge contrast for printed PDFs.
 * 4. When a game asset pipeline needs to preprocess PNG textures with an emboss filter to create depth cues for UI elements.
 * 5. When a document generation service wants to apply a predefined Emboss3x3 convolution filter to PNG logos to give them a raised‑look in generated invoices.
 */