using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputDirectory = @"c:\temp\output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates parent directories as needed)
        Directory.CreateDirectory(outputDirectory);

        // Define the set of PNG filter types to apply
        PngFilterType[] filterTypes = new PngFilterType[]
        {
            PngFilterType.None,
            PngFilterType.Up,
            PngFilterType.Sub,
            PngFilterType.Paeth,
            PngFilterType.Avg,
            PngFilterType.Adaptive
        };

        // Load the source image once
        using (Image image = Image.Load(inputPath))
        {
            foreach (PngFilterType filter in filterTypes)
            {
                // Prepare PNG save options with the current filter type
                PngOptions options = new PngOptions
                {
                    FilterType = filter,
                    CompressionLevel = 9,               // Max compression (optional)
                    Progressive = true                  // Keep progressive loading (optional)
                };

                // Build the output file path
                string outputPath = Path.Combine(outputDirectory, $"output_{filter}.png");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image using the specified PNG options
                image.Save(outputPath, options);
            }
        }
    }
}