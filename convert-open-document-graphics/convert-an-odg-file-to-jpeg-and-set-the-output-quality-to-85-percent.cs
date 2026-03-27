using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\output.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure JPEG save options with quality set to 85%
        JpegOptions jpegOptions = new JpegOptions
        {
            Quality = 85
        };

        // Load the ODG image and save it as JPEG
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, jpegOptions);
        }
    }
}