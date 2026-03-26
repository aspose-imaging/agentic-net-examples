using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output\\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image and save as PNG
        using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
        {
            using (PngOptions pngOptions = new PngOptions())
            {
                dicomImage.Save(outputPath, pngOptions);
            }
        }
    }
}