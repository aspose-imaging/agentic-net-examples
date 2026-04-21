using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Temp\sample.psd";
            string outputPath = @"C:\Temp\sample_converted.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Configure PNG save options with high‑quality smoothing
                PngOptions pngOptions = new PngOptions();

                // Set vector rasterization options to enable anti‑aliasing (high quality smoothing)
                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                {
                    // Use AntiAlias for the best visual fidelity
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                };

                pngOptions.VectorRasterizationOptions = vectorOptions;

                // Save the image as PNG with the specified options
                psdImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}