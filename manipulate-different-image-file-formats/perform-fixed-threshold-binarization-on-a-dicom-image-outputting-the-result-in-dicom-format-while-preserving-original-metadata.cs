using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class FixedThresholdBinarization
{
    static void Main()
    {
        // Path to the source DICOM image
        string inputPath = @"C:\temp\sample.dicom";

        // Path for the binarized DICOM output (metadata will be preserved)
        string outputPath = @"C:\temp\sample_binarized.dicom";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply fixed‑threshold binarization (threshold value: 127)
            dicomImage.BinarizeFixed(127);

            // Save the processed image back to DICOM format,
            // using DicomOptions to retain original metadata
            DicomOptions dicomOptions = new DicomOptions();
            dicomImage.Save(outputPath, dicomOptions);
        }
    }
}