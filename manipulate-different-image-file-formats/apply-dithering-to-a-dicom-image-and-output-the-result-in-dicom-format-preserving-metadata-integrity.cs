using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage to access DICOM‑specific functionality
            DicomImage dicomImage = (DicomImage)image;

            // Apply Floyd‑Steinberg dithering with a 1‑bit palette
            dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

            // Prepare DICOM save options and preserve original metadata
            var options = new DicomOptions
            {
                KeepMetadata = true
            };

            // Save the processed image back to DICOM format
            dicomImage.Save(outputPath, options);
        }
    }
}