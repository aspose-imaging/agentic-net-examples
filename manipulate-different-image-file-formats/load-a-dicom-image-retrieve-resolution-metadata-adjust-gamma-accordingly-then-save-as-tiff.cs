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
            string inputPath = "input/input.dcm";
            string outputPath = "output/output.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM-specific members
                DicomImage dicomImage = (DicomImage)image;

                // Retrieve resolution metadata
                double horizontalResolution = dicomImage.HorizontalResolution;
                double verticalResolution = dicomImage.VerticalResolution;

                // Adjust gamma based on resolution (example logic)
                float gamma = (horizontalResolution > 300 || verticalResolution > 300) ? 1.2f : 1.0f;
                dicomImage.AdjustGamma(gamma);

                // Save the adjusted image as TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicomImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}