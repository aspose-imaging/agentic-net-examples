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
        string inputPath = "input.dcm";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)dicomImage;
            raster.BinarizeOtsu();

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            dicomImage.Save(outputPath, tiffOptions);
        }
    }
}