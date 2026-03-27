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
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (handles cases with no directory part)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the DICOM image, flip vertically, and save as PNG
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Flip vertically
            dicomImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

            // Save to PNG format
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}