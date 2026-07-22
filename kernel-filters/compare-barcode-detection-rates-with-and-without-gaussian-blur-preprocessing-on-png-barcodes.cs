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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG barcode images and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load original image
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    // Save original for detection without blur
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string originalOutputPath = Path.Combine(outputDirectory, fileName + "_original.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(originalOutputPath));
                    raster.Save(originalOutputPath, new PngOptions());

                    // Apply Gaussian blur
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save blurred image
                    string blurredOutputPath = Path.Combine(outputDirectory, fileName + "_blurred.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(blurredOutputPath));
                    raster.Save(blurredOutputPath, new PngOptions());
                }

                // Placeholder for barcode detection logic
                Console.WriteLine($"Processed {Path.GetFileName(inputPath)}: original and blurred images saved.");
            }

            Console.WriteLine("Processing completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to evaluate how applying a Gaussian blur filter changes the detection success rate of PNG barcodes in a batch processing workflow.
 * 2. When a quality‑control system must compare barcode read accuracy before and after a 5‑pixel radius Gaussian blur to determine the optimal preprocessing parameters.
 * 3. When integrating Aspose.Imaging into a C# application that automatically saves both the original and blurred PNG barcode images for audit and debugging purposes.
 * 4. When testing the robustness of a barcode scanner against low‑contrast or noisy PNG barcodes by programmatically blurring the images and measuring detection performance.
 * 5. When building a CI/CD test suite that validates barcode detection reliability does not degrade after image‑enhancement steps such as Gaussian blur using Aspose.Imaging’s Filter method.
 */