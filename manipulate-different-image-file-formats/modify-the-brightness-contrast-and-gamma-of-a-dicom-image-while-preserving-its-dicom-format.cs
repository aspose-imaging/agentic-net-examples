using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomAdjustmentExample
{
    static void Main()
    {
        // Paths to the source DICOM file and the destination file
        string sourcePath = @"C:\Temp\sample.dicom";
        string destinationPath = @"C:\Temp\sample_adjusted.dicom";

        // Load the DICOM image using Aspose.Imaging's generic Image.Load method
        using (Image image = Image.Load(sourcePath))
        {
            // Cast the loaded image to DicomImage to access DICOM‑specific adjustment methods
            DicomImage dicomImage = (DicomImage)image;

            // Adjust brightness (range: -255 to 255)
            dicomImage.AdjustBrightness(50);

            // Adjust contrast (range: -100f to 100f)
            dicomImage.AdjustContrast(30f);

            // Adjust gamma uniformly for all channels
            dicomImage.AdjustGamma(1.2f);

            // Save the modified image back to DICOM format, preserving the original file type
            dicomImage.Save(destinationPath, new DicomOptions());
        }
    }
}