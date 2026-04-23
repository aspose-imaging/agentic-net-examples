using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\input\sample.cmx";
        string outputPath = @"C:\output\sample.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options with quality 90
            var jpegOptions = new JpegOptions
            {
                Quality = 90
            };

            // Save the image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}