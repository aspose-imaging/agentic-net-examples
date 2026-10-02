// HOW-TO: Apply Magic Wand Selection to First Frame of GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.gif";
                string outputPath = "output.gif";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (GifImage gif = (GifImage)Image.Load(inputPath))
                {
                    if (gif.PageCount > 0)
                    {
                        gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];
                        using (RasterImage frame = (RasterImage)gif.ActiveFrame)
                        {
                            MagicWandTool.Select(frame, new MagicWandSettings(10, 10))
                                .Apply();
                        }
                    }

                    gif.Save(outputPath, new GifOptions());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically remove or highlight a specific color region in the first frame of an animated GIF before saving it back.
 * 2. When you want to create a GIF thumbnail where the background is selected and made transparent using the Magic Wand tool.
 * 3. When processing user‑uploaded GIFs to isolate and edit objects on the initial frame for branding or watermarking purposes.
 * 4. When building a C# application that batch‑processes GIF animations and applies a tolerance‑based selection to the first frame for further image analysis.
 * 5. When integrating Aspose.Imaging into a workflow that requires preserving the original animation while modifying only the first frame’s pixel mask.
 */
