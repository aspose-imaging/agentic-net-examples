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
        string inputPath = "input.dcm";
        string outputPath = "output.pdf";

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

            // Adjust brightness (value range: -255 to 255)
            dicomImage.AdjustBrightness(30); // increase brightness

            // Adjust contrast (value range: -100 to 100)
            dicomImage.AdjustContrast(20f); // increase contrast

            // Adjust gamma (positive float, 1.0 = no change)
            dicomImage.AdjustGamma(1.2f); // apply gamma correction

            // Save the processed image as PDF
            dicomImage.Save(outputPath, new PdfOptions());
        }
    }
}