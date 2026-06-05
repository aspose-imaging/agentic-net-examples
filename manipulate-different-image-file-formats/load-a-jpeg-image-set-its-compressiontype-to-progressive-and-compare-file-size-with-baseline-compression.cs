using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string baselineOutputPath = @"C:\temp\output_baseline.jpg";
        string progressiveOutputPath = @"C:\temp\output_progressive.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(baselineOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(progressiveOutputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Save with baseline compression
                JpegOptions baselineOptions = new JpegOptions();
                baselineOptions.CompressionType = JpegCompressionMode.Baseline;
                baselineOptions.Quality = 100; // optional quality setting
                image.Save(baselineOutputPath, baselineOptions);

                // Save with progressive compression
                JpegOptions progressiveOptions = new JpegOptions();
                progressiveOptions.CompressionType = JpegCompressionMode.Progressive;
                progressiveOptions.Quality = 100; // optional quality setting
                image.Save(progressiveOutputPath, progressiveOptions);
            }

            // Compare file sizes
            long baselineSize = new FileInfo(baselineOutputPath).Length;
            long progressiveSize = new FileInfo(progressiveOutputPath).Length;

            Console.WriteLine($"Baseline size: {baselineSize} bytes");
            Console.WriteLine($"Progressive size: {progressiveSize} bytes");
            Console.WriteLine($"Size difference (baseline - progressive): {baselineSize - progressiveSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer wants to generate progressive JPEGs for faster perceived loading on browsers while comparing file size against baseline JPEGs.
 * 2. When a desktop application needs to convert user‑uploaded photos to high‑quality JPEGs with optional progressive encoding to reduce bandwidth usage.
 * 3. When a digital asset management system must evaluate storage savings by switching from baseline to progressive JPEG compression using Aspose.Imaging in C#.
 * 4. When a photo‑editing tool wants to offer an option to save images as progressive JPEGs and display the size difference to the user.
 * 5. When a batch‑processing script needs to verify that changing the JpegCompressionMode from Baseline to Progressive does not degrade image quality while measuring file size impact.
 */