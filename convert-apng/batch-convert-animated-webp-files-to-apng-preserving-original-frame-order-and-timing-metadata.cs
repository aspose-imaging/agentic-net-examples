using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded list of animated WebP files to convert
        string[] inputFiles = {
            @"C:\Images\anim1.webp",
            @"C:\Images\anim2.webp"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Determine output path with .apng extension
            string outputPath = Path.ChangeExtension(inputPath, ".apng");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP and save as APNG preserving frames and timing
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new ApngOptions());
            }
        }
    }
}