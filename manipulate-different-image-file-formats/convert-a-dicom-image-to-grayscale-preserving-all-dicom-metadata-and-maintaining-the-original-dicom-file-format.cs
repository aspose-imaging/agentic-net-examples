using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.dcm";
        string outputPath = @"C:\temp\sample_grayscale.dcm";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image, convert to grayscale, and save preserving metadata
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicomImage = (DicomImage)image;
            dicomImage.Grayscale();

            var options = new DicomOptions
            {
                KeepMetadata = true
            };

            dicomImage.Save(outputPath, options);
        }
    }
}