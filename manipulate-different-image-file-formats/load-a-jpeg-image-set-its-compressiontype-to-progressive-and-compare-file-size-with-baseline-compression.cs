using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.jpg";
        string baselinePath = "baseline.jpg";
        string progressivePath = "progressive.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist (unconditional call as required)
        Directory.CreateDirectory(Path.GetDirectoryName(baselinePath) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(progressivePath) ?? ".");

        // Save baseline JPEG (default compression = Baseline)
        using (Image image = Image.Load(inputPath))
        {
            image.Save(baselinePath);
        }

        // Save JPEG with Progressive compression
        using (Image image = Image.Load(inputPath))
        {
            JpegOptions progressiveOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Progressive,
                Quality = 100 // optional, keep maximum quality
            };
            image.Save(progressivePath, progressiveOptions);
        }

        // Compare file sizes
        long baselineSize = new FileInfo(baselinePath).Length;
        long progressiveSize = new FileInfo(progressivePath).Length;

        Console.WriteLine($"Baseline size   : {baselineSize} bytes");
        Console.WriteLine($"Progressive size: {progressiveSize} bytes");
        Console.WriteLine($"Size difference : {baselineSize - progressiveSize} bytes");
    }
}