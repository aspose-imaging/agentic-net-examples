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
        string inputPath = @"C:\Images\sample.dcm";
        string outputPath = @"C:\Images\Processed\sample_rotated.dcm";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Apply rotation and flip (example: rotate 90 degrees clockwise, no flip)
            dicomImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the transformed image back to DICOM format
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}