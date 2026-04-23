using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

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
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                // Retrieve original dimensions
                int originalWidth = dicomImage.Width;
                int originalHeight = dicomImage.Height;

                // Calculate scaling factor (e.g., reduce size by 50%)
                double scaleFactor = 0.5;
                int newWidth = (int)(originalWidth * scaleFactor);
                int newHeight = (int)(originalHeight * scaleFactor);

                // Resize the image using nearest neighbour resampling
                dicomImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Save the resized image as BMP
                BmpOptions bmpOptions = new BmpOptions();
                dicomImage.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}