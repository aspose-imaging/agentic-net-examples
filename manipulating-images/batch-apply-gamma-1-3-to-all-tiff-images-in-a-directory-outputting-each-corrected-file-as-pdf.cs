// HOW-TO: Batch Apply Gamma 1.3 to TIFF Images and Convert to PDF in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                    continue;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    raster.AdjustGamma(1.3f);

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to correct the brightness of scanned TIFF documents before archiving them as searchable PDFs.
 * 2. When a medical imaging workflow requires batch gamma correction of radiology TIFF files and conversion to PDF for electronic health records.
 * 3. When a publishing system must normalize the contrast of high‑resolution TIFF artwork and output each file as a PDF for proofing.
 * 4. When an automated document processing pipeline has to apply a consistent gamma level to all TIFF images in a folder and generate PDF versions for downstream OCR.
 * 5. When a legacy archive contains TIFF scans that need batch gamma adjustment and conversion to PDF to reduce storage size and improve viewing compatibility.
 */
