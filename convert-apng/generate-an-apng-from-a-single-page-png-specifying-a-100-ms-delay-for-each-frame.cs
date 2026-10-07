// HOW-TO: Create Animated PNG From Single PNG With 100ms Frame Delay In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100u
                };

                using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
                {
                    apng.RemoveAllFrames();
                    apng.AddFrame(sourceImage);
                    apng.Save();
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
 * 1. When you need to convert a static PNG into an animated PNG for web banners that require a 100 ms frame interval.
 * 2. When generating lightweight animated icons for a desktop application that only supports the APNG format.
 * 3. When creating frame‑by‑frame animations from individual PNG assets for a game UI, ensuring each frame displays for exactly 0.1 seconds.
 * 4. When automating the production of animated product previews where each frame must have a consistent delay using C# and Aspose.Imaging.
 * 5. When building a server‑side service that receives a single PNG and returns an APNG with a fixed frame time for use in email newsletters.
 */
