// HOW-TO: Compare Baseline and Progressive JPEG File Sizes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputDir = "output";
            string baselinePath = Path.Combine(outputDir, "baseline.jpg");
            string progressivePath = Path.Combine(outputDir, "progressive.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                image.Save(baselinePath);

                using (JpegOptions progressiveOptions = new JpegOptions())
                {
                    progressiveOptions.CompressionType = JpegCompressionMode.Progressive;
                    image.Save(progressivePath, progressiveOptions);
                }
            }

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
 * 1. When you need to evaluate whether progressive JPEG compression reduces file size for web delivery.
 * 2. When optimizing image assets for faster page load by comparing baseline versus progressive JPEGs in a .NET application.
 * 3. When generating multiple JPEG versions for responsive design and want to choose the smallest file.
 * 4. When implementing an automated image processing pipeline that logs size differences between standard and progressive JPEGs.
 * 5. When troubleshooting image quality versus file size trade‑offs for JPEGs in a C# backend service.
 */
