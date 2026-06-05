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
        string inputPath = @"C:\temp\sample.dicom";
        string outputPath = @"C:\temp\sample.BinarizeBradley15x15.bmp";

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
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a medical imaging application needs to convert a DICOM radiograph to a high‑contrast BMP for display on legacy systems, a developer can load the DICOM, apply Bradley adaptive threshold with a 15‑pixel window, and save the result as BMP.
 * 2. When building a batch‑processing tool that prepares DICOM scans for OCR by binarizing them with a 15×15 window and exporting to BMP, this code provides the necessary C# workflow.
 * 3. When integrating Aspose.Imaging into a C# PACS viewer to enhance bone‑structure visibility by applying Bradley adaptive thresholding (window size 15) before saving the image as BMP for downstream analysis.
 * 4. When a research project requires extracting binary masks from DICOM ultrasound images for machine‑learning training, developers can use this snippet to binarize with a 15‑pixel window and output BMP files.
 * 5. When a hospital IT team needs to generate printable BMP copies of DICOM X‑ray images with consistent thresholding (brightness difference 5, window size 15) for patient records, this code automates the conversion.
 */