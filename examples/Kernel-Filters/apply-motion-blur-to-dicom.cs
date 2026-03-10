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
        // Path to the folder containing the DICOM file
        string dir = @"c:\temp\";

        // Load the DICOM image
        using (Image image = Image.Load(dir + "sample.dicom"))
        {
            // Cast the generic Image to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply a motion blur (motion Wiener) filter to the entire image.
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            dicomImage.Filter(
                dicomImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the filtered image as PNG
            dicomImage.Save(dir + "sample.MotionWienerFilter.png", new PngOptions());
        }
    }
}