using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.dicom";
        string outputPath = "Output/result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;

            // Apply Gaussian blur filter to the entire image
            dicomImage.Filter(
                dicomImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Increase brightness by 15
            dicomImage.AdjustBrightness(15);

            // Save the processed image as PDF with default options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                dicomImage.Save(outputPath, pdfOptions);
            }
        }
    }
}