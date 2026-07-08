using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.gif";
            string outputPath = "C:\\temp\\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image gifImage = Image.Load(inputPath))
            {
                // Cast to multipage interface to access frames
                IMultipageImage multipage = gifImage as IMultipageImage;
                if (multipage == null || multipage.PageCount < 5)
                {
                    Console.Error.WriteLine("GIF does not contain at least 5 frames.");
                    return;
                }

                // Retrieve the fifth frame (zero‑based index 4)
                using (RasterImage fifthFrame = (RasterImage)multipage.Pages[4])
                {
                    // Convert the frame to a WebP image and save it losslessly
                    using (WebPImage webpImage = new WebPImage(fifthFrame))
                    {
                        var options = new WebPOptions { Lossless = true };
                        webpImage.Save(outputPath, options);
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
 * 1. When a developer needs to extract the fifth frame from a multi‑frame GIF and save it as a lossless WebP image for high‑quality web display.
 * 2. When building a thumbnail generator that selects the fifth animation frame of a GIF and converts it to a compact, lossless WebP file using C# and Aspose.Imaging.
 * 3. When migrating legacy animated GIF assets to modern WebP format and only the fifth frame is required for a product showcase or preview.
 * 4. When creating a server‑side image processing pipeline that validates a GIF, retrieves its fifth frame, and outputs a lossless WebP to reduce bandwidth while preserving detail.
 * 5. When implementing a C# utility that processes user‑uploaded GIFs, isolates frame number five, and saves it as a WebP image to ensure compatibility with browsers that support lossless WebP.
 */