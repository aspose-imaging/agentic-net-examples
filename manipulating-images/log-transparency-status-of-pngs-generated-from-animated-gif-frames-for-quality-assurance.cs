using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input GIF path
            string inputPath = "input.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory to store extracted PNG frames
            string outputDir = "output_frames";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the animated GIF
            using (Image gifImage = Image.Load(inputPath))
            {
                // Cast to multipage image to access frames
                var multipage = gifImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage (animated) image.");
                    return;
                }

                int frameCount = multipage.PageCount;

                for (int i = 0; i < frameCount; i++)
                {
                    // Build output PNG path for the current frame
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.png");

                    // Ensure the directory for the output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set up PNG save options with a single-page range
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(i, i + 1));

                    // Save the current frame as PNG
                    gifImage.Save(outputPath, pngOptions);

                    // Load the saved PNG to check transparency
                    using (Image pngImage = Image.Load(outputPath))
                    {
                        // Cast to PngImage to access HasAlpha property
                        var png = pngImage as PngImage;
                        if (png != null)
                        {
                            Console.WriteLine($"Frame {i}: HasAlpha = {png.HasAlpha}");
                        }
                        else
                        {
                            Console.WriteLine($"Frame {i}: Unable to determine alpha (not a PNG image).");
                        }
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
 * 1. When a developer needs to verify that the alpha channel of each PNG extracted from an animated GIF retains proper transparency for web UI quality assurance.
 * 2. When a QA engineer wants to automatically log the transparency status of PNG frames generated from a GIF to ensure compliance with accessibility guidelines.
 * 3. When an e‑commerce platform converts product animation GIFs to PNG sequences and must confirm that background transparency is preserved before publishing.
 * 4. When a game asset pipeline extracts frames from sprite‑sheet GIFs using C# and Aspose.Imaging and needs to audit each PNG’s transparency for correct rendering in the engine.
 * 5. When a digital publishing workflow generates PNG thumbnails from animated GIFs and requires a transparent‑pixel check to avoid unwanted white backgrounds in the final PDF.
 */