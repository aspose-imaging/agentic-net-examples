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
            // Hardcoded input PSD files and corresponding output PNG files
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.psd",
                @"C:\Images\input2.psd"
            };

            string[] outputPaths = new string[]
            {
                @"C:\Images\output1.png",
                @"C:\Images\output2.png"
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Adjust brightness if the image supports raster operations
                    if (image is RasterImage rasterImage)
                    {
                        // Increase brightness uniformly (value range: -255 to 255)
                        rasterImage.AdjustBrightness(50);
                    }

                    // Save the brightened image as PNG
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}