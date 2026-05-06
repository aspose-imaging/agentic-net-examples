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
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.j2k";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image pngImage = Image.Load(inputPath))
            {
                // Configure JPEG2000 options for lossless compression and buffer size hint
                Jpeg2000Options options = new Jpeg2000Options
                {
                    Irreversible = false,               // lossless DWT 5-3
                    BufferSizeHint = 10 * 1024 * 1024   // example buffer limit (10 MB)
                };

                // Save as JPEG2000 using the configured options
                pngImage.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}