using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

        // Load DICOM image with memory buffer hint
        using (Stream stream = File.OpenRead(inputPath))
        {
            var loadOptions = new LoadOptions();
            loadOptions.BufferSizeHint = 256 * 1024; // 256 KB buffer

            using (Aspose.Imaging.FileFormats.Dicom.DicomImage dicomImage = new Aspose.Imaging.FileFormats.Dicom.DicomImage(stream, loadOptions))
            {
                // Adjust brightness and contrast
                dicomImage.AdjustBrightness(30);      // Example brightness value
                dicomImage.AdjustContrast(20f);       // Example contrast value

                // Save the adjusted image as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicomImage.Save(outputPath, tiffOptions);
            }
        }
    }
}