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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_embossed.png");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply Emboss5x5 filter, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Emboss5x5 convolution filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                    // Save the processed image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to automatically add a stylized emboss effect to a large collection of PNG assets for a game’s UI, they can use this script to batch‑process the images with Aspose.Imaging’s Emboss5x5 convolution filter.
 * 2. When a web application must generate embossed thumbnails for user‑uploaded PNG photos before publishing them to a gallery, the code provides a fast C# solution to apply the filter to every file in a folder.
 * 3. When a marketing team wants to create a consistent embossed look for product PNG images across a catalog without manually editing each file, a developer can run this batch filter to transform all images in one step.
 * 4. When an automated build pipeline needs to preprocess PNG textures by applying a 5×5 emboss convolution for visual consistency in a simulation, the script can be integrated to process the directory during the CI process.
 * 5. When a developer is building a desktop utility that enhances PNG screenshots with a subtle 3‑D emboss effect for documentation purposes, this code demonstrates how to load, filter, and save each image programmatically.
 */