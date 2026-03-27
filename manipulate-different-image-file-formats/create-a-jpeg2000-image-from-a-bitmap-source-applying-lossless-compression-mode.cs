using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\source.png";
        string outputPath = @"c:\temp\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the bitmap source
        using (Image bitmap = Image.Load(inputPath))
        {
            // Configure JPEG2000 options for lossless compression (default)
            Jpeg2000Options jpeg2000Options = new Jpeg2000Options
            {
                Irreversible = false // explicit lossless mode
            };

            // Save as JPEG2000 image
            bitmap.Save(outputPath, jpeg2000Options);
        }
    }
}