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
        string inputPath = @"C:\Images\sample.dicom";
        string outputPath = @"C:\Images\sample_brightness20.png";

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
                // Cast to DicomImage to access AdjustBrightness
                DicomImage dicomImage = (DicomImage)image;

                // Increase brightness by 20 units
                dicomImage.AdjustBrightness(20);

                // Save as PNG
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
 * 1. When a medical imaging application needs to convert DICOM scans to PNG thumbnails with enhanced visibility for web previews, a developer can use this code to load the DICOM, boost brightness by 20 units, and save the result as PNG.
 * 2. When integrating radiology data into a hospital’s electronic health record system that only supports PNG, a developer can apply the code to increase the brightness of the DICOM image for better readability before storing it.
 * 3. When building a diagnostic reporting tool that extracts DICOM images and displays them on a tablet, a developer can use this snippet to adjust the image’s brightness and output a PNG that matches the device’s display profile.
 * 4. When creating a batch‑processing pipeline that normalizes the visual contrast of DICOM files for machine‑learning preprocessing, a developer can employ this code to raise brightness by a fixed amount and export each image as PNG.
 * 5. When developing a tele‑medicine portal that streams patient scans as lightweight PNGs with improved illumination, a developer can leverage this example to load the DICOM, apply a 20‑unit brightness increase, and save the PNG for fast delivery.
 */