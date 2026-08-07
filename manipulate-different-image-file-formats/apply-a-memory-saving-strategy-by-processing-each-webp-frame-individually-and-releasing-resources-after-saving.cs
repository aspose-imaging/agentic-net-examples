using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Cast to multipage interface to get page count
                var multipage = webPImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                // Process each frame individually
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.png");

                    // Ensure the directory for this frame exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Extract the frame as a RasterImage and save it
                    using (RasterImage frame = (RasterImage)webPImage.Pages[i])
                    {
                        frame.Save(outputPath, new PngOptions());
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
 * 1. When an application must extract every frame from an animated WebP file and save them as PNG thumbnails while keeping memory usage low, this code can be used.
 * 2. When a server‑side C# service needs to convert a large multi‑frame WebP animation into individual PNG images for downstream processing without loading the entire animation into memory, the example applies.
 * 3. When a developer is building a content‑management system that must generate PNG previews of each frame of user‑uploaded animated WebP graphics while ensuring resources are released after each save, this pattern is appropriate.
 * 4. When a batch‑processing tool has to split an animated WebP into separate PNG assets for use in mobile apps that only support static PNGs, processing frames one by one prevents out‑of‑memory errors.
 * 5. When an image‑analysis pipeline requires reading each frame of a WebP animation, performing per‑frame analysis, and then discarding the frame to keep the .NET process lightweight, this code demonstrates the required workflow.
 */