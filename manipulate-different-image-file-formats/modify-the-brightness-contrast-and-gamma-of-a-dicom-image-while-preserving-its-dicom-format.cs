using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access adjustment methods
            DicomImage dicomImage = (DicomImage)image;

            // Adjust brightness (range: -255 to 255)
            dicomImage.AdjustBrightness(50);

            // Adjust contrast (range: -100 to 100)
            dicomImage.AdjustContrast(30f);

            // Adjust gamma (positive float)
            dicomImage.AdjustGamma(1.2f);

            // Save the modified image preserving DICOM format
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}