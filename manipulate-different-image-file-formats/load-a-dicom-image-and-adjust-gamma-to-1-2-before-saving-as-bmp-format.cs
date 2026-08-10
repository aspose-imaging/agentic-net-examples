// HOW-TO: How To Adjust Gamma Of DICOM Image And Save As BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.dicom";
            string outputPath = @"C:\temp\sample_adjusted.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image, adjust gamma, and save as BMP
            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;
                dicomImage.AdjustGamma(1.2f);
                BmpOptions bmpOptions = new BmpOptions();
                dicomImage.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application needs to enhance the brightness of a DICOM scan before converting it to a BMP file for display in a Windows viewer.
 * 2. When developers are building a workflow that extracts DICOM images, applies gamma correction to improve contrast, and stores the result in a BMP format for legacy reporting tools.
 * 3. When a radiology software must preprocess DICOM images by adjusting gamma to a specific value (e.g., 1.2) and then export them as BMPs for integration with non‑DICOM image processing libraries.
 * 4. When a C# program has to verify that a DICOM file exists, create the output folder, and safely convert the image with gamma adjustment to BMP for archival or printing purposes.
 * 5. When an automated batch process needs to load multiple DICOM files, apply consistent gamma correction, and save them as BMPs to ensure uniform visual quality across all exported images.
 */
