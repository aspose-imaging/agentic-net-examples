using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.jpg";
            string progressivePath = @"C:\temp\output_progressive.jpg";
            string baselinePath = @"C:\temp\output_baseline.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(progressivePath));
            Directory.CreateDirectory(Path.GetDirectoryName(baselinePath));

            // Load the source JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // ---------- Save with Progressive compression ----------
                JpegOptions progressiveOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 100 // optional, keep maximum quality
                };
                image.Save(progressivePath, progressiveOptions);

                // ---------- Save with Baseline (default) compression ----------
                JpegOptions baselineOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Baseline,
                    Quality = 100 // optional, keep maximum quality
                };
                image.Save(baselinePath, baselineOptions);
            }

            // Compare file sizes
            long progressiveSize = new FileInfo(progressivePath).Length;
            long baselineSize = new FileInfo(baselinePath).Length;

            Console.WriteLine($"Progressive JPEG size: {progressiveSize} bytes");
            Console.WriteLine($"Baseline JPEG size:   {baselineSize} bytes");

            if (progressiveSize < baselineSize)
                Console.WriteLine("Progressive compression produced a smaller file.");
            else if (progressiveSize > baselineSize)
                Console.WriteLine("Baseline compression produced a smaller file.");
            else
                Console.WriteLine("Both files have the same size.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer wants to generate progressive JPEGs for faster incremental loading on browsers and compare their file size against baseline JPEGs to decide which format reduces bandwidth.
 * 2. When an e‑commerce platform needs to create high‑quality product images with Aspose.Imaging in C# and evaluate whether progressive compression yields smaller files than baseline compression for SEO‑friendly page speed.
 * 3. When a desktop application processes user‑uploaded photos and must save both progressive and baseline JPEG versions to support older devices while measuring the storage impact of each compression mode.
 * 4. When a digital asset management system automates image optimization by converting source JPEGs to progressive format using JpegOptions and then logs the size difference to monitor storage savings.
 * 5. When a developer is troubleshooting image rendering issues and uses Aspose.Imaging to toggle between progressive and baseline JPEG compression in C# to compare file sizes and identify the optimal setting for a given quality level.
 */