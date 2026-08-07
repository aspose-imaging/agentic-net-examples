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
        string outputPath = @"C:\Images\resized.bmp";

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
 * 1. When a medical imaging application must convert DICOM scans to BMP thumbnails for fast preview in a C# .NET user interface.
 * 2. When a healthcare data pipeline needs to downscale large DICOM images by 50 % before storing them as BMP files to reduce storage costs.
 * 3. When a diagnostic tool requires extracting the original width and height of a DICOM image to calculate a scaling factor for consistent image resizing.
 * 4. When a .NET service processes incoming DICOM files, resizes them using nearest‑neighbour resampling, and saves the result as BMP for compatibility with legacy Windows viewers.
 * 5. When a batch‑processing script validates the existence of a DICOM file, creates the output directory, and safely resizes and converts the image to BMP while handling runtime exceptions.
 */