using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM‑specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive thresholding (brightnessDifference = 5, windowSize = 10)
                dicomImage.BinarizeBradley(5, 10);

                // Rotate the image 180 degrees
                dicomImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Save the processed image as BMP
                dicomImage.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology software needs to preprocess a DICOM X‑ray by binarizing it with Bradley adaptive thresholding, rotating the image 180° for correct orientation, and exporting the result as a BMP for legacy PACS integration, this code provides a ready‑to‑use C# solution.
 * 2. When a medical research application must convert DICOM ultrasound frames into high‑contrast black‑and‑white BMP files for machine‑learning model training, applying Bradley thresholding and a 180° rotation ensures consistent input data.
 * 3. When a hospital’s document‑archiving system requires automated conversion of DICOM scans into BMP thumbnails that are upright after a 180° flip, the code handles loading, adaptive binarization, rotation, and saving in one workflow.
 * 4. When a telemedicine platform needs to generate BMP snapshots from DICOM images with enhanced edge definition via Bradley binarization and correct patient‑side orientation by rotating 180°, developers can use this snippet in C#.
 * 5. When a quality‑control tool for medical imaging devices must validate DICOM output by creating rotated, thresholded BMP copies for visual inspection, this example demonstrates the complete process with Aspose.Imaging for .NET.
 */