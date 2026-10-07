// HOW-TO: Apply Gaussian Blur to PSD and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.psd");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(3, 3);
                raster.Filter(raster.Bounds, blurOptions);

                var pdfOptions = new PdfOptions();
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
 * 1. When you need to obscure sensitive details in a Photoshop PSD before sharing it as a PDF report.
 * 2. When a web service must automatically smooth high‑resolution PSD artwork and deliver it in a PDF for client review.
 * 3. When generating printable PDFs from layered PSD files while applying a uniform Gaussian blur to meet branding guidelines.
 * 4. When batch‑processing design assets to reduce file size by blurring and converting PSDs to PDF for archival storage.
 * 5. When integrating Aspose.Imaging in a C# application to programmatically apply a sigma‑3 blur to a PSD and export the result as a PDF for email attachment.
 */
