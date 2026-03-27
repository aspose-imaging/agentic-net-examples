using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
        {
            DicomImage dicomImage = (DicomImage)image;
            dicomImage.BinarizeOtsu();
            dicomImage.Save(outputPath, tiffOptions);
        }
    }
}