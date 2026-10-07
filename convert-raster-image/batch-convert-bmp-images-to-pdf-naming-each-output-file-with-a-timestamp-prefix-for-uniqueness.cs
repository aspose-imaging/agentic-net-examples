// HOW-TO: Batch Convert BMP Files to PDF with Timestamped Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BmpToPdfBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = @"C:\BmpInput";
                string outputDirectory = @"C:\PdfOutput";

                // Ensure the output directory exists
                Directory.CreateDirectory(outputDirectory);

                string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp", SearchOption.TopDirectoryOnly);

                foreach (string inputPath in bmpFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string outputFileName = $"{timestamp}_{Path.GetFileNameWithoutExtension(inputPath)}.pdf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var pdfOptions = new PdfOptions();
                        image.Save(outputPath, pdfOptions);
                    }

                    // Slight pause to help keep timestamps unique
                    System.Threading.Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to archive a collection of BMP scans as PDF documents while ensuring each PDF has a unique timestamped name to avoid overwriting.
 * 2. When an automated workflow must convert newly saved BMP screenshots into PDFs for email attachment, using a timestamp prefix to keep the order of creation.
 * 3. When a document management system requires batch conversion of BMP assets to PDF and needs unique filenames for version control.
 * 4. When generating PDF invoices from BMP graphics in a batch process and you want each file to include a precise creation timestamp for audit trails.
 * 5. When migrating legacy BMP image archives to PDF format on a server and you need to guarantee unique output names across multiple runs.
 */
