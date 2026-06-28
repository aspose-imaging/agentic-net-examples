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
            // Hardcoded list of DICOM files to process
            string[] inputPaths = new string[]
            {
                @"C:\Images\dicom1.dcm",
                @"C:\Images\dicom2.dcm",
                @"C:\Images\dicom3.dcm"
            };

            // Hardcoded output directory for PDF files
            string outputDir = @"C:\Images\PdfOutput";

            foreach (string inputPath in inputPaths)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PDF file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DICOM image with a buffer size hint to limit memory usage
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB
                };

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Configure PDF options (also applying a buffer size hint)
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        BufferSizeHint = 256 * 1024 // 256 KB
                    };

                    // Save the image as a PDF document
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
 * 1. When a hospital IT system needs to batch‑convert DICOM radiology scans into PDF reports while keeping memory usage low.
 * 2. When a medical research lab wants to archive a collection of DICOM images as searchable PDF files without loading the entire image into RAM.
 * 3. When a telemedicine platform must generate PDF summaries of patient imaging studies on the fly for email attachment, using C# and Aspose.Imaging with buffer size hints.
 * 4. When a health‑care compliance tool automates the conversion of multiple DICOM files to PDF for long‑term storage and audit trails, requiring efficient memory management.
 * 5. When a radiology workflow application processes a list of DICOM files from a folder and saves each as a PDF document in a separate output directory using .NET.
 */