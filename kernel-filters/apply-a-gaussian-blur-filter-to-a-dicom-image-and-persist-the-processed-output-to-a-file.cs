using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the DICOM file.
        string dir = @"c:\temp\";

        // Load the DICOM image.
        using (Image image = Image.Load(dir + "sample.dicom"))
        {
            // Cast the generic Image to DicomImage to access DICOM‑specific methods.
            DicomImage dicomImage = (DicomImage)image;

            // Apply a Gaussian blur filter to the whole image.
            // Radius = 5, Sigma = 4.0 (as in the documentation example).
            dicomImage.Filter(dicomImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG.
            dicomImage.Save(dir + "sample.GaussianBlur.png", new PngOptions());
        }
    }
}