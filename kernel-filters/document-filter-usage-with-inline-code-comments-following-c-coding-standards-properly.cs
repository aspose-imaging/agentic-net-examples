using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

namespace AsposeImagingFilterDemo
{
    class Program
    {
        static void Main()
        {
            // Wrap the entire processing logic in a try-catch block to handle unexpected errors gracefully.
            try
            {
                // Hard‑coded input and output file paths.
                string inputPath = @"C:\temp\sample.png";
                string outputPath = @"C:\temp\sample.SharpenFilter.png";

                // Verify that the input file exists before attempting to load it.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists; create it unconditionally.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image from disk.
                using (Image image = Image.Load(inputPath))
                {
                    // Cast the generic Image to RasterImage to gain access to filtering capabilities.
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a sharpen filter with a kernel size of 5 and a sigma value of 4.0
                    // to the entire image bounds.
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new SharpenFilterOptions(5, 4.0));

                    // Save the processed image to the specified output path.
                    rasterImage.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                // Output any runtime exception message without crashing the application.
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to automatically enhance uploaded product photos in PNG format before displaying them in an online catalog, a developer can use this code to apply a sharpen filter with a 5‑pixel kernel and sigma 4.0.
 * 2. When a desktop utility processes batches of scanned documents and wants to improve text readability by sharpening each image, the code can be integrated to load each raster image, apply the filter, and save the result.
 * 3. When a mobile backend service receives user‑generated screenshots and must improve edge definition for better OCR accuracy, developers can employ this snippet to sharpen the PNG before passing it to the OCR engine.
 * 4. When an automated reporting tool generates charts as PNG files and wants to make visual details pop on high‑resolution PDFs, the filter code can be called to sharpen the chart image before embedding it.
 * 5. When a content‑management system needs to create a sharpened preview thumbnail of a large PNG image for faster browsing, this code provides a straightforward way to load, filter, and save the processed thumbnail.
 */