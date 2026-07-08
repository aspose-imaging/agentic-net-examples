using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output\\adjusted.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load GIF image
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Apply gamma correction (balanced luminance)
                gif.AdjustGamma(1.2f);

                // Save the adjusted GIF with default options
                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
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
 * 1. When a developer wants to correct the overall brightness of an animated GIF by applying gamma correction with Aspose.Imaging before embedding it in a web page.
 * 2. When a developer needs to preprocess a sequence of GIF frames to achieve balanced luminance for a marketing email campaign that uses animated GIFs.
 * 3. When a developer must ensure that a user‑generated GIF uploaded to a mobile app has consistent contrast across all frames by adjusting its gamma value.
 * 4. When a developer is creating a slideshow of product images in GIF format and wants to normalize the lighting of each frame to avoid flickering.
 * 5. When a developer is automating the preparation of GIF assets for a digital signage system and needs to apply a uniform gamma correction to meet visual standards.
 */