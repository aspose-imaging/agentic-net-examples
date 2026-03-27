using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.tif";

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
            // Cast to DicomImage to access DICOM-specific methods
            DicomImage dicomImage = (DicomImage)image;

            // Apply Floyd‑Steinberg dithering with 1‑bit palette
            dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

            // Prepare TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the processed image as TIFF
            dicomImage.Save(outputPath, tiffOptions);
        }
    }
}