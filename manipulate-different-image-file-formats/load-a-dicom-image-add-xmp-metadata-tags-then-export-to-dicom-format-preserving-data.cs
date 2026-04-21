using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = "input.dcm";
        string outputPath = "output.dcm";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DicomImage image = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
        {
            var options = new DicomOptions
            {
                KeepMetadata = true
            };

            image.Save(outputPath, options);
        }
    }
}