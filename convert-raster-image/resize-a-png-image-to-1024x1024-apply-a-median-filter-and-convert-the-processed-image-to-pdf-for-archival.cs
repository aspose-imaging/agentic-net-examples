using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/processed.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Resize(1024, 1024);
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

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
 * 1. When a developer needs to generate a standardized 1024x1024 thumbnail of a PNG, reduce noise with a median filter, and store it as a searchable PDF for a digital asset management system.
 * 2. When an e‑commerce platform must compress product images, clean up artifacts, and archive the final images in PDF format for compliance reporting.
 * 3. When a medical imaging application requires converting high‑resolution PNG scans to a fixed size, denoise them, and save them as PDF records for patient archives.
 * 4. When a legal document management tool needs to ingest PNG evidence files, resize them for consistent viewing, apply a median filter to improve clarity, and bundle them into PDF files for court submission.
 * 5. When a content management system automates the preparation of PNG graphics for print, resizing them, smoothing noise, and exporting to PDF to ensure long‑term preservation.
 */