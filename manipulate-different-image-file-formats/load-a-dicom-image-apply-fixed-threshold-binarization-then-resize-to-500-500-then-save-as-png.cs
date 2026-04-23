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
        string inputPath = @"C:\Images\sample.dicom";
        string outputPath = @"C:\Images\Result\sample_processed.png";

        // Ensure any runtime exception is reported without crashing
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
                // Cast to DicomImage to access DICOM‑specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply fixed‑threshold binarization (threshold value 127)
                dicomImage.BinarizeFixed(127);

                // Resize to 500×500 using bilinear resampling
                dicomImage.Resize(500, 500, ResizeType.BilinearResample);

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