// HOW-TO: Apply Bradley Adaptive Threshold to DICOM and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dcm";
            string outputPath = "output.bmp";

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
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive thresholding (brightnessDifference: 5, windowSize: 10)
                dicomImage.BinarizeBradley(5, 10);

                // Rotate the image 180 degrees
                dicomImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

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
 * 1. When you need to convert a medical DICOM scan into a high‑contrast BMP for analysis by legacy imaging software.
 * 2. When you must preprocess radiology images by binarizing them with Bradley adaptive threshold before performing automated measurements.
 * 3. When you require rotating a DICOM image 180° to correct orientation after acquisition and then export it for reporting.
 * 4. When integrating Aspose.Imaging into a C# workflow to transform DICOM files into BMP format for storage in a non‑DICOM archive.
 * 5. When building a batch process that applies adaptive thresholding and rotation to multiple DICOM files before feeding them into a machine‑learning model that expects BMP inputs.
 */
