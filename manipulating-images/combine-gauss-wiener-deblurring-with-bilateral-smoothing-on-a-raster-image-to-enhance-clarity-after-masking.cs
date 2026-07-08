using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gauss‑Wiener deblurring (radius 5, sigma 4.0)
                var gaussWienerOptions = new GaussWienerFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, gaussWienerOptions);

                // Apply Bilateral smoothing (kernel size 5)
                var bilateralOptions = new BilateralSmoothingFilterOptions(5);
                rasterImage.Filter(rasterImage.Bounds, bilateralOptions);

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to restore sharpness and reduce noise in scanned PNG documents that contain motion blur, they can use Aspose.Imaging for .NET to apply Gauss‑Wiener deblurring followed by bilateral smoothing in C#.
 * 2. When processing JPEG photos uploaded to a web service where the images are slightly out‑of‑focus, the code can automatically improve clarity while preserving edges by chaining Gauss‑Wiener and bilateral filters using RasterImage.Filter.
 * 3. When building a C# desktop application that cleans up medical X‑ray images saved as BMP files, the developer can employ this routine to deblur the image and smooth homogeneous regions without blurring important anatomical edges.
 * 4. When automating batch enhancement of satellite imagery in TIFF format before analysis, the Gauss‑Wiener deblurring and bilateral smoothing steps help remove atmospheric blur and speckle noise while keeping terrain details intact.
 * 5. When integrating an image‑preprocessing pipeline for OCR where masked regions of a scanned PDF page are extracted as PNG raster images, the code improves text legibility by deblurring and edge‑preserving smoothing before feeding the image to the recognizer.
 */