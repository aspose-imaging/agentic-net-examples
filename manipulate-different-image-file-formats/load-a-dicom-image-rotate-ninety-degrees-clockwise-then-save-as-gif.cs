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
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image, rotate, and save as GIF
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Rotate 90 degrees clockwise without flipping
            dicomImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Save the rotated image as GIF
            dicomImage.Save(outputPath, new GifOptions());
        }
    }
}