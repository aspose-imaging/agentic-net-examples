using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output\\output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;

            double horizontalResolution = dicomImage.HorizontalResolution;
            double verticalResolution = dicomImage.VerticalResolution;

            float gamma = (horizontalResolution > 300 || verticalResolution > 300) ? 1.2f : 1.0f;
            dicomImage.AdjustGamma(gamma);

            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                dicomImage.Save(outputPath, tiffOptions);
            }
        }
    }
}