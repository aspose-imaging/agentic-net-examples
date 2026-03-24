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
        string inputPath = @"C:\temp\input.dcm";
        string outputPath = @"C:\temp\output.dcm";

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
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Calculate offset margins (10% of width/height)
            int horizontalMargin = dicomImage.Width / 10;
            int verticalMargin = dicomImage.Height / 10;

            // Apply cropping with the calculated offsets:
            // leftShift, rightShift, topShift, bottomShift
            dicomImage.Crop(horizontalMargin, horizontalMargin, verticalMargin, verticalMargin);

            // Save the cropped image back to DICOM format
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}