using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DicomFilterExample
{
    static void Main()
    {
        // Paths to the source and destination DICOM files
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        // Load the DICOM image from file
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to a DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply a Gaussian blur filter to the whole image
            // Rectangle covering the entire image is obtained via dicomImage.Bounds
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            dicomImage.Filter(dicomImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Prepare DICOM save options.
            // Here we keep the default color type; you can customize it if required.
            DicomOptions saveOptions = new DicomOptions();

            // Save the processed image back to DICOM format
            dicomImage.Save(outputPath, saveOptions);
        }
    }
}