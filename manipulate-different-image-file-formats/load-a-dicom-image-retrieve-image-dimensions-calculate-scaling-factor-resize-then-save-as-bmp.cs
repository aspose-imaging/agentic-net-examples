// HOW-TO: Resize DICOM Image to BMP with Scaling Factor in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.dcm";
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

                // Calculate scaling factor (example: reduce size by 50%)
                double scaleFactor = 0.5;
                int newWidth = (int)(originalWidth * scaleFactor);
                int newHeight = (int)(originalHeight * scaleFactor);

                // Resize the image using bilinear resampling
                image.Resize(newWidth, newHeight, ResizeType.BilinearResample);

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
 * 1. When a medical imaging application must convert high‑resolution DICOM scans to smaller BMP files for faster viewing on legacy systems.
 * 2. When a radiology workflow needs to downscale DICOM images by a specific percentage before embedding them into a PDF report.
 * 3. When a hospital’s PACS integration requires extracting image dimensions from DICOM files to calculate custom thumbnail sizes.
 * 4. When a developer wants to automate batch processing that resizes DICOM images and saves them as BMP for use in machine‑learning preprocessing.
 * 5. When a diagnostic software needs to verify that a DICOM file exists, resize it, and store the result in a BMP format compatible with third‑party viewers.
 */
