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
            // Hard‑coded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // List of blurred PNG files to process
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "blur1.png"),
                Path.Combine(inputDir, "blur2.png"),
                Path.Combine(inputDir, "blur3.png")
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output file path (same name with suffix)
                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(inputPath) + "_restored.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to use the Filter method
                    RasterImage raster = (RasterImage)image;

                    // Create deconvolution filter options with default parameters
                    // Length = 5, Sigma = 1.0, Angle = 0.0 (default values)
                    var deconvOptions = new MotionWienerFilterOptions(5, 1.0, 0.0);

                    // Apply the deconvolution filter to the whole image
                    raster.Filter(raster.Bounds, deconvOptions);

                    // Save the restored image
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
 * 1. When a developer needs to automatically restore a batch of motion‑blurred PNG photographs taken from a security camera by applying the default MotionWiener deconvolution filter in a C# application.
 * 2. When an image‑processing pipeline must clean up scanned documents that appear blurred due to scanner vibration, using Aspose.Imaging to load each PNG, apply deconvolution, and save the sharpened version.
 * 3. When a photo‑editing tool wants to provide a one‑click “restore all” feature that processes multiple PNG files in a folder, applying the default deconvolution parameters without manual user input.
 * 4. When a .NET service that archives product images needs to improve visual quality of blurred PNG assets before storage by batch applying the MotionWiener filter with default length, sigma, and angle settings.
 * 5. When a developer is building a batch conversion script that reads PNG files, removes motion blur using Aspose.Imaging’s RasterImage.Filter method, and writes the restored images to a separate output directory for downstream AI analysis.
 */