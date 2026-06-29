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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\thumbnail.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering and resizing
                RasterImage raster = (RasterImage)image;

                // Apply a median filter (kernel size 3)
                raster.Filter(raster.Bounds, new MedianFilterOptions(3));

                // Resize the image to 200x200 pixels
                raster.Resize(200, 200);

                // Save the processed image as a PDF thumbnail
                PdfOptions pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a small PDF preview of a high‑resolution BMP scan for a document management system, they can load the BMP, apply a median filter to reduce noise, resize it to 200 × 200 pixels, and save it as a PDF thumbnail using Aspose.Imaging for .NET.
 * 2. When an e‑commerce site wants to display fast‑loading product thumbnails from legacy BMP assets, the code can clean the image with a median filter, shrink it to a uniform 200 × 200 size, and export it as a PDF thumbnail for consistent browser rendering.
 * 3. When a medical imaging application must create compact PDF reports from raw BMP X‑ray images, the developer can use this snippet to denoise the image, resize it for report layout, and embed it as a PDF thumbnail.
 * 4. When a batch‑processing tool needs to convert a folder of BMP icons into searchable PDF thumbnails for an internal knowledge base, the code demonstrates how to filter, resize, and save each image as a PDF using C# and Aspose.Imaging.
 * 5. When a developer is building a Windows desktop utility that previews scanned documents, they can employ this example to load a BMP scan, apply a median filter to improve visual quality, resize it to a thumbnail size, and output a PDF file that can be opened in any PDF viewer.
 */