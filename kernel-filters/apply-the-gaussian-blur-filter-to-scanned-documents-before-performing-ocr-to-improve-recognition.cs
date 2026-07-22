using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\scanned.png";
        string outputPath = "Output\\scanned_blurred.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image and apply Gaussian blur
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputPath);
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
 * 1. When a developer needs to improve OCR results by applying a Gaussian blur filter to scanned PNG images using Aspose.Imaging in a C# application.
 * 2. When building an automated document preprocessing step that verifies the input file, creates the output directory, and blurs the image to reduce scanning artifacts before text extraction.
 * 3. When integrating image preprocessing into a batch processing job that loads each scanned image, applies a 5‑pixel radius Gaussian blur with a sigma of 4.0, and saves the blurred PNG for further analysis.
 * 4. When creating a C# utility that prepares noisy scanned documents for machine learning models by smoothing the raster image with Aspose.Imaging’s GaussianBlurFilterOptions.
 * 5. When developing a Windows service that monitors a folder, loads new scanned PNG files, applies Gaussian blur to enhance readability, and stores the processed images in an output directory for downstream OCR pipelines.
 */