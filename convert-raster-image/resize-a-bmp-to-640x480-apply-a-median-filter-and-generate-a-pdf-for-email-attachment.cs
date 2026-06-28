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
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Resize(640, 480);
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

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
 * 1. When a developer needs to shrink a high‑resolution BMP screenshot to a 640×480 thumbnail, reduce noise with a median filter, and attach the result as a PDF in an automated email report.
 * 2. When an application must convert legacy BMP scans of signed contracts into compact PDF files after resizing and cleaning the images for archival and email distribution.
 * 3. When a batch job processes user‑uploaded BMP photos, normalizes their dimensions, removes speckles using a median filter, and generates PDF attachments for notification emails.
 * 4. When a C# service prepares product catalog images originally stored as BMP, resizes them for web‑friendly viewing, applies a median filter to improve clarity, and sends the PDFs to clients via email.
 * 5. When a document management system needs to transform scanned BMP pages into searchable PDF attachments, ensuring consistent size and reduced noise before emailing them to stakeholders.
 */