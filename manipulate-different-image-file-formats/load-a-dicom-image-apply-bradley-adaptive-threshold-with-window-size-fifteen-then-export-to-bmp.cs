// HOW-TO: Binarize DICOM Image Using Bradley Adaptive Threshold and Export to BMP in C# (Aspose.Imaging for .NET)
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
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample_binarized.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive thresholding (brightnessDifference = 5, windowSize = 15)
                dicomImage.BinarizeBradley(5.0, 15);

                // Save the processed image as BMP
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
 * 1. When a medical imaging application needs to convert grayscale DICOM scans into high‑contrast black‑and‑white BMP files for easier visual inspection or downstream analysis.
 * 2. When a developer wants to preprocess DICOM radiology images with Bradley adaptive thresholding to improve OCR accuracy on embedded annotations.
 * 3. When integrating Aspose.Imaging into a C# workflow that extracts binary masks from DICOM files for use in machine‑learning segmentation pipelines.
 * 4. When generating thumbnail previews of DICOM studies in BMP format after applying adaptive binarization to reduce file size for web display.
 * 5. When automating batch conversion of DICOM images to BMP with consistent binarization parameters for archival or compliance reporting.
 */
