using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Input DICOM file path
        string inputPath = "input.dcm";
        // Output DICOM file path
        string outputPath = "output_embossed.dcm";

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply Emboss filter using a convolution filter option
            dicomImage.Filter(
                dicomImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

            // Save the processed image back to DICOM format
            dicomImage.Save(outputPath, new DicomOptions());
        }
    }
}