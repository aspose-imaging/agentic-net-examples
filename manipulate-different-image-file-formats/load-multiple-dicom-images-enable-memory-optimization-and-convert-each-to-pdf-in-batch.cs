// HOW-TO: Batch Convert DICOM Files to PDF with Memory Optimization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Pdf;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var loadOptions = new LoadOptions { BufferSizeHint = 1024 * 1024 };

                using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath, loadOptions))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.BufferSizeHint = 1024 * 1024;
                        dicomImage.Save(outputPath, pdfOptions);
                    }
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
 * 1. When a hospital IT system needs to generate printable PDF reports from thousands of DICOM scans while keeping RAM usage low.
 * 2. When a research lab wants to automate the conversion of a folder of MRI DICOM images into PDFs for easy sharing with collaborators.
 * 3. When a medical imaging software vendor must batch process patient studies into PDF archives without loading entire images into memory.
 * 4. When a radiology PACS integration requires on‑the‑fly conversion of incoming DICOM files to PDF documents for electronic health records.
 * 5. When a cloud service processes uploaded DICOM files in bulk and needs to output PDF files while optimizing server memory consumption.
 */
