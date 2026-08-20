// HOW-TO: Convert DICOM to PNG with Fixed Threshold Binarization and Resize in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"c:\temp\sample.dicom";
            string outputPath = @"c:\temp\result.png";

            // Verify input file exists
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
                DicomImage dicomImage = (DicomImage)image;

                // Apply fixed threshold binarization (threshold value 127)
                dicomImage.BinarizeFixed(127);

                // Resize to 500x500 using Bilinear resampling
                dicomImage.Resize(500, 500, ResizeType.BilinearResample);

                // Save the processed image as PNG
                dicomImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to preprocess radiology DICOM files by binarizing and resizing them before feeding them into a diagnostic AI model.
 * 2. When you want to create web‑friendly PNG thumbnails of DICOM scans with a fixed threshold for clear black‑and‑white contrast.
 * 3. When you must convert DICOM images to PNG format for inclusion in electronic health record reports while standardizing the size to 500 × 500 pixels.
 * 4. When you are archiving medical images and need a lightweight binary PNG version that preserves essential details after thresholding.
 * 5. When you are building a desktop C# application that extracts DICOM data, applies fixed‑threshold binarization, and outputs a resized PNG for further image analysis.
 */
