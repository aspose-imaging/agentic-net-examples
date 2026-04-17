using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of animated WebP files to convert
        string[] inputFiles = new string[]
        {
            @"C:\Images\anim1.webp",
            @"C:\Images\anim2.webp"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output path (same folder, .png extension)
            string outputPath = Path.ChangeExtension(inputPath, ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Save as APNG, preserving metadata (including frame timing)
                var apngOptions = new ApngOptions
                {
                    KeepMetadata = true
                };
                image.Save(outputPath, apngOptions);
            }
        }
    }
}