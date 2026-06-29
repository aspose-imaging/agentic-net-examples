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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify each input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image, apply Emboss5x5 filter, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
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
 * 1. When a developer needs to batch‑process a folder of PNG product photos to add an embossed look for an online catalog, they can use this C# Aspose.Imaging code to apply the Emboss5x5 filter to every image automatically.
 * 2. When a game studio wants to generate stylized terrain textures from source PNG assets, the code can quickly emboss each tile in bulk, saving manual editing time.
 * 3. When a document‑scanning workflow requires pre‑enhancing scanned PNG pages with edge‑highlighting before OCR, the batch filter applies a consistent emboss effect across all pages.
 * 4. When a marketing team needs to create embossed thumbnail previews for a series of PNG banners, the script processes the entire folder and outputs ready‑to‑use images.
 * 5. When an e‑learning platform wants to add a subtle 3‑D emboss effect to PNG diagram assets for better visual depth, this C# routine applies the ConvolutionFilter.
 */