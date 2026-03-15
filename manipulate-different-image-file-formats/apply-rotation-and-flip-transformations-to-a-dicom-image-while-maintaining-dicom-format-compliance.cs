using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source DICOM file
        string inputPath = @"c:\temp\sample.dicom";

        // Path for the transformed DICOM file
        string outputPath = @"c:\temp\sample_rotated.dicom";

        // Load the DICOM image using Aspose.Imaging's Image.Load method
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Apply a rotation of 90 degrees clockwise combined with a horizontal flip
            dicomImage.RotateFlip(RotateFlipType.Rotate90FlipX);

            // Save the transformed image back to DICOM format.
            // Calling Save without specifying options preserves the original DICOM metadata.
            dicomImage.Save(outputPath);
        }
    }
}