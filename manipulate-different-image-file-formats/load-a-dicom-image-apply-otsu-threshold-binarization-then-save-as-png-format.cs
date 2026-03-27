using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample.BinarizeOtsu.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image, apply Otsu binarization, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;
            dicomImage.BinarizeOtsu();
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}