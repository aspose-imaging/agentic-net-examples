using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input_animation.webp";
        string outputPath = @"C:\Images\output_animation.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image
        using (Image webpImage = Image.Load(inputPath))
        {
            // Cast to IMultipageImage to access frame information
            var webpMultipage = webpImage as IMultipageImage;
            int originalFrameCount = webpMultipage?.PageCount ?? 1;

            // Save as APNG using default options (preserves frame timing)
            webpImage.Save(outputPath, new ApngOptions());

            // Load the generated APNG to verify frame data
            using (Image apngImage = Image.Load(outputPath))
            {
                var apngMultipage = apngImage as IMultipageImage;
                int apngFrameCount = apngMultipage?.PageCount ?? 1;

                // Simple verification: frame count should match
                if (originalFrameCount != apngFrameCount)
                {
                    Console.Error.WriteLine($"Frame count mismatch: WebP={originalFrameCount}, APNG={apngFrameCount}");
                }
                else
                {
                    Console.WriteLine($"Success: Frame count matches ({originalFrameCount} frames).");
                }

                // Verify default frame time if available
                var apng = apngImage as ApngImage;
                if (apng != null && webpMultipage != null)
                {
                    // WebPImage does not expose a direct default frame time, but we can compare per‑frame delays if needed.
                    // Here we simply output the default frame time of the APNG.
                    Console.WriteLine($"APNG default frame time: {apng.DefaultFrameTime} ms");
                }
            }
        }
    }
}