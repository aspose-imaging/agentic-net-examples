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
        string inputPath = "Animation1.webp";
        string outputPath = "Animation1.webp.png";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the animated WebP image
            using (Image webpImage = Image.Load(inputPath))
            {
                // Cast to multipage interface to obtain frame count
                int webpFrameCount = 0;
                if (webpImage is IMultipageImage multipageWebp)
                {
                    webpFrameCount = multipageWebp.PageCount;
                }

                // Convert and save as APNG using default options (preserves frame delays)
                webpImage.Save(outputPath, new ApngOptions());

                // Load the resulting APNG to verify frame information
                using (Image apngImage = Image.Load(outputPath))
                {
                    int apngFrameCount = 0;
                    if (apngImage is IMultipageImage multipageApng)
                    {
                        apngFrameCount = multipageApng.PageCount;
                    }

                    // Simple verification: frame counts should match
                    if (webpFrameCount == apngFrameCount)
                    {
                        Console.WriteLine($"Verification succeeded: both images contain {webpFrameCount} frames.");
                    }
                    else
                    {
                        Console.WriteLine($"Verification failed: WebP has {webpFrameCount} frames, APNG has {apngFrameCount} frames.");
                    }

                    // Optional: compare default frame time if available
                    if (webpImage is WebPImage wImg && apngImage is ApngImage aImg)
                    {
                        // WebPImage does not expose a direct DefaultFrameTime, so we compare the APNG's default
                        // with the assumption that Aspose.Imaging copies the original delays.
                        Console.WriteLine($"APNG default frame time: {aImg.DefaultFrameTime} ms");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}