using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output\\input.webp.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WebPImage to access frame information
            WebPImage webpImage = image as WebPImage;
            if (webpImage == null)
            {
                Console.Error.WriteLine("The loaded image is not a WebP image.");
                return;
            }

            // Collect original frame delays (in milliseconds)
            List<int> originalDelays = new List<int>();
            // WebPImage stores its frames in the Frames collection; each frame block has a Delay property
            foreach (WebPFrameBlock frame in webpImage.Frames)
            {
                // The Delay property represents the frame duration in milliseconds
                originalDelays.Add(frame.Delay);
            }

            // Save the image as APNG using default options (unlimited loops)
            image.Save(outputPath, new ApngOptions());

            // Load the resulting APNG to verify frame timing
            using (Image apngLoaded = Image.Load(outputPath))
            {
                ApngImage apngImage = apngLoaded as ApngImage;
                if (apngImage == null)
                {
                    Console.Error.WriteLine("Failed to load the generated APNG image.");
                    return;
                }

                // APNG stores a default frame time that applies to all frames unless overridden
                uint apngDefaultDelay = apngImage.DefaultFrameTime;

                // Determine if the original WebP had uniform frame delays
                bool uniformDelay = originalDelays.Count > 0 && originalDelays.All(d => d == originalDelays[0]);

                if (uniformDelay)
                {
                    int originalDelay = originalDelays[0];
                    if (apngDefaultDelay == (uint)originalDelay)
                    {
                        Console.WriteLine("Verification succeeded: APNG frame delay matches the original WebP delay.");
                    }
                    else
                    {
                        Console.WriteLine($"Verification failed: APNG default delay ({apngDefaultDelay} ms) does not match original WebP delay ({originalDelay} ms).");
                    }
                }
                else
                {
                    // If original delays vary, compare each frame individually
                    bool allMatch = true;
                    int frameCount = Math.Min(originalDelays.Count, apngImage.PageCount);
                    for (int i = 0; i < frameCount; i++)
                    {
                        // Each APNG frame can have its own delay; retrieve it via the ApngFrame's Delay property
                        ApngFrame apngFrame = apngImage.Pages[i] as ApngFrame;
                        if (apngFrame == null)
                        {
                            allMatch = false;
                            break;
                        }

                        uint frameDelay = apngFrame.Delay;
                        if (frameDelay != (uint)originalDelays[i])
                        {
                            allMatch = false;
                            break;
                        }
                    }

                    Console.WriteLine(allMatch
                        ? "Verification succeeded: All APNG frame delays match the original WebP delays."
                        : "Verification failed: APNG frame delays do not match the original WebP delays.");
                }
            }
        }
    }
}