using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input WebP file path
        string inputPath = "input.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the WebP image
        using (WebPImage webpImage = new WebPImage(inputPath))
        {
            // Try to treat the image as a multipage (animated) image
            IMultipageImage multipage = webpImage as IMultipageImage;
            if (multipage != null && multipage.PageCount > 0)
            {
                // Process each frame individually
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Cast the page to RasterImage to enable saving
                    RasterImage frame = multipage.Pages[i] as RasterImage;
                    if (frame == null)
                        continue;

                    // Define output path for the current frame
                    string outputPath = Path.Combine("output", $"frame_{i}.png");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as PNG
                    frame.Save(outputPath, new PngOptions());

                    // Release resources for the current frame
                    frame.Dispose();
                }
            }
            else
            {
                // Single-frame WebP handling
                string outputPath = Path.Combine("output", "frame_0.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                webpImage.Save(outputPath, new PngOptions());
            }
        }
    }
}