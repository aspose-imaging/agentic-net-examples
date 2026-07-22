using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.dicom";
        string outputPath = @"C:\Temp\output.bmp";

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
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Adjust gamma to 1.2 for all channels
                dicomImage.AdjustGamma(1.2f);

                // Save the result as BMP
                dicomImage.Save(outputPath, new BmpOptions());
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
 * 1. When a medical imaging application needs to convert a DICOM radiology scan to a BMP file for display on a Windows workstation while applying a gamma correction of 1.2 to improve visual contrast.
 * 2. When a healthcare data pipeline must preprocess DICOM images by adjusting gamma before exporting them as BMPs for integration with legacy reporting tools that only accept BMP format.
 * 3. When a developer is building a C# utility to batch‑process DICOM files, applying a uniform gamma boost of 1.2 and saving the results as BMPs for use in training machine‑learning models that require standard image formats.
 * 4. When a radiology research project requires extracting DICOM images, enhancing their brightness via gamma adjustment, and storing them as BMPs to embed in PDF documents or presentations.
 * 5. When an electronic health record (EHR) system needs to generate thumbnail BMP previews of DICOM studies with a gamma of 1.2 to ensure consistent appearance across different browsers and devices.
 */