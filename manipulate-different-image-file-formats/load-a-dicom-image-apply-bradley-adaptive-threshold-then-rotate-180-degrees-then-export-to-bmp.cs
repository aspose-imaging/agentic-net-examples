using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image, apply Bradley threshold, rotate, and save as BMP
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;

            // Apply Bradley adaptive threshold (brightnessDifference = 5, windowSize = 10)
            dicomImage.BinarizeBradley(5, 10);

            // Rotate 180 degrees without resizing, using black background
            dicomImage.Rotate(180f, false, Color.Black);

            // Save as BMP
            BmpOptions bmpOptions = new BmpOptions();
            dicomImage.Save(outputPath, bmpOptions);
        }
    }
}