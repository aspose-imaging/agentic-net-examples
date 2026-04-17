using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DicomImage dicom = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
        {
            PngOptions options = new PngOptions();
            dicom.Save(outputPath, options);
        }

        long inputSize = new FileInfo(inputPath).Length;
        long outputSize = new FileInfo(outputPath).Length;

        Console.WriteLine($"Input DICOM size: {inputSize} bytes");
        Console.WriteLine($"Output PNG size: {outputSize} bytes");
        Console.WriteLine($"Size difference: {outputSize - inputSize} bytes");
    }
}