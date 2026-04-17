using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        string inputPath = "input.dcm";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;
            dicomImage.Filter(dicomImage.Bounds, new MedianFilterOptions(5));
            var pngOptions = new PngOptions();
            dicomImage.Save(outputPath, pngOptions);
        }
    }
}