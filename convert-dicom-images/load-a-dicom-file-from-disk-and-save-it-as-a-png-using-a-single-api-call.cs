using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.dcm";
        string outputPath = "output\\converted.png";

        // Verify that the input DICOM file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image and save it as PNG in a single call
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            image.Save(outputPath, new PngOptions());
        }
    }
}