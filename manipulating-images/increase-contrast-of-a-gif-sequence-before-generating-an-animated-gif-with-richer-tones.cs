// HOW-TO: Increase Contrast of GIF Animation in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output_contrast.gif";

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
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Increase contrast (value range: -100 to 100)
                gifImage.AdjustContrast(50f);

                // Save the adjusted GIF (using default GifOptions)
                gifImage.Save(outputPath, new GifOptions());
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
 * 1. When you need to enhance the visual depth of an existing animated GIF before embedding it in a web banner, you can increase its contrast with Aspose.Imaging in C#.
 * 2. When preparing a series of GIF frames for a marketing email, adjusting contrast ensures the colors stand out across different email clients.
 * 3. When converting low‑contrast screen‑capture GIFs into clearer instructional animations, developers can programmatically boost contrast using Aspose.Imaging.
 * 4. When automating a batch process that improves the readability of GIF‑based data visualizations, increasing contrast via C# simplifies the workflow.
 * 5. When integrating GIF assets into a mobile app and want richer tones without manual editing, you can adjust contrast programmatically with Aspose.Imaging.
 */
