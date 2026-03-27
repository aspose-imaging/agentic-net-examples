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
            // Cast to DicomImage to access DICOM‑specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply window‑level adjustment.
            // In medical imaging, window level can be approximated by adjusting brightness and contrast.
            // These values are examples; adjust as needed for your data.
            dicomImage.AdjustBrightness(40);   // Increase brightness
            dicomImage.AdjustContrast(30f);    // Increase contrast

            // Save as a 16‑bit PNG for analysis
            var pngOptions = new PngOptions
            {
                // Set the bit depth to 16 bits per channel
                BitDepth = 16
            };
            dicomImage.Save(outputPath, pngOptions);
        }
    }
}