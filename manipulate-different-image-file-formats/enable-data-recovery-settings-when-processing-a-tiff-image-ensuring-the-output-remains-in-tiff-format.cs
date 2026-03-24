using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.tif";
        string outputPath = @"C:\Temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure load options with data recovery
        LoadOptions loadOptions = new LoadOptions
        {
            DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
            DataBackgroundColor = Color.White
        };

        // Load the TIFF image with recovery settings
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Prepare TIFF save options (default format)
            TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the recovered image back to TIFF
            image.Save(outputPath, saveOptions);
        }
    }
}