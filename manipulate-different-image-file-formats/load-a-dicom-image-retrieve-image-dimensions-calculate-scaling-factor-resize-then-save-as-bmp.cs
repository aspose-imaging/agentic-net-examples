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

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Retrieve original dimensions
            int originalWidth = dicomImage.Width;
            int originalHeight = dicomImage.Height;

            // Calculate scaling factor (example: reduce size by 50%)
            double scaleFactor = 0.5;
            int newWidth = (int)(originalWidth * scaleFactor);
            int newHeight = (int)(originalHeight * scaleFactor);

            // Ensure dimensions are at least 1 pixel
            if (newWidth < 1) newWidth = 1;
            if (newHeight < 1) newHeight = 1;

            // Resize the image using nearest neighbour resampling
            dicomImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the resized image as BMP
            dicomImage.Save(outputPath, new BmpOptions());
        }
    }
}