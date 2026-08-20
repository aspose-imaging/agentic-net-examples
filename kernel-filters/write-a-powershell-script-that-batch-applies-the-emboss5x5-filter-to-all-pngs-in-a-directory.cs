// HOW-TO: Batch Apply Emboss5x5 Filter to PNG Images with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "Input";
            string outputDir = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.png");
            foreach (string inputPath in files)
            {
                // Verify each input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_embossed.png");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply Emboss5x5 filter, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                    raster.Save(outputPath);
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
 * 1. When you need to add a 3‑D emboss effect to a large set of product photos stored as PNG files before uploading them to an e‑commerce site.
 * 2. When you want to automatically preprocess scanned documents by applying an emboss filter to enhance edge details for OCR preprocessing.
 * 3. When a game developer must generate stylized texture assets by embossing multiple PNG sprites in a build pipeline.
 * 4. When a marketing team requires a quick way to create embossed versions of logo PNGs for promotional graphics without manual editing.
 * 5. When a desktop application needs to batch convert user‑selected PNG images into embossed variants for a photo‑editing feature.
 */
