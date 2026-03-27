using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.cmyk.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare JPEG save options with CMYK color type
            JpegOptions saveOptions = new JpegOptions
            {
                ColorType = JpegCompressionColorMode.Cmyk
            };

            // Save the image as CMYK JPEG
            image.Save(outputPath, saveOptions);
        }

        Console.WriteLine($"Image saved as CMYK JPEG to: {outputPath}");
    }
}