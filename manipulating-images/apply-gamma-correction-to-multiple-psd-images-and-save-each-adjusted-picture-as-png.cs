using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input PSD files
        string[] inputPaths = new string[]
        {
            @"C:\Images\sample1.psd",
            @"C:\Images\sample2.psd",
            @"C:\Images\sample3.psd"
        };

        // Corresponding output PNG files
        string[] outputPaths = new string[]
        {
            @"C:\Images\Output\sample1.AdjustGamma.png",
            @"C:\Images\Output\sample2.AdjustGamma.png",
            @"C:\Images\Output\sample3.AdjustGamma.png"
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

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access AdjustGamma
                RasterImage rasterImage = (RasterImage)image;

                // Apply gamma correction (example coefficient 2.5f)
                rasterImage.AdjustGamma(2.5f);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as PNG
                rasterImage.Save(outputPath, new PngOptions());
            }
        }
    }
}