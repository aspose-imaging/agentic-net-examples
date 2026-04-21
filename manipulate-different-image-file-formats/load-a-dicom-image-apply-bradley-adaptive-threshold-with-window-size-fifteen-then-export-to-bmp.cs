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
        string inputPath = "sample.dicom";
        string outputPath = "result.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the DICOM image, apply Bradley adaptive threshold, and save as BMP
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply Bradley adaptive thresholding with a brightness difference of 5 and window size of 15
            dicomImage.BinarizeBradley(5, 15);

            // Save the processed image as BMP
            dicomImage.Save(outputPath, new BmpOptions());
        }
    }
}