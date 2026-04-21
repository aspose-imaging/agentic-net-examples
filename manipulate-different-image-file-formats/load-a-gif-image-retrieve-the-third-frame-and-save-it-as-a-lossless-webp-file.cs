using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

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
                GifImage gif = image as GifImage;
                if (gif == null)
                {
                    Console.Error.WriteLine("The input file is not a GIF image.");
                    return;
                }

                // Check that the GIF has at least three frames (zero‑based index 2)
                if (gif.PageCount <= 2)
                {
                    Console.Error.WriteLine("The GIF does not contain a third frame.");
                    return;
                }

                // Set the active frame to the third frame
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[2];

                // Cast the active frame to RasterImage for saving
                using (RasterImage frame = (RasterImage)gif.ActiveFrame)
                {
                    // Configure lossless WebP options
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };

                    // Save the frame as a lossless WebP file
                    frame.Save(outputPath, webpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}