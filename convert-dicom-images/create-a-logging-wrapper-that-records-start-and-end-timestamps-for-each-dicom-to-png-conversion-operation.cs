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
        string inputPath = "sample.dicom";
        string outputPath = "sample.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Perform conversion with logging
            ConvertDicomToPng(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertDicomToPng(string inputPath, string outputPath)
    {
        // Log start timestamp
        Console.WriteLine($"Conversion started: {DateTime.Now:O}");

        // Open the DICOM file as a stream and load it
        using (Stream stream = File.OpenRead(inputPath))
        using (DicomImage dicomImage = new DicomImage(stream))
        {
            // Save the DICOM image as PNG
            dicomImage.Save(outputPath, new PngOptions());
        }

        // Log end timestamp
        Console.WriteLine($"Conversion finished: {DateTime.Now:O}");
    }
}