// HOW-TO: Adjust Gamma of DNG Image to 2.2 and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"c:\temp\sample.dng";
            string outputPath = @"c:\temp\sample.adjusted.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;

                // Apply gamma correction (2.2) to all colour channels
                dngImage.AdjustGamma(2.2f);

                // Save the result as PNG
                dngImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a photographer needs to correct the exposure of a raw DNG file for web display by applying a 2.2 gamma curve and converting it to a lightweight PNG format using C#.
 * 2. When a scientific imaging application must standardize the gamma of raw sensor data (DNG) before archiving it as lossless PNG files for downstream analysis.
 * 3. When an e‑commerce platform wants to generate product thumbnails from raw camera shots, adjusting gamma to match typical monitor settings and saving them as PNGs via Aspose.Imaging in .NET.
 * 4. When a mobile app backend processes user‑uploaded DNG photos, applying gamma correction to improve visual consistency and exporting the result as PNG for fast delivery.
 * 5. When a batch‑processing tool automates the conversion of a collection of DNG images to PNG while ensuring a consistent 2.2 gamma for accurate color reproduction in C# projects.
 */
