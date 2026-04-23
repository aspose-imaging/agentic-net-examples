using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output\\output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                // Retrieve resolution metadata
                double horizontalResolution = dicomImage.HorizontalResolution;
                double verticalResolution = dicomImage.VerticalResolution;

                // Compute a gamma value based on resolution (example logic)
                float gamma = (float)((horizontalResolution + verticalResolution) / 200.0);
                if (gamma <= 0) gamma = 1.0f;

                // Adjust gamma
                dicomImage.AdjustGamma(gamma);

                // Save as TIFF
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