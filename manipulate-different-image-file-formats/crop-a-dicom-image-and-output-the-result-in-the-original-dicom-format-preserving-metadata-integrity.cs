using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Input and output DICOM file paths
        string inputPath = "input.dcm";
        string outputPath = "output_cropped.dcm";

        // Load the DICOM image, cast to DicomImage for cropping
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Define the central cropping rectangle (half width and height, centered)
            int cropX = dicomImage.Width / 4;
            int cropY = dicomImage.Height / 4;
            int cropWidth = dicomImage.Width / 2;
            int cropHeight = dicomImage.Height / 2;
            Rectangle cropArea = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            // Perform the crop operation
            dicomImage.Crop(cropArea);

            // Prepare DICOM save options to keep original metadata
            DicomOptions saveOptions = new DicomOptions
            {
                KeepMetadata = true
            };

            // Save the cropped image back to DICOM format
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}