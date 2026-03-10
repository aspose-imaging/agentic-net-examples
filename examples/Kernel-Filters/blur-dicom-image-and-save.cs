using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output DICOM file paths
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific methods
            var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;

            // Apply Gaussian blur filter to the entire image
            dicomImage.Filter(
                dicomImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to DICOM format
            var options = new DicomOptions();
            dicomImage.Save(outputPath, options);
        }
    }
}