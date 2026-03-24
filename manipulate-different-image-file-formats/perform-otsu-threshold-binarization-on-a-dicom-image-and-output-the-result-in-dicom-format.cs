using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

namespace OtsuBinarizationDemo
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.dcm";
            string outputPath = @"c:\temp\output.dcm";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Otsu threshold binarization
                dicomImage.BinarizeOtsu();

                // Save the binarized image back to DICOM format
                dicomImage.Save(outputPath, new DicomOptions());
            }
        }
    }
}