using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access adjustment methods
                DicomImage dicomImage = (DicomImage)image;

                // Adjust brightness, contrast, and gamma sequentially
                dicomImage.AdjustBrightness(30);      // Example brightness value
                dicomImage.AdjustContrast(20f);       // Example contrast value
                dicomImage.AdjustGamma(1.2f);         // Example gamma value

                // Save the processed image as PDF
                var pdfOptions = new PdfOptions();
                dicomImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}