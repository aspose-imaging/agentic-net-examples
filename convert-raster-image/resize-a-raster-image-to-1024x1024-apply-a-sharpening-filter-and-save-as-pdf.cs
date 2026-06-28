using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x1024
                image.Resize(1024, 1024);

                // Apply sharpening filter if the image is a raster image
                if (image is RasterImage rasterImage)
                {
                    // Sharpen with kernel size 5 and sigma 4.0 (example values)
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));
                }

                // Save as PDF using PdfOptions
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a web application needs to generate a printable 1024x1024 PDF thumbnail from a user‑uploaded JPEG and improve its clarity with a sharpening filter using Aspose.Imaging for .NET in C#.
 * 2. When an e‑commerce platform must automatically convert product photos to a standardized 1024x1024 size, enhance details, and store them as PDF catalog pages via C# code.
 * 3. When a document management system requires batch processing of scanned images to resize them to 1024x1024, apply a sharpen filter, and archive the results as PDF files using Aspose.Imaging.
 * 4. When a mobile backend service wants to prepare high‑resolution PDF receipts by resizing uploaded receipt images, sharpening text edges, and saving them as PDFs with C#.
 * 5. When a digital publishing workflow needs to transform source JPEG artwork into a 1024x1024 PDF preview with enhanced sharpness before sending it to a print‑ready pipeline using Aspose.Imaging for .NET.
 */