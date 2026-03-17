using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomOtsuBinarization
{
    static void Main()
    {
        // Paths for input and output DICOM files
        string inputPath = @"c:\temp\sample.dcm";
        string outputPath = @"c:\temp\sample.Binarized.dcm";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply Otsu threshold binarization
            dicomImage.BinarizeOtsu();

            // Save the binarized image back in DICOM format
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}