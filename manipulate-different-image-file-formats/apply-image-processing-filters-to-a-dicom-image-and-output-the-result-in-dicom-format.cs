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
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

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
            // Apply a simple brightness adjustment to each page
            foreach (DicomPage page in dicomImage.DicomPages)
            {
                // Increase brightness by 20 (value can be adjusted as needed)
                page.AdjustBrightness(20);
            }

            // Set DICOM save options (e.g., RGB 24‑bit color)
            var options = new DicomOptions
            {
                ColorType = ColorType.Rgb24Bit
            };

            // Save the processed image back to DICOM format
            dicomImage.Save(outputPath, options);
        }
    }
}