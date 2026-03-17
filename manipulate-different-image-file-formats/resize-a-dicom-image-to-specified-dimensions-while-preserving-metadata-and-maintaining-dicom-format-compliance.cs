using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class DicomResizeExample
{
    static void Main()
    {
        // Input DICOM file path
        string inputPath = @"c:\temp\sample.dicom";

        // Output DICOM file path
        string outputPath = @"c:\temp\sample_resized.dicom";

        // Desired dimensions
        int newWidth = 512;
        int newHeight = 512;

        // Load the DICOM image using the generic Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM‑specific functionality
            DicomImage dicomImage = (DicomImage)image;

            // Resize the image; metadata is retained automatically
            dicomImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Prepare DICOM save options (preserves existing metadata)
            DicomOptions saveOptions = new DicomOptions();

            // Save the resized image back to DICOM format
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}