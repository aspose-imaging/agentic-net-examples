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
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "Animation1.webp";
            string outputPath = "Animation1.webp.png";

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
                // Convert and save as APNG using default options
                webpImage.Save(outputPath, new ApngOptions());

                // Determine frame count of the source WebP
                int webpFrameCount = 0;
                if (webpImage is IMultipageImage webpMultipage)
                {
                    webpFrameCount = webpMultipage.PageCount;
                }

                // Load the generated APNG image
                using (Image apngImage = Image.Load(outputPath))
                {
                    // Determine frame count of the resulting APNG
                    int apngFrameCount = 0;
                    if (apngImage is IMultipageImage apngMultipage)
                    {
                        apngFrameCount = apngMultipage.PageCount;
                    }

                    // Output verification results
                    Console.WriteLine($"WebP frames: {webpFrameCount}");
                    Console.WriteLine($"APNG frames: {apngFrameCount}");

                    if (webpFrameCount == apngFrameCount)
                    {
                        Console.WriteLine("Verification succeeded: frame counts match.");
                    }
                    else
                    {
                        Console.WriteLine("Verification failed: frame counts do not match.");
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