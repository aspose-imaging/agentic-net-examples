using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply Gaussian blur filter to the whole image
            dicomImage.Filter(dicomImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as GIF with default options
            dicomImage.Save(outputPath, new GifOptions());
        }
    }
}