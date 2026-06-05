using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in subfolders
            string[] files = Directory.GetFiles(inputDirectory, "*.png", SearchOption.AllDirectories);

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load image
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    // Apply Emboss5x5 convolution filter
                    var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5;
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    // Prepare output path
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileName + "_embossed.png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
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
 * 1. When a developer needs to automatically add an embossed effect to a large collection of product photos stored as PNG files across multiple subfolders before uploading them to an e‑commerce site.
 * 2. When a batch image‑processing pipeline must convert scanned PNG documents into stylized embossed graphics for a digital archive or printing workflow.
 * 3. When a game‑asset pipeline requires applying a uniform emboss filter to all PNG texture files in a directory tree to create a consistent visual style for UI elements.
 * 4. When a content‑management system needs to generate embossed thumbnails from user‑uploaded PNG images located in nested folders for faster preview rendering.
 * 5. When a developer wants to preprocess PNG icons in a multi‑level folder structure with a convolution Emboss5x5 filter before embedding them into a Windows desktop application.
 */