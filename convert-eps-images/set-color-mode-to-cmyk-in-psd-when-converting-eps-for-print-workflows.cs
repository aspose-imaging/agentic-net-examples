using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\Converted\sample_cmyk.psd";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD saving options with CMYK color mode
            var psdOptions = new PsdOptions
            {
                ColorMode = ColorModes.Cmyk
            };

            // Save the image as a CMYK PSD file
            image.Save(outputPath, psdOptions);
        }

        Console.WriteLine($"EPS file successfully converted to CMYK PSD: {outputPath}");
    }
}