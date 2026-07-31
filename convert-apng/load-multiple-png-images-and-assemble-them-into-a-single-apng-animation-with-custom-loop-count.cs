using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PNG files
            string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png" };
            // Hardcoded output APNG file
            string outputPath = "output_animation.png";

            // Validate each input file exists
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first image to obtain canvas size
            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                // Create source and APNG options
                Source source = new FileCreateSource(outputPath, false);
                ApngOptions options = new ApngOptions
                {
                    Source = source,
                    DefaultFrameTime = 100, // frame duration in ms
                    ColorType = PngColorType.TruecolorWithAlpha,
                    NumPlays = 3 // custom loop count
                };

                // Create APNG canvas bound to the output file
                using (ApngImage apng = (ApngImage)Image.Create(options, first.Width, first.Height))
                {
                    // Remove the default single frame
                    apng.RemoveAllFrames();

                    // Add each PNG as a frame
                    foreach (var path in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(path))
                        {
                            apng.AddFrame(frame);
                        }
                    }

                    // Save the assembled animation
                    apng.Save();
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
 * 1. When creating an animated product showcase where each PNG represents a product view and the APNG animation must loop exactly three times.
 * 2. When generating a step‑by‑step tutorial that stitches together a series of screenshot PNGs into an APNG that repeats a custom number of cycles for e‑learning platforms.
 * 3. When building a web banner that cycles through promotional PNG images and requires a fixed loop count to meet advertising display rules.
 * 4. When exporting a sequence of medical imaging slices as a single APNG file so researchers can view the PNG frames in a controlled three‑play loop.
 * 5. When developing a game UI that displays a short animated icon composed of multiple PNG frames and needs the animation to stop after three repetitions.
 */