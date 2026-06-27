using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\document.png";
            string outputPath = "output\\document_blur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, apply Gaussian blur, and save the result
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
 * 1. When a developer needs to preprocess scanned PNG documents with a Gaussian blur filter in C# before sending them to an OCR engine to reduce noise and improve text recognition accuracy.
 * 2. When an application must automatically enhance low‑quality JPEG images of receipts by applying a 5‑pixel radius Gaussian blur using Aspose.Imaging before extracting data with OCR.
 * 3. When a batch processing service reads image files from a folder, applies a Gaussian blur filter to each raster image, and saves the blurred versions to a separate output directory for downstream document analysis.
 * 4. When a .NET solution integrates Aspose.Imaging to clean up scanned PDFs converted to PNG pages, using the GaussianBlurFilterOptions to smooth edges and improve subsequent OCR results.
 * 5. When a developer wants to ensure the output directory exists, verify the input image path, and safely apply a Gaussian blur filter to a raster image in a try‑catch block before performing automated text extraction.
 */