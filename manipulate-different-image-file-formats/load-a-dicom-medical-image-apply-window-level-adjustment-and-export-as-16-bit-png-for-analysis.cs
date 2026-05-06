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
            string inputPath = @"C:\Images\input.dcm";
            string outputPath = @"C:\Images\output.png";

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
                // Cast to DicomImage to access DICOM‑specific operations
                DicomImage dicomImage = (DicomImage)image;

                // Apply window level adjustment (simulated with brightness/contrast)
                // AdjustBrightness: range [-255, 255]
                // AdjustContrast: range [-100, 100]
                dicomImage.AdjustBrightness(40);   // Example window level shift
                dicomImage.AdjustContrast(30f);    // Example window width scaling

                // Save as 16‑bit PNG
                var pngOptions = new PngOptions
                {
                    BitDepth = 16 // 16‑bit per channel
                };
                dicomImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}