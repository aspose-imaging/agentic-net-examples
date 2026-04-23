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

        try
        {
            // Open DICOM file stream with high‑performance memory strategy
            using (FileStream stream = File.OpenRead(inputPath))
            {
                var loadOptions = new LoadOptions
                {
                    // Example buffer size hint (256 KB)
                    BufferSizeHint = 256 * 1024
                };

                // Load DICOM image
                using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
                {
                    // Adjust contrast (value range: -100 to 100)
                    dicomImage.AdjustContrast(50f);

                    // Prepare TIFF save options
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                    // Save as TIFF
                    dicomImage.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}