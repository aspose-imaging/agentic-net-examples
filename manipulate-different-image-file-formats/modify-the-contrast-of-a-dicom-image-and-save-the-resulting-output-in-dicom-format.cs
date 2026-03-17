using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomContrastAdjustment
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"c:\temp\sample.dcm";
        string outputPath = @"c:\temp\sample_contrast.dcm";

        // Load the DICOM image from file
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Adjust contrast (value must be in the range [-100, 100])
            dicomImage.AdjustContrast(50f);

            // Save the modified image back to DICOM format using default DICOM options
            DicomOptions saveOptions = new DicomOptions();
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}