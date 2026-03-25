using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG files
        string[] inputFiles = new[]
        {
            @"C:\Images\example1.svg",
            @"C:\Images\example2.svg",
            @"C:\Images\example3.svg"
        };

        // Hardcoded output directory
        string outputDirectory = @"C:\Images\APNGOutput";

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output file path (same name with .apng extension)
            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".apng");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Save as APNG with a default frame delay (e.g., 100 ms)
                var apngOptions = new ApngOptions
                {
                    DefaultFrameTime = 100 // milliseconds
                };

                image.Save(outputPath, apngOptions);
            }
        }
    }
}