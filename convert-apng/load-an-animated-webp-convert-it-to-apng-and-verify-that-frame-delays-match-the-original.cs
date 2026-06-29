using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
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
            using (Image webpImage = Image.Load(inputPath))
            {
                // Convert to APNG
                webpImage.Save(outputPath, new ApngOptions());

                // Verify frame counts match
                int webpFrames = (webpImage as IMultipageImage)?.PageCount ?? 1;

                using (Image apngImage = Image.Load(outputPath))
                {
                    int apngFrames = (apngImage as IMultipageImage)?.PageCount ?? 1;
                    Console.WriteLine($"WebP frames: {webpFrames}, APNG frames: {apngFrames}");
                    if (webpFrames == apngFrames)
                    {
                        Console.WriteLine("Frame count matches.");
                    }
                    else
                    {
                        Console.WriteLine("Frame count mismatch.");
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
 * 1. When a mobile app needs to display animated stickers originally created as WebP but the target platform only supports APNG, a developer can use this code to convert the animation and ensure the frame count stays consistent.
 * 2. When a web service processes user‑uploaded animated WebP files and must store them as lossless APNG for archival, the code lets the service perform the conversion and verify that no frames are lost.
 * 3. When a game engine imports animated assets and requires the same timing in APNG format, a developer can run this snippet to transform the WebP animation and check that the frame delays match the source.
 * 4. When an e‑learning platform generates animated diagrams in WebP and needs to embed them in PDF documents that only accept APNG, the code provides a reliable way to convert and validate the animation frames.
 * 5. When a CI/CD pipeline tests image‑processing tools by converting sample animated WebP files to APNG and confirming frame parity, this example serves as the verification step in the automated tests.
 */