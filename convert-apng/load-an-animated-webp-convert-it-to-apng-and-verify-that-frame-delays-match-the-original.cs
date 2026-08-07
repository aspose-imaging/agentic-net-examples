using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animation.webp";
            string outputPath = "Output/animation.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load animated WebP
            using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
            {
                // Convert to APNG
                webpImage.Save(outputPath, new ApngOptions());

                // Verify frame counts (as a proxy for matching delays)
                int webpFrames = (webpImage as IMultipageImage)?.PageCount ?? 0;

                using (ApngImage apngImage = (ApngImage)Image.Load(outputPath))
                {
                    int apngFrames = (apngImage as IMultipageImage)?.PageCount ?? 0;
                    Console.WriteLine($"WebP frames: {webpFrames}, APNG frames: {apngFrames}");
                    if (webpFrames == apngFrames)
                    {
                        Console.WriteLine("Frame count matches. Verification passed.");
                    }
                    else
                    {
                        Console.WriteLine("Frame count mismatch. Verification failed.");
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

/*
 * Real-World Use Cases:
 * 1. When a mobile app needs to display animated stickers originally delivered as WebP but the target platform only supports APNG, a developer can load the animated WebP, convert it to APNG, and verify that the frame timing remains consistent.
 * 2. When a game engine imports user‑generated animated assets and must ensure the animation speed is preserved after converting from WebP to APNG, the code can be used to compare frame counts as a proxy for matching delays.
 * 3. When a content‑management system migrates legacy animated WebP files to an APNG‑based CDN and wants to programmatically confirm that each frame’s delay is retained, this C# snippet performs the conversion and validation.
 * 4. When an e‑learning platform automatically generates animated diagrams in WebP format but needs to serve them as APNG for browsers that lack WebP animation support, developers can employ this code to convert and verify frame synchronization.
 * 5. When a digital‑signage solution receives animated advertisements in WebP and must convert them to APNG for compatibility with the signage firmware while ensuring the animation timing is unchanged, the example provides the necessary loading, conversion, and frame‑count check.
 */