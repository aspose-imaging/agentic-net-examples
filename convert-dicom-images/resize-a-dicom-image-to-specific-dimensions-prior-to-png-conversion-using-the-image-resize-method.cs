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
            string inputPath = "c:\\temp\\sample.dicom";
            string outputPath = "c:\\temp\\resized.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                // Resize to the desired dimensions (e.g., 800x600) using Bilinear resampling
                int newWidth = 800;
                int newHeight = 600;
                image.Resize(newWidth, newHeight, ResizeType.BilinearResample);

                // Save the resized image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging web portal needs fast‑loading thumbnail previews of DICOM scans, developers resize the image to 800×600 and convert it to PNG for browser display.
 * 2. When generating PDF radiology reports, developers downscale DICOM images to fit the page layout and save them as PNG to ensure the PDF library can embed the graphics.
 * 3. When preparing training data for a machine‑learning model, developers resize DICOM files to a uniform resolution and convert them to PNG to provide consistent, lightweight inputs.
 * 4. When a hospital’s PACS must transmit scans to a third‑party viewer that only accepts PNG, developers resize the DICOM image to a manageable size and perform the format conversion.
 * 5. When an electronic health record system stores patient scan thumbnails for quick lookup, developers use this code to downscale the original DICOM and save it as a PNG thumbnail.
 */