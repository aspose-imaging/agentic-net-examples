using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;

class DicomTransformExample
{
    static void Main()
    {
        // Path to the source DICOM file
        string inputPath = @"C:\Temp\sample.dcm";

        // Path where the transformed DICOM file will be saved
        string outputPath = @"C:\Temp\sample_rotated_flipped.dcm";

        // Load the DICOM image using Aspose.Imaging's Image.Load method
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Apply a combined rotation (90 degrees clockwise) and horizontal flip.
            // RotateFlipType provides various combinations; adjust as needed.
            dicomImage.RotateFlip(RotateFlipType.Rotate90FlipX);

            // Save the transformed image back to DICOM format.
            // The Save method preserves the original format when the file extension is .dcm.
            dicomImage.Save(outputPath);
        }

        Console.WriteLine("Transformation completed. Saved to: " + outputPath);
    }
}