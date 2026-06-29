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
            string outputPath = @"C:\Images\resized.bmp";

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
 * 1. When a hospital IT system needs to convert high‑resolution DICOM scans into smaller BMP files for quick preview in a web portal, this code can load the DICOM image, shrink it by a calculated factor, and save the result as BMP.
 * 2. When a research lab wants to batch‑process radiology images to reduce storage costs while preserving basic visual information, they can use this snippet to read each DICOM file, apply a 50 % scaling, and store the downsized bitmap.
 * 3. When a medical device manufacturer must generate thumbnail BMP icons from DICOM files for inclusion in a device’s UI, the code demonstrates how to retrieve the original dimensions, compute a scaling factor, resize with nearest‑neighbour resampling, and export the thumbnail.
 * 4. When a compliance audit requires exporting DICOM images to a non‑proprietary format for long‑term archival, developers can employ this example to load the DICOM, resize it to a manageable size, and save it as a BMP using Aspose.Imaging for .NET.
 * 5. When a telemedicine application needs to send reduced‑size BMP snapshots of patient scans over low‑bandwidth connections, this program shows how to programmatically load the DICOM, calculate new width and height, resize the image, and write the BMP to disk.
 */