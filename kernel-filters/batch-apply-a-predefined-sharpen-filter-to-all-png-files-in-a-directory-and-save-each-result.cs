using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply the sharpen filter (kernel size 5, sigma 4.0)
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Build the output file path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".sharpened.png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image
                    rasterImage.Save(outputPath);
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
 * 1. When a developer needs to automatically enhance the visual clarity of a large collection of product photos stored as PNG files before uploading them to an e‑commerce website, they can use this code to batch apply a sharpen filter with Aspose.Imaging in C#.
 * 2. When a photo‑editing tool must prepare a set of PNG screenshots for a software manual by increasing edge definition without manual intervention, the code provides a repeatable C# solution that processes an entire folder.
 * 3. When a digital asset management system requires periodic sharpening of newly imported PNG graphics to improve print quality, this script can be scheduled to run on the server and save the sharpened versions to an output directory.
 * 4. When a developer is building a CI/CD pipeline that validates image assets and needs to automatically apply a predefined sharpening filter to every PNG in a repository before packaging, the example demonstrates how to integrate Aspose.Imaging filtering into the build process.
 * 5. When a content‑creation workflow involves converting raw PNG illustrations into web‑ready images with enhanced detail, the code enables batch processing of the source folder and saves the sharpened PNGs to a separate output location.
 */