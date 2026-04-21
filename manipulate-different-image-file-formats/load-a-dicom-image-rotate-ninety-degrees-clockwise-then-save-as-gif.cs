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
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the DICOM image, rotate 90 degrees clockwise, and save as GIF
        using (var dicomImage = (DicomImage)Image.Load(inputPath))
        {
            dicomImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            dicomImage.Save(outputPath, new GifOptions());
        }
    }
}