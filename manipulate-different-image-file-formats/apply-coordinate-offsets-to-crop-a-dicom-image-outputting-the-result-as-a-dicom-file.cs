using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomCropExample
{
    static void Main()
    {
        // Path to the folder containing the DICOM file
        string dir = @"c:\temp\";

        // Load the DICOM image
        using (Image image = Image.Load(dir + "sample.dcm"))
        {
            // Cast to DicomImage to access DICOM‑specific functionality
            DicomImage dicomImage = (DicomImage)image;

            // Define coordinate offsets (in pixels) for each side
            int leftShift   = 50;   // pixels to remove from the left side
            int rightShift  = 50;   // pixels to remove from the right side
            int topShift    = 30;   // pixels to remove from the top side
            int bottomShift = 30;   // pixels to remove from the bottom side

            // Apply the cropping operation using the offsets
            dicomImage.Crop(leftShift, rightShift, topShift, bottomShift);

            // Save the cropped image back as a DICOM file
            dicomImage.Save(dir + "sample_cropped.dcm", new DicomOptions());
        }
    }
}