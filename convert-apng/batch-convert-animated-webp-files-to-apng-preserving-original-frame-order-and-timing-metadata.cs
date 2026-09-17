// HOW-TO: Batch Convert Animated WebP Files to APNG with Frame Order in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.webp");

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (WebPImage webp = (WebPImage)Image.Load(inputPath))
                {
                    if (webp.Pages == null || webp.Pages.Length == 0)
                    {
                        Console.Error.WriteLine($"No frames found in: {inputPath}");
                        continue;
                    }

                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, webp.Width, webp.Height))
                    {
                        apng.RemoveAllFrames();

                        foreach (RasterImage frame in webp.Pages)
                        {
                            apng.AddFrame(frame);
                        }

                        apng.Save();
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
 * 1. When you need to transform a collection of animated WebP stickers into APNGs for iOS apps that only support APNG animation.
 * 2. When you want to preserve the original frame sequence and timing while migrating web assets from WebP to APNG for cross‑browser compatibility.
 * 3. When an automated build pipeline must generate APNG thumbnails from animated WebP source files for a game’s UI assets.
 * 4. When a content‑management system imports user‑uploaded animated WebP images and must store them as APNGs to maintain animation in email newsletters.
 * 5. When you are creating a batch processing tool that converts large numbers of animated WebP graphics to APNG without losing frame order for a digital signage solution.
 */
