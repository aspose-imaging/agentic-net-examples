using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input\\large_image.png";
        string outputPath = "output\\large_image_copy.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG with a memory buffer hint to limit internal memory usage
        var loadOptions = new LoadOptions { BufferSizeHint = 100 }; // 100 MB buffer hint
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Prepare PNG save options to preserve fidelity and metadata
            var saveOptions = new PngOptions
            {
                CompressionLevel = 9,      // Maximum lossless compression
                KeepMetadata = true        // Preserve original metadata
            };

            // Save the image to the output path
            image.Save(outputPath, saveOptions);
        }
    }
}