using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Input and output DICOM file paths
        string inputPath = args.Length > 0 ? args[0] : "input.dcm";
        string outputPath = args.Length > 1 ? args[1] : "output_resized.dcm";

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Define new dimensions (example: 50% reduction)
            int newWidth = dicomImage.Width / 2;
            int newHeight = dicomImage.Height / 2;

            // Resize using nearest neighbour resampling
            dicomImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Prepare DICOM save options, preserving original metadata
            DicomOptions options = new DicomOptions
            {
                KeepMetadata = true
                // Additional metadata can be set via options.XmpData if needed
            };

            // Save the resized image back to DICOM format
            dicomImage.Save(outputPath, options);
        }
    }
}