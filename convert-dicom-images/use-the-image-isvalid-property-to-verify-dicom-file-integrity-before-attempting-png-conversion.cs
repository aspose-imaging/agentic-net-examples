using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\sample.dcm";
        string outputPath = "output\\sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            var pngOptions = new PngOptions();
            dicomImage.Save(outputPath, pngOptions);
        }
    }
}