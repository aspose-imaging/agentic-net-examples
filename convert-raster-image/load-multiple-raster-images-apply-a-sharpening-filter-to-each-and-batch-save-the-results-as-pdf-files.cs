// HOW-TO: Batch Sharpen Multiple Images and Save as PDFs in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input image files
            string[] inputPaths = new string[]
            {
                @"C:\Images\photo1.png",
                @"C:\Images\photo2.jpg",
                @"C:\Images\photo3.tif"
            };

            // Corresponding output PDF files
            string[] outputPaths = new string[]
            {
                @"C:\Output\photo1.pdf",
                @"C:\Output\photo2.pdf",
                @"C:\Output\photo3.pdf"
            };

            // Process each image
            for (int i = 0; i < inputPaths.Length; i++)
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
                    // Cast to RasterImage to access filtering
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
 * 1. When you need to batch‑process raster images, apply a sharpen filter, and archive the results as PDF files.
 * 2. When an automated workflow must enhance scanned JPEG, PNG, or TIFF pictures and generate PDF reports in C#.
 * 3. When a web API receives user‑uploaded images, sharpens them programmatically, and returns the output as PDFs.
 * 4. When preparing print‑ready PDFs from low‑resolution photos by applying a sharpening filter to improve detail.
 * 5. When migrating a legacy image collection to PDF format while automatically improving image clarity with Aspose.Imaging in .NET.
 */
