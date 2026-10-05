// HOW-TO: Batch Increase Brightness of TIFF Images and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "C:\\InputTiffs";
            string outputFolder = "C:\\OutputPdfs";

            string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                    continue;

                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage raster)
                    {
                        raster.AdjustBrightness(20);
                    }

                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputFolder, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pdfOptions = new PdfOptions();
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
 * 1. When you need to automatically brighten scanned TIFF documents before converting them to searchable PDF files for archiving.
 * 2. When a workflow requires processing a folder of medical imaging TIFFs, enhancing visibility by increasing brightness, and outputting each as a PDF report.
 * 3. When you want to prepare a batch of high‑resolution TIFF photographs for client delivery by adjusting exposure and saving them as PDF portfolios.
 * 4. When an application must convert legacy TIFF blueprints to PDF while improving contrast through a brightness boost for easier viewing on tablets.
 * 5. When a document management system needs to ingest multiple TIFF files, apply a uniform brightness correction, and store the results as PDF files for downstream indexing.
 */
