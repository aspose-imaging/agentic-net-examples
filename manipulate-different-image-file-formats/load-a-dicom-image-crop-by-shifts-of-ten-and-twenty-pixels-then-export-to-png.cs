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
        string inputPath = @"C:\temp\sample.dicom";
        string outputPath = @"C:\temp\sample.cropped.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image, crop, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;

            // Crop with left/right shift of 10 pixels and top/bottom shift of 20 pixels
            dicomImage.Crop(10, 10, 20, 20);

            // Save the cropped image to PNG format
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}