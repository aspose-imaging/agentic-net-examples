using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set memory strategy via LoadOptions
            var loadOptions = new Aspose.Imaging.LoadOptions
            {
                BufferSizeHint = 256 * 1024 // 256 KB buffer size hint
            };

            // Load DICOM image with memory strategy
            using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                // Adjust brightness and contrast
                dicomImage.AdjustBrightness(30);      // Increase brightness
                dicomImage.AdjustContrast(20f);       // Increase contrast

                // Prepare TIFF save options
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the processed image as TIFF
                dicomImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}