using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of DICOM files to process
            string[] inputFiles = new string[]
            {
                @"C:\Images\dicom1.dcm",
                @"C:\Images\dicom2.dcm",
                @"C:\Images\dicom3.dcm"
            };

            // Output directory (hard‑coded)
            string outputDir = @"C:\Images\PdfOutput";

            // Ensure the output directory exists (unconditional as required)
            Directory.CreateDirectory(outputDir);

            // Memory‑optimization hint (256 KB)
            const int bufferSizeHint = 256 * 1024;

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the directory for the output file exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DICOM image with memory‑optimizing load options
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = bufferSizeHint
                };

                using (FileStream stream = File.OpenRead(inputPath))
                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Optional: cache all pages to avoid further stream reads
                    dicomImage.CacheData();

                    // Convert and save to PDF
                    PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a hospital IT system needs to archive a series of patient DICOM scans as searchable PDF reports while minimizing RAM usage during batch processing in a C# application.
 * 2. When a radiology research lab wants to convert dozens of DICOM images from a study into PDF documents for inclusion in a publication, using Aspose.Imaging's LoadOptions to control buffer size.
 * 3. When a medical imaging workflow requires automated nightly conversion of new DICOM files in a folder to PDF files for electronic health record (EHR) integration, with memory‑optimizing load options to handle large image sets.
 * 4. When a telemedicine platform must generate PDF summaries of multiple DICOM examinations on the fly, ensuring each image is cached and the conversion runs efficiently in a .NET service.
 * 5. When a diagnostic equipment manufacturer builds a C# utility that processes a batch of DICOM files, applies memory‑efficient loading, and outputs PDF files for compliance reporting and archiving.
 */