// HOW-TO: Batch Apply Emboss5x5 Filter To PNG Images In C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputFolder = "Input";
            string outputFolder = "Output";

            // Validate input directory
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Get all PNG files in the input folder
            string[] files = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for filtering
                    RasterImage raster = (RasterImage)image;

                    // Apply the predefined Emboss5x5 convolution filter
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                    // Prepare output path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileName(inputPath));

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as PNG
                    raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to automatically add a 3‑D emboss effect to a collection of product photos stored as PNG files before publishing them on an e‑commerce site.
 * 2. When you want to preprocess scanned documents in PNG format with an emboss filter to enhance edge details for visual inspection in a desktop application.
 * 3. When a game developer must generate stylized texture assets by applying the Emboss5x5 convolution to all PNG sprites in a folder during the build pipeline.
 * 4. When a digital archivist requires a quick way to batch‑apply an emboss effect to PNG images to improve visual contrast for archival previews.
 * 5. When an automated reporting tool needs to batch process PNG charts, adding an emboss filter to make the graphics stand out in generated PDF reports.
 */
