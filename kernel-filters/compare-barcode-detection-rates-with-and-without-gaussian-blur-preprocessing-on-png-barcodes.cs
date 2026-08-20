// HOW-TO: Compare Barcode Detection With and Without Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/barcode.png";
            string outputPathBlurred = "output/barcode_blurred.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathBlurred));

            // Load the original barcode image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // TODO: Detect barcodes without preprocessing
                int detectionWithoutBlur = 0; // placeholder for detection count

                // Apply Gaussian blur preprocessing
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // TODO: Detect barcodes after Gaussian blur
                int detectionWithBlur = 0; // placeholder for detection count

                // Save the blurred image for inspection
                raster.Save(outputPathBlurred);

                // Output detection results
                Console.WriteLine($"Barcodes detected without blur: {detectionWithoutBlur}");
                Console.WriteLine($"Barcodes detected with Gaussian blur: {detectionWithBlur}");
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
 * 1. When you need to evaluate whether applying a Gaussian blur improves barcode reading accuracy on scanned PNG labels in a C# application.
 * 2. When you want to benchmark the detection count of barcodes before and after image preprocessing to choose the optimal pipeline for inventory management systems.
 * 3. When integrating Aspose.Imaging into a .NET service that processes product images and you must decide if blurring reduces noise without harming barcode recognition.
 * 4. When testing the impact of different blur radii on QR code detection rates in a quality‑control workflow that handles PNG files.
 * 5. When creating a diagnostic tool that saves both original and blurred barcode images to compare detection results for automated checkout scanners.
 */
