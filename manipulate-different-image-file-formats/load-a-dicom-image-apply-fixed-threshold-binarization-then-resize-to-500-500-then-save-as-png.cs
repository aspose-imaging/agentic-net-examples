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
        string outputPath = @"C:\temp\result.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;

            // Apply fixed threshold binarization (threshold value 127)
            dicomImage.BinarizeFixed(127);

            // Resize the image to 500x500 using nearest neighbour resampling
            dicomImage.Resize(500, 500, ResizeType.NearestNeighbourResample);

            // Save the processed image as PNG
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}