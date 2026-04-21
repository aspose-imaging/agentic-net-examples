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
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.dcm";
        string outputPath = @"C:\Images\output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image, resize it, and save as BMP
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Resize to 800x600 using nearest neighbour resampling
            dicomImage.Resize(800, 600, ResizeType.NearestNeighbourResample);

            // Save the resized image as BMP
            dicomImage.Save(outputPath, new BmpOptions());
        }
    }
}