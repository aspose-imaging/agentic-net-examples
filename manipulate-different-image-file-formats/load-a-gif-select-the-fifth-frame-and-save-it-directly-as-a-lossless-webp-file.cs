using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.webp";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the GIF image
            using (Image gifImage = Image.Load(inputPath))
            {
                // Cast to multipage image to access frames
                var multipage = gifImage as IMultipageImage;
                if (multipage == null || multipage.PageCount < 5)
                {
                    Console.Error.WriteLine("The GIF does not contain at least five frames.");
                    return;
                }

                // Get the fifth frame (zero‑based index 4)
                var fifthFrame = (RasterImage)multipage.Pages[4];

                // Create a WebP image from the selected frame
                using (WebPImage webPImage = new WebPImage(fifthFrame))
                {
                    // Set lossless WebP options
                    var webPOptions = new WebPOptions
                    {
                        Lossless = true
                    };

                    // Save as lossless WebP
                    webPImage.Save(outputPath, webPOptions);
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
 * 1. When creating a thumbnail gallery for an animated GIF, a developer can extract the fifth frame and save it as a lossless WebP to ensure high‑quality static previews on web pages.
 * 2. When generating a preview image for a social‑media post that uses a multi‑frame GIF, extracting the fifth frame and converting it to lossless WebP reduces file size while preserving visual fidelity.
 * 3. When building an e‑learning platform that needs to display a specific step from an animated instructional GIF, the code can isolate the fifth frame and store it as a lossless WebP for fast loading in the lesson UI.
 * 4. When archiving key frames from a GIF‑based animation for a digital asset management system, saving the fifth frame as a lossless WebP maintains exact pixel data for future reuse.
 * 5. When optimizing a marketing email that includes a static image taken from a GIF animation, converting the fifth frame to lossless WebP ensures crisp rendering across email clients while keeping the attachment lightweight.
 */