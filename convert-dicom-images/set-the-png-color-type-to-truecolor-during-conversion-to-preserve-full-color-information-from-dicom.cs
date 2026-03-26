using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.dcm";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
        Directory.CreateDirectory(outputDir);

        // Load the DICOM image
        using (Image dicomImage = Image.Load(inputPath))
        {
            // Configure PNG options with Truecolor color type
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.Truecolor
            };

            // Save the image as PNG using the specified options
            dicomImage.Save(outputPath, pngOptions);
        }
    }
}