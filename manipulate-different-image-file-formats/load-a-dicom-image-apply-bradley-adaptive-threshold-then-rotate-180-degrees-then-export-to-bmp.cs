using System;
using System.IO;
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
        using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Apply Bradley adaptive threshold (brightnessDifference = 5, windowSize = 10)
            dicomImage.BinarizeBradley(5, 10);

            // Rotate 180 degrees, resize proportionally, background color black
            dicomImage.Rotate(180f, true, Aspose.Imaging.Color.Black);

            // Save the processed image as BMP
            BmpOptions bmpOptions = new BmpOptions();
            dicomImage.Save(outputPath, bmpOptions);
        }
    }
}