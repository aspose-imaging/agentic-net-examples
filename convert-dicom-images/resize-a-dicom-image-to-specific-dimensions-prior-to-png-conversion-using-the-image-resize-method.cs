using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.dicom";
        string outputPath = @"C:\temp\resized.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image, resize it, and save as PNG
        using (DicomImage image = (DicomImage)Image.Load(inputPath))
        {
            // Desired dimensions
            int newWidth = 800;
            int newHeight = 600;

            // Resize using Bilinear resampling
            image.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Save the resized image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}