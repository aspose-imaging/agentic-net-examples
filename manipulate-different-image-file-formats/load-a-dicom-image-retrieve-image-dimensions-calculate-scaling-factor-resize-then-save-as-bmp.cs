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
        string outputPath = @"C:\temp\resized.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (DicomImage image = (DicomImage)Image.Load(inputPath))
        {
            // Retrieve original dimensions
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // Calculate scaling factor (example: reduce size by 50%)
            double scaleFactor = 0.5;
            int newWidth = (int)(originalWidth * scaleFactor);
            int newHeight = (int)(originalHeight * scaleFactor);

            // Resize the image using nearest neighbour resampling
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Save the resized image as BMP
            image.Save(outputPath, new BmpOptions());
        }
    }
}