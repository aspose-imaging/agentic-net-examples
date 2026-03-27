using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PSD save options
            PsdOptions psdOptions = new PsdOptions();

            // Set desired resolution (e.g., 300 DPI for both axes)
            psdOptions.ResolutionSettings = new ResolutionSetting(300.0, 300.0);

            // Save the image as PSD with the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}