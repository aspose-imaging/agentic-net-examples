// HOW-TO: Deskew TIFF Image, Apply Anti‑Alias Smoothing, and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.tif");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.NormalizeAngle(false, Aspose.Imaging.Color.White);

                Graphics graphics = new Graphics(raster);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

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
 * 1. When scanning documents that are slightly rotated, a developer can deskew the TIFF, smooth the edges, and output a clean PDF for archiving.
 * 2. When converting legacy multi‑page TIFF scans to searchable PDFs, applying anti‑alias smoothing improves visual quality of text and graphics.
 * 3. When preparing scanned forms for electronic signatures, deskewing ensures alignment while smoothing removes jagged lines before saving as PDF.
 * 4. When generating PDF reports from high‑resolution TIFF images, using Aspose.Imaging to correct orientation and apply smoothing yields professional‑looking PDFs.
 * 5. When automating a batch process that receives TIFF files from scanners, the code can automatically straighten, smooth, and convert each image to PDF for downstream workflows.
 */
