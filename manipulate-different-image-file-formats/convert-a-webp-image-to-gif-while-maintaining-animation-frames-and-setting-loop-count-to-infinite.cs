using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.webp";
            string outputPath = "Output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions
                {
                    LoopsCount = 0 // infinite loop
                };
                image.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to display an animated WebP advertisement on legacy browsers that only support GIF, they can use this code to convert the WebP to an endlessly looping GIF.
 * 2. When a mobile app stores user‑generated stickers as animated WebP files but the messaging platform requires GIF format, this snippet converts the frames while preserving animation and sets the loop count to infinite.
 * 3. When an e‑learning platform wants to embed animated illustrations originally created in WebP into PowerPoint slides that only accept GIF, the code enables seamless conversion with continuous playback.
 * 4. When a social media scheduler must transform animated WebP posts into GIFs for a service that does not support WebP, the example ensures all frames are kept and the GIF repeats forever.
 * 5. When a game developer exports character animations as WebP but needs to generate GIF previews for documentation or marketing assets, this C# routine converts the animation and forces an infinite loop.
 */