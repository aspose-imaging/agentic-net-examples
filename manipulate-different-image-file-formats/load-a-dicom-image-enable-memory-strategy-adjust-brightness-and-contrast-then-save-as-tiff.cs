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

        // Configure memory strategy
        LoadOptions loadOptions = new LoadOptions
        {
            BufferSizeHint = 256 * 1024 // 256 KB buffer size hint
        };

        // Load DICOM image with memory strategy
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath, loadOptions))
        {
            // Adjust brightness and contrast
            dicomImage.AdjustBrightness(50);      // Increase brightness
            dicomImage.AdjustContrast(30f);       // Increase contrast

            // Prepare TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save as TIFF
            dicomImage.Save(outputPath, tiffOptions);
        }
    }
}