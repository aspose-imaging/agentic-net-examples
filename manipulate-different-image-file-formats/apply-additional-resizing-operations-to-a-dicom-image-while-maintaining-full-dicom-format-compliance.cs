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
        string inputPath = "sample.dcm";
        string outputPath = "resized_output.dcm";

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
            // Cast to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Calculate new dimensions (example: double size)
            int newWidth = dicomImage.Width * 2;
            int newHeight = dicomImage.Height * 2;

            // Resize while keeping DICOM compliance
            dicomImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Save back to DICOM format with default options
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}