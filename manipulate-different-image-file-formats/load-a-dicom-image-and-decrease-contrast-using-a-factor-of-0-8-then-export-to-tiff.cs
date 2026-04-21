using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.dcm";
        string outputPath = @"C:\Images\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image, adjust contrast, and save as TIFF
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Decrease contrast by 20% (negative value reduces contrast)
            dicomImage.AdjustContrast(-20f);

            // Configure TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the adjusted image as TIFF
            dicomImage.Save(outputPath, tiffOptions);
        }
    }
}