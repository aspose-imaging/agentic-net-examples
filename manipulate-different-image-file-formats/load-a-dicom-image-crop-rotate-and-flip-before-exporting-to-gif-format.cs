using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

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

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Crop the image (example rectangle)
            var cropRect = new Rectangle(10, 10, 200, 200);
            dicomImage.Crop(cropRect);

            // Rotate and flip the image
            dicomImage.RotateFlip(RotateFlipType.Rotate90FlipX);

            // Save as GIF
            dicomImage.Save(outputPath, new GifOptions());
        }
    }
}