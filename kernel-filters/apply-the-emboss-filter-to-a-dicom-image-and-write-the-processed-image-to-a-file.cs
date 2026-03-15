using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Input DICOM file path
        string inputPath = "input.dcm";
        // Output DICOM file path
        string outputPath = "output_emboss.dcm";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply the Emboss filter to the entire image using a predefined kernel
            dicomImage.Filter(dicomImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image back to DICOM format
            dicomImage.Save(outputPath);
        }
    }
}