using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (PngImage pngImage = new PngImage(inputPath))
        {
            // Basic image dimensions
            Console.WriteLine($"Width: {pngImage.Width}");
            Console.WriteLine($"Height: {pngImage.Height}");

            // Retrieve original PNG options (preserves original settings)
            ImageOptionsBase baseOptions = pngImage.GetOriginalOptions();
            if (baseOptions is PngOptions pngOptions)
            {
                // Enumerate relevant PNG input parameters
                Console.WriteLine($"BitDepth: {pngOptions.BitDepth}");
                Console.WriteLine($"ColorType: {pngOptions.ColorType}");
                Console.WriteLine($"CompressionLevel: {pngOptions.PngCompressionLevel}");
                Console.WriteLine($"FilterType: {pngOptions.FilterType}");
                Console.WriteLine($"Progressive: {pngOptions.Progressive}");
            }
            else
            {
                Console.WriteLine("Unable to retrieve PNG-specific options.");
            }

            // Save a copy to demonstrate the save workflow
            pngImage.Save(outputPath);
        }
    }
}