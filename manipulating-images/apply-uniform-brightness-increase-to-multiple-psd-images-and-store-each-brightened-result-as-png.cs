using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\input\image1.psd",
            @"C:\Images\input\image2.psd",
            @"C:\Images\input\image3.psd"
        };

        string[] outputPaths = new string[]
        {
            @"C:\Images\output\image1.png",
            @"C:\Images\output\image2.png",
            @"C:\Images\output\image3.png"
        };

        // Process each file
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
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Adjust brightness (increase by 50)
                if (image is RasterImage rasterImage)
                {
                    rasterImage.AdjustBrightness(50);
                }

                // Save as PNG
                image.Save(outputPath, new PngOptions());
            }
        }
    }
}