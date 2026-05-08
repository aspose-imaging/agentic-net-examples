using System;
using System.IO;
using System.Collections.Generic;
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
            string inputPath = "input.webp";
            string outputPath = "output.png";

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
                // Extract original frame delays (if available)
                var originalDelays = new List<int>();
                if (webpImage is IMultipageImage webpMultipage)
                {
                    foreach (var page in webpMultipage.Pages)
                    {
                        // Try to read a FrameDelay property via reflection
                        var delayProp = page.GetType().GetProperty("FrameDelay");
                        int delay = delayProp != null ? (int)delayProp.GetValue(page) : 0;
                        originalDelays.Add(delay);
                    }
                }

                // Convert and save to APNG using default options
                webpImage.Save(outputPath, new ApngOptions());

                // Load the generated APNG to verify frame delays
                using (Image apngImage = Image.Load(outputPath))
                {
                    var apngDelays = new List<int>();
                    if (apngImage is IMultipageImage apngMultipage)
                    {
                        foreach (var page in apngMultipage.Pages)
                        {
                            var delayProp = page.GetType().GetProperty("FrameDelay");
                            int delay = delayProp != null ? (int)delayProp.GetValue(page) : 0;
                            apngDelays.Add(delay);
                        }
                    }

                    // Simple verification: compare counts and each delay value
                    bool match = originalDelays.Count == apngDelays.Count;
                    if (match)
                    {
                        for (int i = 0; i < originalDelays.Count; i++)
                        {
                            if (originalDelays[i] != apngDelays[i])
                            {
                                match = false;
                                break;
                            }
                        }
                    }

                    Console.WriteLine(match
                        ? "Frame delays match between WebP and APNG."
                        : "Frame delays do NOT match.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}