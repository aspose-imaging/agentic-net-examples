// HOW-TO: Apply Gamma Correction to TIFF and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.tif";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)tiff;
                raster.AdjustGamma(1.2f);
                PdfOptions pdfOptions = new PdfOptions();
                tiff.Save(outputPath, pdfOptions);
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
 * 1. When you need to brighten a scanned TIFF document before distributing it as a searchable PDF.
 * 2. When a medical imaging system must adjust the gamma of high‑resolution TIFF X‑ray images and archive them as PDFs.
 * 3. When an e‑commerce platform wants to enhance product TIFF photos and deliver them to customers in PDF catalogs.
 * 4. When a legal firm requires consistent visual quality across TIFF evidence files by applying gamma correction and converting them to PDF for courtroom presentation.
 * 5. When an automated workflow processes batches of TIFF maps, applies gamma correction to improve readability, and saves the results as PDFs for archival storage.
 */
