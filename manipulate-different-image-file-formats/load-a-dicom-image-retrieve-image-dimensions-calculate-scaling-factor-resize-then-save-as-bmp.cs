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
            string inputPath = @"C:\Images\sample.dicom";
            string outputPath = @"C:\Images\sample_resized.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                // Retrieve original dimensions
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // Calculate scaling factor (e.g., reduce size by 50%)
                double scaleFactor = 0.5;
                int newWidth = (int)(originalWidth * scaleFactor);
                int newHeight = (int)(originalHeight * scaleFactor);

                // Resize the image using nearest neighbour resampling
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Save the resized image as BMP
                BmpOptions bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
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
 * 1. When a medical imaging application must convert high‑resolution DICOM scans to smaller BMP files for quick preview in a Windows desktop viewer.
 * 2. When a radiology PACS integration needs to generate thumbnail BMP images from original DICOM studies for display in a web‑based patient portal.
 * 3. When a C# batch‑processing tool has to resize DICOM X‑ray images by a fixed percentage before archiving them in a legacy BMP‑only archive.
 * 4. When a diagnostic software component requires extracting the dimensions of a DICOM image, applying a scaling factor, and saving the result as a BMP to be consumed by a third‑party analysis library.
 * 5. When an automated workflow must verify the existence of a DICOM file, resize it using nearest‑neighbour resampling, and output a BMP for use in printed reports.
 */