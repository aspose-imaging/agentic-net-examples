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
        string outputPath = "output\\output.tiff";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Retrieve resolution metadata
            double horizontalResolution = dicomImage.HorizontalResolution;
            double verticalResolution = dicomImage.VerticalResolution;

            // Compute gamma based on resolution (example calculation)
            float gamma = (float)((horizontalResolution + verticalResolution) / 200.0);

            // Adjust gamma
            dicomImage.AdjustGamma(gamma);

            // Prepare TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save as TIFF
            dicomImage.Save(outputPath, tiffOptions);
        }
    }
}