using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample.GaussianBlurFilter.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image, apply Gaussian blur, and save the result
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            dicomImage.Filter(dicomImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            dicomImage.Save(outputPath, new PngOptions());
        }
    }
}