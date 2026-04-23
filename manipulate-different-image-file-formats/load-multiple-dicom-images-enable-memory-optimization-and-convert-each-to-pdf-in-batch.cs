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
            // Hardcoded input DICOM files
            string[] inputFiles = new string[]
            {
                @"C:\Images\image1.dcm",
                @"C:\Images\image2.dcm",
                @"C:\Images\image3.dcm"
            };

            // Corresponding output PDF files
            string[] outputFiles = new string[]
            {
                @"C:\Output\image1.pdf",
                @"C:\Output\image2.pdf",
                @"C:\Output\image3.pdf"
            };

            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputPath = inputFiles[i];
                string outputPath = outputFiles[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Enable memory optimization via LoadOptions
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB
                };

                // Load DICOM image from file stream with the specified load options
                using (FileStream stream = File.OpenRead(inputPath))
                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Cache all pages to avoid further stream reads
                    dicomImage.CacheData();

                    // Convert and save as PDF
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