using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDir = @"C:\Images\Input";
        string outputDir = @"C:\Images\Output";

        try
        {
            // Get all PNG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.png");

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_motion.png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply the Motion Wiener filter, and save the result
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access the Filter method
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply MotionWienerFilterOptions: size=10, sigma=1.0, angle=90.0
                    var options = new MotionWienerFilterOptions(10, 1.0, 90.0);
                    rasterImage.Filter(rasterImage.Bounds, options);

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
 * 1. When a developer needs to automatically clean up a large collection of low‑light PNG photos taken with a shaky camera, they can use this C# code with Aspose.Imaging to batch apply a Motion Wiener filter and remove motion artifacts.
 * 2. When an image‑processing pipeline must convert raw surveillance PNG frames captured at night into clearer visuals, the code provides a simple way to filter each frame and save the enhanced results.
 * 3. When a photo‑editing application requires a one‑click “reduce motion blur” feature for user‑uploaded PNGs, the developer can integrate this loop to process all selected files on the server side.
 * 4. When a scientific research project collects PNG microscopy images under dim lighting and needs consistent de‑blurring across dozens of files, the script automates the filter application using RasterImage and MotionWienerFilterOptions.
 * 5. When a batch‑export tool for a mobile app must improve the quality of exported PNG screenshots taken in low‑light conditions, this C# example shows how to iterate through a folder, apply the filter, and store the corrected images.
 */