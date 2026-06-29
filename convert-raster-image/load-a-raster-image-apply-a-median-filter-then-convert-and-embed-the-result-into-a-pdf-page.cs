using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.png";
            string outputPdfPath = @"C:\Images\sample_filtered.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the filtered image as a PDF page
                rasterImage.Save(outputPdfPath, pdfOptions);
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
 * 1. When a developer needs to clean up noisy PNG scans of handwritten forms and embed the filtered image directly into a PDF report.
 * 2. When an application must automatically reduce salt‑and‑pepper noise in satellite JPEG images before generating a PDF document for archival.
 * 3. When a medical imaging system wants to apply a median filter to DICOM‑converted PNG images and save the result as a single‑page PDF for patient records.
 * 4. When a web service processes user‑uploaded PNG screenshots, removes visual artifacts with a median filter, and returns a PDF file for printing.
 * 5. When a batch job converts a folder of raster images to PDF while applying a 5‑pixel median filter to improve visual quality for legal document submission.
 */