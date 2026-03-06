using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dir = @"c:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "sample.dicom");
        string outputPath = System.IO.Path.Combine(dir, "sample.SharpenFilter.png");

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific functionality
            DicomImage dicomImage = (DicomImage)image;

            // Apply a sharpen filter (kernel size 5, sigma 4.0) to the entire image
            dicomImage.Filter(dicomImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the result as a PNG file
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}