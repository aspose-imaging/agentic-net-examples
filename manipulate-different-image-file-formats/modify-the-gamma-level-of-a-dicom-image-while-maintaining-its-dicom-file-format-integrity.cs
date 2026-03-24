using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

namespace DicomGammaAdjustment
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.dicom";
            string outputPath = @"C:\temp\sample.adjusted.dcm";

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

                // Apply gamma correction (example gamma value: 2.5)
                dicomImage.AdjustGamma(2.5f);

                // Save the modified image back to DICOM format, preserving integrity
                dicomImage.Save(outputPath, new DicomOptions());
            }
        }
    }
}