using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output\\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image and ensure it is disposed
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DicomImage for DICOM-specific operations
            DicomImage dicomImage = (DicomImage)image;

            // Create PNG options and ensure they are disposed
            using (var pngOptions = new PngOptions())
            {
                // Save the DICOM image as PNG
                dicomImage.Save(outputPath, pngOptions);
            }
        }
    }
}