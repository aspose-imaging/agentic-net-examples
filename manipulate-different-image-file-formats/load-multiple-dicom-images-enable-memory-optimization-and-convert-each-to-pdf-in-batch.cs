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
            // Hardcoded input DICOM files
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.dcm",
                @"C:\Images\input2.dcm",
                @"C:\Images\input3.dcm"
            };

            // Process each file
            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path (same name, .pdf extension, placed in an output folder)
                string outputDirectory = @"C:\Images\Output";
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DICOM image with memory optimization (buffer size hint)
                var loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB
                };

                using (Image dicomImage = Image.Load(inputPath, loadOptions))
                {
                    // Prepare PDF export options
                    var pdfOptions = new PdfOptions();

                    // Save as PDF
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
 * 1. When a hospital IT system must archive a series of DICOM radiology scans as searchable PDF reports while minimizing memory usage during batch processing.
 * 2. When a medical research lab needs to convert dozens of DICOM images from a scanner into PDF files for inclusion in a publication pipeline without loading the entire image into memory.
 * 3. When a telemedicine platform wants to generate patient‑friendly PDF summaries from uploaded DICOM files on the server, ensuring the conversion runs efficiently in a background job.
 * 4. When a health‑care compliance tool must batch‑convert DICOM files to PDF for secure storage in an electronic health record (EHR) system while controlling RAM consumption.
 * 5. When a C# desktop application automates the export of DICOM images to PDF for printing or sharing, using Aspose.Imaging’s BufferSizeHint to handle large image sets on limited‑resource machines.
 */