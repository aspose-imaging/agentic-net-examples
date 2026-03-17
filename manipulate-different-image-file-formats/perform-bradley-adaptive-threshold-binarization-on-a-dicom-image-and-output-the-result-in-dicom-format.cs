using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample.BinarizeBradley5_10x10.dicom";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply Bradley's adaptive thresholding
            // brightnessDifference = 5, windowSize = 10 (10x10 window)
            dicomImage.BinarizeBradley(5, 10);

            // Save the processed image back in DICOM format
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}