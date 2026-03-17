using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomBrightnessAdjustment
{
    static void Main()
    {
        // Path to the folder containing the DICOM file
        string dir = @"c:\temp\";

        // Load the existing DICOM image
        using (Image image = Image.Load(dir + "sample.dicom"))
        {
            // Cast to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Adjust brightness; valid range is [-255, 255]
            dicomImage.AdjustBrightness(50);

            // Save the modified image back to DICOM format,
            // preserving DICOM compliance by using DicomOptions.
            DicomOptions saveOptions = new DicomOptions();
            dicomImage.Save(dir + "sample_brightness.dcm", saveOptions);
        }
    }
}