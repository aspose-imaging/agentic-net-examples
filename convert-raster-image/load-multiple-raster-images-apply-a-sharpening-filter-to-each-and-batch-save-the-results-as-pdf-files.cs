using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.png",
                @"C:\Images\input2.jpg",
                @"C:\Images\input3.bmp"
            };

            string[] outputPaths = new string[]
            {
                @"C:\Images\output1.pdf",
                @"C:\Images\output2.pdf",
                @"C:\Images\output3.pdf"
            };

            // Ensure the arrays have the same length
            int count = Math.Min(inputPaths.Length, outputPaths.Length);

            for (int i = 0; i < count; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filter
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply sharpen filter (kernel size 5, sigma 4.0) to the whole image
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Prepare PDF save options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the processed image as PDF
                    rasterImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to automatically enhance scanned documents (PNG, JPG, BMP) by sharpening them and archive each as a searchable PDF for a document management system.
 * 2. When a batch image processing tool must improve the visual clarity of product photos before converting them into PDF catalogs for e‑commerce platforms.
 * 3. When a medical imaging application requires sharpening of radiology images and saving them as PDF reports for easy distribution to clinicians.
 * 4. When a real‑estate agency wants to quickly sharpen property photos and generate PDF brochures for each listing using C# and Aspose.Imaging.
 * 5. When an educational software needs to preprocess lecture slide images with a sharpen filter and bundle each slide into individual PDF files for student download.
 */