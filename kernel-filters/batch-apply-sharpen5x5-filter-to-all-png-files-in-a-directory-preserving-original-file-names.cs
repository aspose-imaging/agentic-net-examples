// HOW-TO: Batch Sharpen PNG Images with 5x5 Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output directories
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
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

                // Preserve original file name for the output
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply the 5x5 sharpen kernel, and save it
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply the Sharpen5x5 convolution kernel to the whole image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Sharpen5x5));

                    // Save the processed image using the same file name
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
 * 1. When you need to automatically enhance the sharpness of a large set of product photos stored as PNG files before uploading them to an e‑commerce site.
 * 2. When a desktop application must process scanned documents in PNG format and apply a 5×5 sharpening kernel to improve readability without changing the original file names.
 * 3. When a game‑development pipeline requires batch sharpening of texture atlases saved as PNGs while keeping the naming convention for asset management.
 * 4. When a photo‑editing tool wants to apply a consistent sharpen effect to all user‑selected PNG images and save the results in a separate output folder.
 * 5. When an automated build script has to improve the visual quality of PNG icons using Aspose.Imaging’s convolution filter while preserving the original filenames for version control.
 */
