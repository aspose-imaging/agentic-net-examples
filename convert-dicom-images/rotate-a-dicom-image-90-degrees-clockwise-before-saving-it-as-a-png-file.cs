using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.dicom";
        string outputPath = "sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific methods
                if (image is DicomImage dicomImage)
                {
                    // Rotate 90 degrees clockwise without flipping
                    dicomImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // Save as PNG
                    dicomImage.Save(outputPath, new PngOptions());
                }
                else
                {
                    Console.Error.WriteLine("The loaded file is not a DICOM image.");
                }
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
 * 1. When a medical imaging application needs to display a DICOM radiology scan in a web viewer that only supports PNG, a developer can rotate the image 90° clockwise and convert it to PNG using Aspose.Imaging for .NET.
 * 2. When integrating a PACS system with a reporting tool that expects correctly oriented images, a developer can use this code to fix the orientation of DICOM files and export them as PNG thumbnails.
 * 3. When building a batch processing script that prepares DICOM images for machine‑learning training, a developer can rotate each image and save it as PNG to ensure consistent orientation and format.
 * 4. When a hospital’s mobile app must show patient scans in portrait mode, a developer can apply a 90‑degree clockwise rotation to the DICOM image and save it as a PNG for efficient rendering on iOS/Android.
 * 5. When converting legacy DICOM files to a standard image format for archival or documentation purposes, a developer can use this code to rotate the image correctly and store it as a PNG file.
 */