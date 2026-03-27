using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of DICOM files to process
        string[] inputFiles = new string[]
        {
            @"C:\Images\dicom1.dcm",
            @"C:\Images\dicom2.dcm",
            @"C:\Images\dicom3.dcm"
        };

        // Hardcoded output directory for the generated PDFs
        string outputDirectory = @"C:\Images\PdfOutput";

        foreach (string inputPath in inputFiles)
        {
            // Verify that the input DICOM file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build the output PDF file path (same name, .pdf extension)
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");

            // Ensure the output directory exists before saving
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure load options to limit internal buffer size (memory optimization)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 256 * 1024 // 256 KB
            };

            // Load the DICOM image using the memory‑optimized load options
            using (Image dicomImage = Image.Load(inputPath, loadOptions))
            {
                // Prepare PDF export options (default settings are sufficient here)
                PdfOptions pdfOptions = new PdfOptions();

                // Save the loaded image as a PDF document
                dicomImage.Save(outputPath, pdfOptions);
            }
        }
    }
}