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
        string inputPath = @"C:\temp\sample.dicom";
        string outputPath = @"C:\temp\sample_brady15.bmp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM‑specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Bradley adaptive thresholding (brightnessDifference = 5, windowSize = 15)
                dicomImage.BinarizeBradley(5, 15);

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
 * 1. When a medical imaging application needs to convert a DICOM radiology scan into a high‑contrast BMP for display on non‑DICOM viewers, a developer can load the DICOM file, apply Bradley adaptive threshold with a window size of 15, and save the result as BMP using Aspose.Imaging for .NET.
 * 2. When a hospital’s PACS integration requires preprocessing of DICOM images to enhance bone structures before archiving them as BMP thumbnails, the code can be used to binarize the image with a 15‑pixel window and export it.
 * 3. When a research project needs to batch‑process DICOM ultrasound images into binary BMP files for machine‑learning feature extraction, a developer can employ this snippet to apply the Bradley thresholding algorithm with a window size of fifteen.
 * 4. When a telemedicine platform must generate lightweight BMP copies of DICOM X‑ray images for fast transmission over low‑bandwidth networks, the code provides a C# solution to load, threshold, and save the images.
 * 5. When a diagnostic software tool wants to create printable BMP versions of DICOM scans with consistent contrast by using the Bradley adaptive threshold (brightness difference 5, window size 15), this example shows how to achieve it with Aspose.Imaging.
 */