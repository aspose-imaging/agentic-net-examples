using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access adjustment methods
                DicomImage dicomImage = (DicomImage)image;

                // Adjust brightness, contrast, and gamma sequentially
                dicomImage.AdjustBrightness(30);          // example brightness value
                dicomImage.AdjustContrast(20f);           // example contrast value
                dicomImage.AdjustGamma(1.2f);             // example gamma value

                // Save the processed image as PDF
                dicomImage.Save(outputPath, new PdfOptions());
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
 * 1. When a medical imaging application needs to convert a DICOM radiology scan to a PDF report while enhancing visibility by adjusting brightness, contrast, and gamma using C# and Aspose.Imaging.
 * 2. When a healthcare provider wants to generate printable PDFs from DICOM files for patient records, applying image processing adjustments to improve diagnostic clarity.
 * 3. When a radiology workflow automates the preparation of DICOM images for telemedicine, using Aspose.Imaging to tweak visual parameters before saving as a PDF for easy sharing.
 * 4. When a research team processes batches of DICOM images, applying consistent brightness, contrast, and gamma corrections in .NET and exporting the results as PDFs for publication.
 * 5. When a hospital IT system integrates DICOM image handling into a .NET service, needing to adjust image quality and output the final image as a PDF for archival or review purposes.
 */