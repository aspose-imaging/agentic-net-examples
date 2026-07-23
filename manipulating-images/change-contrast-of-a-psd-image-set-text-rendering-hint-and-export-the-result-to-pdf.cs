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
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Adjust contrast if the image is raster
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    if (!raster.IsCached) raster.CacheData();
                    raster.AdjustContrast(50f); // example contrast value
                }

                // Set PDF export options with text rendering hint
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    image.Save(outputPath, pdfOptions);
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
 * 1. When a designer needs to convert a Photoshop PSD file to a PDF for client review while increasing the image contrast to make details stand out.
 * 2. When an automated batch job must process layered PSD assets, adjust their contrast, and generate PDF reports with crisp text rendering for archival.
 * 3. When a web service receives user‑uploaded PSD files and must produce printable PDFs with enhanced contrast and single‑bit‑per‑pixel text for low‑resolution printing.
 * 4. When a desktop application offers a “Export to PDF” feature that applies a contrast boost to raster layers of a PSD and ensures text is rendered with no smoothing for sharpness.
 * 5. When a document management system needs to ingest PSD files, improve visual clarity by adjusting contrast, and store them as PDFs with precise text rendering hints for searchable PDFs.
 */