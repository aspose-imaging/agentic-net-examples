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
        string inputPath = "input.jpg";
        string progressiveOutputPath = "output_progressive.jpg";
        string baselineOutputPath = "output_baseline.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(progressiveOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(baselineOutputPath));

        // Load the source JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Save with progressive compression
            JpegOptions progressiveOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Progressive,
                Quality = 100 // optional, keep maximum quality
            };
            image.Save(progressiveOutputPath, progressiveOptions);

            // Save with baseline compression for comparison
            JpegOptions baselineOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Baseline,
                Quality = 100
            };
            image.Save(baselineOutputPath, baselineOptions);
        }

        // Compare file sizes
        long progressiveSize = new FileInfo(progressiveOutputPath).Length;
        long baselineSize = new FileInfo(baselineOutputPath).Length;

        Console.WriteLine($"Progressive JPEG size: {progressiveSize} bytes");
        Console.WriteLine($"Baseline JPEG size:   {baselineSize} bytes");
        Console.WriteLine($"Size difference:      {baselineSize - progressiveSize} bytes");
    }
}