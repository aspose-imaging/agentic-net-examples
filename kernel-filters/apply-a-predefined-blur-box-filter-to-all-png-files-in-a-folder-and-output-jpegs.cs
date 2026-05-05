using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all PNG files in the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a Gaussian blur filter (acts as a blur box filter)
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Prepare the output JPEG path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image as JPEG
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