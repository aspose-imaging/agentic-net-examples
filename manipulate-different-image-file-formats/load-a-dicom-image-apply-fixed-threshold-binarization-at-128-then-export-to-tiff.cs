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
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/sample.tiff";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image, apply binarization, and save as TIFF
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;
            dicomImage.BinarizeFixed(128); // Fixed threshold binarization at 128

            // Configure TIFF options (default format)
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            dicomImage.Save(outputPath, tiffOptions);
        }
    }
}