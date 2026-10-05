// HOW-TO: Convert Animated WebP to APNG with Original Frame Timing in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "animation.webp");
            string outputPath = Path.Combine("Output", "animation.apng");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                var webpImage = (WebPImage)img;

                var apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, webpImage.Width, webpImage.Height))
                {
                    foreach (var page in webpImage.Pages)
                    {
                        var raster = (RasterImage)page;
                        apngImage.AddFrame(raster);
                    }

                    apngImage.Save();
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
 * 1. When you need to display animated graphics on platforms that support APNG but not WebP, you can convert the WebP animation to APNG while keeping the original frame delays.
 * 2. When optimizing a mobile app’s assets, you may convert animated WebP stickers to APNG to ensure consistent playback timing across iOS and Android devices.
 * 3. When migrating a legacy web catalog that uses animated WebP files to a new system that only accepts APNG, this code preserves the animation speed during the transition.
 * 4. When generating email newsletters that require APNG for animated images, you can programmatically transform WebP animations to APNG without losing timing information.
 * 5. When building a server‑side image processing pipeline in C#, you can use this snippet to batch‑convert user‑uploaded animated WebP files to APNG while retaining their original animation timing.
 */
