using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of DICOM input files
        string[] inputFiles = new string[]
        {
            @"C:\Images\dicom1.dcm",
            @"C:\Images\dicom2.dcm"
        };

        // Corresponding PDF output files
        string[] outputFiles = new string[]
        {
            @"C:\Output\dicom1.pdf",
            @"C:\Output\dicom2.pdf"
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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image with memory optimization (buffer size hint)
            using (FileStream stream = File.OpenRead(inputPath))
            {
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 256 * 1024 // 256 KB
                };

                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Convert and save the image as PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    dicomImage.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}