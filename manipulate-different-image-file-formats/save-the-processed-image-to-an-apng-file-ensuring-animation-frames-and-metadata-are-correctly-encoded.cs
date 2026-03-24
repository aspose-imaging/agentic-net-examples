using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates if null path)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        // Load the source image (supports animated formats)
        using (Image sourceImage = Image.Load(inputPath))
        {
            // Configure APNG options: default frame duration and infinite looping
            var apngOptions = new ApngOptions
            {
                DefaultFrameTime = 200, // milliseconds per frame
                NumPlays = 0,            // 0 = infinite loop
                KeepMetadata = true     // preserve original metadata
            };

            // Save the image as an animated PNG (APNG)
            sourceImage.Save(outputPath, apngOptions);
        }
    }
}