using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\frame0.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF animation
            using (Image image = Image.Load(inputPath))
            {
                // Cast to multipage image to access frames
                var multipage = image as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the GIF.");
                    return;
                }

                // Index of the frame to convert (0‑based)
                int frameIndex = 0;

                // Extract the specific frame
                using (Image frame = multipage.Pages[frameIndex])
                {
                    // Set up WebP options with lossless compression
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };

                    // Save the frame as a WebP image
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