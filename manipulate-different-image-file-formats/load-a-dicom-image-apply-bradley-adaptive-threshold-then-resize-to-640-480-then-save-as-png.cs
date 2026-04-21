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
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image, apply Bradley threshold, resize, and save as PNG
        using (DicomImage image = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Apply Bradley adaptive threshold (brightnessDifference = 5, windowSize = 10)
            image.BinarizeBradley(5, 10);

            // Resize to 640x480 using nearest neighbour resampling
            image.Resize(640, 480, Aspose.Imaging.ResizeType.NearestNeighbourResample);

            // Save the processed image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}