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
        string inputPath = @"C:\temp\sample.dicom";
        string outputPath = @"C:\temp\sample_cropped.dcm";

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
            // Cast to DicomImage to access DICOM-specific functionality
            DicomImage dicomImage = (DicomImage)image;

            // Define the cropping rectangle (central area of the image)
            var cropArea = new Rectangle(
                dicomImage.Width / 4,
                dicomImage.Height / 4,
                dicomImage.Width / 2,
                dicomImage.Height / 2);

            // Perform the crop operation
            dicomImage.Crop(cropArea);

            // Prepare DICOM save options to keep original metadata
            var saveOptions = new DicomOptions
            {
                KeepMetadata = true
            };

            // Save the cropped image back to DICOM format
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}