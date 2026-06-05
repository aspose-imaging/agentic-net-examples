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
        string inputPath = @"C:\temp\input.dcm";
        string outputPath = @"C:\temp\output.bmp";

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
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Resize to 800x600 using bilinear resampling
                dicomImage.Resize(800, 600, ResizeType.BilinearResample);

                // Save as BMP
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
 * 1. When a medical imaging application needs to convert DICOM scans into BMP files for display on legacy Windows viewers, a developer can use this code to load, resize, and export the images.
 * 2. When integrating radiology data into a hospital’s electronic health record system that only accepts BMP thumbnails, the code resizes the DICOM image to 800 × 600 and saves it in the required format.
 * 3. When building a batch processing tool that prepares DICOM images for machine‑learning models that expect fixed‑size BMP inputs, this snippet handles loading, resizing, and conversion in C#.
 * 4. When a telemedicine platform must generate uniformly sized preview images from DICOM files for web browsers that do not support DICOM, the code provides a simple way to produce 800 × 600 BMP snapshots.
 * 5. When a developer needs to archive DICOM studies as BMP files with a standard resolution for compliance reporting, this example demonstrates how to verify file paths, resize, and save the images using Aspose.Imaging for .NET.
 */