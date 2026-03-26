using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output\\resized.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image, resize, and save as PNG
        using (DicomImage image = (DicomImage)Image.Load(inputPath))
        {
            int newWidth = 800;   // Desired width
            int newHeight = 600;  // Desired height

            // Resize using nearest neighbour resampling
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Save the resized image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}