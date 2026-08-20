// HOW-TO: Resize BMP to 640x480, Apply Median Filter, Save as PDF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\result.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 640x480
                image.Resize(640, 480);

                // Apply median filter (kernel size 5) to the entire image
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                // Save the processed image as PDF
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to shrink a large BMP screenshot to a standard 640×480 size, clean up noise with a median filter, and embed it in a PDF email attachment.
 * 2. When an automated report generator must convert scanned BMP documents into compact PDF files while reducing visual artifacts before sending them to clients.
 * 3. When a web service processes user‑uploaded BMP images, normalizes their dimensions, applies noise reduction, and returns a PDF suitable for archival or emailing.
 * 4. When a desktop application prepares product photos stored as BMPs for marketing emails by resizing them, smoothing the image, and packaging them as PDFs.
 * 5. When a batch job iterates over BMP files, applies a 5‑pixel median filter to improve image quality, resizes them to 640×480, and saves each as a PDF for distribution.
 */
