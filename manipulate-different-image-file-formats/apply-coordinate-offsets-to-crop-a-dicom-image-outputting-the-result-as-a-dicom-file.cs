using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomCropExample
{
    static void Main()
    {
        // Path to the folder containing the DICOM file
        string dataDir = @"c:\temp\";

        // Load the DICOM image
        using (Image image = Image.Load(dataDir + "input.dcm"))
        {
            // Cast the generic Image to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Define coordinate offsets (in pixels) for cropping
            int leftShift   = 50;   // pixels to remove from the left side
            int rightShift  = 50;   // pixels to remove from the right side
            int topShift    = 30;   // pixels to remove from the top
            int bottomShift = 30;   // pixels to remove from the bottom

            // Apply the crop operation using the offsets
            dicomImage.Crop(leftShift, rightShift, topShift, bottomShift);

            // Save the cropped image back to DICOM format
            dicomImage.Save(dataDir + "output.dcm", new DicomOptions());
        }
    }
}