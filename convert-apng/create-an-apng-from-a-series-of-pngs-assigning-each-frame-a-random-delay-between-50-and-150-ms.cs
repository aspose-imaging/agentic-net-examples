// HOW-TO: Create Animated PNG From Multiple PNGs With Random Frame Delays In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PNG file paths
            string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png", "frame4.png" };

            // Verify each input file exists
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Hardcoded output APNG file path
            string outputPath = "output\\animation.apng";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first image to obtain canvas size
            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = first.Width;
                int height = first.Height;

                // Create APNG options bound to the output file
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG image
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                {
                    // Remove the default frame that exists upon creation
                    apngImage.RemoveAllFrames();

                    Random rnd = new Random();

                    // Add each PNG as a frame with a random delay between 50 and 150 ms
                    foreach (var path in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(path))
                        {
                            uint delay = (uint)rnd.Next(50, 151); // inclusive upper bound
                            apngImage.AddFrame(frame, delay);
                        }
                    }

                    // Save the APNG (output is already bound via FileCreateSource)
                    apngImage.Save();
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
 * 1. When you need to generate an animated PNG for a web banner using a set of static PNG assets and want each frame to appear for a different, randomly chosen duration.
 * 2. When building a game UI that displays a looping character animation where the frame timing should vary to create a more natural, jitter‑free motion.
 * 3. When creating a slideshow‑like effect for a desktop application but require true‑color with alpha support, which APNG provides, and you want unpredictable frame pacing.
 * 4. When automating the production of promotional graphics that combine several product images into a single APNG file with varied display times to highlight each item.
 * 5. When developing a testing tool that simulates irregular network‑latency animation playback by assigning random delays to each PNG frame in an APNG sequence.
 */
