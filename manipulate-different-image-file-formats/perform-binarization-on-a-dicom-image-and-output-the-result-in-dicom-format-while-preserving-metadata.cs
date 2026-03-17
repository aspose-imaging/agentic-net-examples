using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomBinarization
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample_binarized.dcm";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply fixed threshold binarization (threshold value 127)
            dicomImage.BinarizeFixed(127);

            // Prepare DICOM save options and preserve original metadata
            DicomOptions saveOptions = new DicomOptions
            {
                KeepMetadata = true
            };

            // Save the binarized image back to DICOM format
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}