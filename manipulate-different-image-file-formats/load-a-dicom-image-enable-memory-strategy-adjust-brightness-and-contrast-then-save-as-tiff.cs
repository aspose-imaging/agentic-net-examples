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

            // Load DICOM image with memory buffer hint
            var loadOptions = new LoadOptions { BufferSizeHint = 256 * 1024 };
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var dicomImage = (DicomImage)image;

                // Adjust brightness and contrast
                dicomImage.AdjustBrightness(50);      // range [-255, 255]
                dicomImage.AdjustContrast(30f);      // range [-100, 100]

                // Save as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicomImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}