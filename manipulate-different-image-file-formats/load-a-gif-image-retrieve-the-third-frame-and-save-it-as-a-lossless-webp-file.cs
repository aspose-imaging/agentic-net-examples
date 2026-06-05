using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded relative input and output paths
            string inputPath = "Input\\animation.gif";
            string outputPath = "Output\\frame3.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access frame information
                GifImage gif = image as GifImage;
                if (gif == null || gif.PageCount < 3)
                {
                    Console.Error.WriteLine("GIF does not contain at least three frames.");
                    return;
                }

                // Configure WebP options for lossless compression and select only the third frame (index 2)
                WebPOptions options = new WebPOptions
                {
                    Lossless = true,
                    MultiPageOptions = new MultiPageOptions(new IntRange(2, 2))
                };

                // Save the selected frame as a lossless WebP file
                image.Save(outputPath, options);
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
 * 1. When creating a thumbnail for a specific animation step, a developer can extract the third frame from a GIF and save it as a lossless WebP to preserve quality while reducing file size.
 * 2. When generating preview images for an e‑learning platform, you might need to isolate the third frame of an instructional GIF and store it as a WebP to ensure fast loading on web browsers.
 * 3. When building a social‑media scheduler that converts animated content to static assets, extracting the third frame of a GIF and converting it to a lossless WebP allows consistent visual representation across devices.
 * 4. When performing automated QA on animated advertisements, a test script can pull the third frame from a GIF and save it as a lossless WebP to compare pixel‑perfect screenshots.
 * 5. When optimizing a mobile game’s UI assets, developers may need to take the third frame of a GIF sprite sheet and export it as a lossless WebP to keep sharpness while minimizing bandwidth.
 */