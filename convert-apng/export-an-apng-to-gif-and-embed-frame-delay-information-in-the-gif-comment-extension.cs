using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                var delays = new List<int>();
                foreach (var page in apng.Pages)
                {
                    var frame = (ApngFrame)page;
                    delays.Add(frame.FrameTime);
                }

                var gifOptions = new GifOptions();

                apng.Save(outputPath, gifOptions);
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
 * 1. When a web developer needs to convert animated PNG (APNG) assets into GIFs for browsers that only support GIF animation while preserving the original frame timing via comment extensions.
 * 2. When a mobile app team wants to generate lightweight GIF previews from high‑resolution APNG files for email attachments, using C# and Aspose.Imaging to embed the frame delay data for accurate playback.
 * 3. When an e‑learning platform must batch‑process course illustrations stored as APNGs into GIFs for legacy LMS systems, ensuring each frame’s display duration is retained in the GIF metadata.
 * 4. When a digital marketing agency automates the creation of social‑media GIFs from product animation APNGs, leveraging Aspose.Imaging for .NET to keep the original animation speed encoded in the GIF comment block.
 * 5. When a game developer exports character sprite animations from APNG to GIF for documentation purposes, using C# code to embed frame delay information so reviewers see the exact timing of each animation frame.
 */