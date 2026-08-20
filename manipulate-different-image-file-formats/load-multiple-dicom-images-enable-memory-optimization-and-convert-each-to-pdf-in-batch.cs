// HOW-TO: Batch Convert DICOM Files to PDF with Memory Optimization in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDir = @"C:\InputDICOMs";
            string outputDir = @"C:\OutputPDFs";

            // Get all DICOM files in the input directory
            string[] dicomFiles = Directory.GetFiles(inputDir, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding PDF output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DICOM image with memory optimization (buffer size hint)
                var loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB
                };

                using (Image dicomImage = Image.Load(inputPath, loadOptions))
                {
                    // Prepare PDF export options
                    var pdfOptions = new PdfOptions();

                    // Save the image as PDF
                    dicomImage.Save(outputPath, pdfOptions);
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
 * 1. When a hospital IT system needs to archive dozens of patient DICOM scans as PDF reports while keeping RAM usage low.
 * 2. When a research lab processes a folder of radiology images and wants to generate searchable PDF documents for each study.
 * 3. When a medical imaging workflow requires automated conversion of incoming DICOM files to PDF for integration with a document management system.
 * 4. When a cloud service batches large numbers of DICOM images and must limit memory consumption during conversion to PDF.
 * 5. When a desktop application offers users a one‑click export of selected DICOM series to PDF without loading the entire image into memory.
 */
