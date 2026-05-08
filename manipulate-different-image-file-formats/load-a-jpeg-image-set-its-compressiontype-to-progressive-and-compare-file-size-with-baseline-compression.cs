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
            string baselinePath = @"C:\temp\baseline.jpg";
            string progressivePath = @"C:\temp\progressive.jpg";

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
                // Save baseline (default) JPEG
                image.Save(baselinePath);
                long baselineSize = new FileInfo(baselinePath).Length;

                // Prepare options for progressive compression
                JpegOptions progressiveOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 100 // optional: set quality to maximum
                };

                // Save progressive JPEG
                image.Save(progressivePath, progressiveOptions);
                long progressiveSize = new FileInfo(progressivePath).Length;

                // Output size comparison
                Console.WriteLine($"Baseline JPEG size: {baselineSize} bytes");
                Console.WriteLine($"Progressive JPEG size: {progressiveSize} bytes");
                if (progressiveSize < baselineSize)
                {
                    Console.WriteLine("Progressive compression produced a smaller file.");
                }
                else if (progressiveSize > baselineSize)
                {
                    Console.WriteLine("Progressive compression produced a larger file.");
                }
                else
                {
                    Console.WriteLine("Both files have the same size.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}