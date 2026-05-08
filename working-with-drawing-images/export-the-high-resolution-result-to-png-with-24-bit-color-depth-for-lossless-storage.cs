using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options for 24‑bit (Truecolor) output with high resolution
                PngOptions pngOptions = new PngOptions
                {
                    // Truecolor = 24‑bit (8 bits per channel, no alpha channel)
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.Truecolor,
                    BitDepth = 8,
                    // Set a high DPI for high‑resolution export (e.g., 300 DPI)
                    ResolutionSettings = new ResolutionSetting(300.0, 300.0)
                };

                // Save the image as PNG using the specified options
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}