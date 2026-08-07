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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.jpg";
            string baselinePath = @"C:\temp\output\sample_baseline.jpg";
            string progressivePath = @"C:\temp\output\sample_progressive.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(baselinePath));
            Directory.CreateDirectory(Path.GetDirectoryName(progressivePath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Save with default (baseline) compression
                image.Save(baselinePath);

                // Configure progressive compression options
                JpegOptions progressiveOptions = new JpegOptions();
                progressiveOptions.CompressionType = JpegCompressionMode.Progressive;
                progressiveOptions.Quality = 100; // Preserve quality

                // Save with progressive compression
                image.Save(progressivePath, progressiveOptions);
            }

            // Compare file sizes
            long baselineSize = new FileInfo(baselinePath).Length;
            long progressiveSize = new FileInfo(progressivePath).Length;

            Console.WriteLine($"Baseline size: {baselineSize} bytes");
            Console.WriteLine($"Progressive size: {progressiveSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer wants to serve faster‑loading images on a website, they can use this code to convert high‑quality JPEGs to progressive format and verify that the file size reduction meets performance targets.
 * 2. When an e‑commerce platform needs to generate product thumbnails that display incrementally while downloading, the code enables saving progressive JPEGs and comparing their size against baseline compression to ensure optimal bandwidth usage.
 * 3. When a digital asset management system must archive photographs with the smallest possible file size without losing quality, developers can apply progressive compression and programmatically compare sizes to decide which version to store.
 * 4. When a mobile app requires images that render quickly on slow networks, this snippet lets developers create progressive JPEGs and confirm that the progressive file is smaller or comparable to the baseline version before deployment.
 * 5. When a content‑delivery network (CDN) automates image optimization, the code can be integrated into the pipeline to generate progressive JPEGs and log size differences, helping engineers monitor storage savings across large image collections.
 */