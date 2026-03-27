using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.dcm";
        string outputPath = @"c:\temp\output\result.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Adjust brightness (example value: 30)
            dicomImage.AdjustBrightness(30);

            // Adjust contrast (example value: 20f)
            dicomImage.AdjustContrast(20f);

            // Adjust gamma (example value: 1.2f)
            dicomImage.AdjustGamma(1.2f);

            // Save the processed image as PDF
            dicomImage.Save(outputPath, new PdfOptions());
        }
    }
}