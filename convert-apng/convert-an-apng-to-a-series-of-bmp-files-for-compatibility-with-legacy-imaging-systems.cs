using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input APNG file and output directory
        string inputPath = Path.Combine("Input", "animation.apng");
        string outputDirectory = "Output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the APNG image
        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            int frameCount = apng.PageCount;

            for (int i = 0; i < frameCount; i++)
            {
                // Get the current frame as a raster image
                using (RasterImage frame = (RasterImage)apng.Pages[i])
                {
                    // Build output BMP file path
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i + 1}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as BMP
                    BmpOptions bmpOptions = new BmpOptions();
                    frame.Save(outputPath, bmpOptions);
                }
            }
        }
    }
}