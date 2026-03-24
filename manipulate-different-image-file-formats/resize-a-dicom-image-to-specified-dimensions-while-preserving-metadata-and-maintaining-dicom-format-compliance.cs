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
        string outputPath = "output_resized.dcm";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Desired dimensions (example: 512x512)
            int newWidth = 512;
            int newHeight = 512;

            // Resize the image while preserving metadata
            dicomImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Save the resized image as DICOM, keeping original metadata
            var saveOptions = new DicomOptions { KeepMetadata = true };
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}