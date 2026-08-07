using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_restored.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a motion Wiener deconvolution filter with default parameters
                    // Length = 5, Sigma = 1.0, Angle = 0.0 (these are reasonable defaults)
                    var deconvolutionOptions = new MotionWienerFilterOptions(5, 1.0, 0.0);

                    // Apply the filter to the whole image bounds
                    rasterImage.Filter(rasterImage.Bounds, deconvolutionOptions);

                    // Save the restored image
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
 * 1. When a developer needs to automatically restore a batch of motion‑blurred PNG photos taken from a security camera by applying a Wiener deconvolution filter with default settings.
 * 2. When an image‑processing pipeline must clean up scanned document PNGs that suffer from slight motion blur before they are archived or OCR‑processed.
 * 3. When a photo‑editing application wants to offer a one‑click “Restore All” feature that deblurs all PNG files in a folder and saves the results with a “_restored” suffix.
 * 4. When a data‑science workflow requires preprocessing of a large set of PNG microscopy images to improve visual clarity using C# and Aspose.Imaging’s raster filter API.
 * 5. When a web service needs to batch‑process uploaded PNG avatars that appear blurry due to compression artifacts, applying default motion Wiener deconvolution and storing the corrected images on the server.
 */