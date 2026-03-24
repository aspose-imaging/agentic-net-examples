using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Aspose.Imaging.FileFormats.Apng.ApngImage apngImage =
            (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Load(inputPath))
        {
            // Check if the image has an alpha channel (transparency)
            bool hasAlpha = apngImage.HasAlpha;
            Console.WriteLine($"Image has alpha channel: {hasAlpha}");

            // Example handling: ensure the saved APNG preserves transparency
            // by setting the appropriate color type in the options
            ApngOptions saveOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha // preserve alpha
            };

            // Save the APNG with the specified options
            apngImage.Save(outputPath, saveOptions);
        }
    }
}