using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
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

                // Save the result as PDF with default options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    dicomImage.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology application must load a DICOM scan, apply a Gaussian blur to reduce noise, increase brightness for clearer viewing, and export the result as a PDF report for clinicians.
 * 2. When a medical imaging web service needs to convert uploaded DICOM files to PDF documents after smoothing with a Gaussian filter and adjusting brightness to meet privacy and readability requirements.
 * 3. When a hospital’s batch processing script automates the creation of printable PDFs from DICOM images, using Gaussian blur to anonymize sensitive details and brightness enhancement for consistent print quality.
 * 4. When a research tool extracts DICOM images, applies a Gaussian blur to smooth artifacts, brightens the image for better contrast, and saves the processed output as a PDF for inclusion in scientific publications.
 * 5. When a C# desktop utility loads a DICOM file, performs image processing such as Gaussian blur and brightness correction, and then saves the final image as a PDF with default settings for archival purposes.
 */