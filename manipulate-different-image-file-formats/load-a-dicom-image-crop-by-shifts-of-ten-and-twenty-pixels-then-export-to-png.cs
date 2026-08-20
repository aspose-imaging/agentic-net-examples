// HOW-TO: Crop DICOM Image By Pixels And Save As PNG In C# (Aspose.Imaging for .NET)
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
        string inputPath = @"c:\temp\sample.dicom";
        string outputPath = @"c:\temp\sample.cropped.png";

        try
        {
            // Check if the input file exists
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

                // Crop: leftShift=10, rightShift=10, topShift=20, bottomShift=20
                dicomImage.Crop(10, 10, 20, 20);

                // Save the cropped image as PNG
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
 * 1. When a medical imaging application needs to remove unwanted borders from a DICOM scan before displaying it in a web viewer.
 * 2. When a radiology workflow requires extracting the central region of a DICOM file and converting it to a lightweight PNG for reporting.
 * 3. When a developer wants to automate batch processing of DICOM files, cropping a fixed number of pixels and storing the result as PNG for archival.
 * 4. When integrating DICOM images into a C# desktop app that only supports PNG, and a consistent crop offset must be applied to all images.
 * 5. When preparing DICOM screenshots for machine‑learning training, trimming edges and saving them in PNG format for easier loading.
 */
