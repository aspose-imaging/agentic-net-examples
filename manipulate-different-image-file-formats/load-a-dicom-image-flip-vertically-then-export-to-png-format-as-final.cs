using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.dcm";
        string outputPath = "output\\flipped.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image, flip vertically, and save as PNG
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Flip vertically
            dicomImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

            // Save the transformed image as PNG
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}