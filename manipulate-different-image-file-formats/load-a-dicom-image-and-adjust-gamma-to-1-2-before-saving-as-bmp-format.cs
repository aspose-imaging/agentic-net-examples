using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample_adjusted.bmp";

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
                // Cast to DicomImage to access AdjustGamma
                DicomImage dicomImage = (DicomImage)image;

                // Apply gamma correction (1.2 for all channels)
                dicomImage.AdjustGamma(1.2f);

                // Save as BMP format
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
 * 1. When a medical imaging application needs to convert a DICOM radiology scan to a BMP file with increased brightness by applying a gamma of 1.2 for better visual inspection.
 * 2. When a healthcare IT system must export DICOM images to a legacy Windows viewer that only supports BMP, and the developer wants to adjust gamma to improve contrast before saving.
 * 3. When a research tool processes DICOM ultrasound images and requires a quick C# routine to apply gamma correction and store the result as BMP for inclusion in reports.
 * 4. When a PACS integration script needs to batch‑convert DICOM files to BMP while normalizing gamma to 1.2 to ensure consistent appearance across different monitors.
 * 5. When a diagnostic software developer wants to demonstrate Aspose.Imaging’s DicomImage.AdjustGamma method by loading a DICOM file, adjusting its gamma, and saving the output as a BMP image in a .NET environment.
 */