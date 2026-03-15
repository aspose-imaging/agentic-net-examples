using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source DICOM image
        string inputPath = @"c:\temp\sample.dicom";

        // Path where the adjusted DICOM image will be saved
        string outputPath = @"c:\temp\sample_contrast.dcm";

        // Load the DICOM image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Adjust the contrast; value must be in the range [-100, 100]
            dicomImage.AdjustContrast(50f);

            // Prepare DICOM save options (default options are sufficient for this case)
            DicomOptions saveOptions = new DicomOptions();

            // Save the modified image back to DICOM format
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}