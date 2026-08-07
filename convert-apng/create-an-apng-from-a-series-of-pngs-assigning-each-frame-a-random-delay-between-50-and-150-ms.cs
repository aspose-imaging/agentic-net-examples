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
            // Hardcoded input PNG file paths
            string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png" };
            // Hardcoded output APNG file path
            string outputPath = "output\\animation.apng";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Load the first image to obtain canvas size
            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = first.Width;
                int height = first.Height;

                // Set up APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG image canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                {
                    apngImage.RemoveAllFrames();

                    Random rnd = new Random();

                    // Add each PNG as a frame with a random delay between 50 and 150 ms
                    foreach (var path in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(path))
                        {
                            uint delay = (uint)rnd.Next(50, 151);
                            apngImage.AddFrame(frame, delay);
                        }
                    }

                    // Save the APNG file (output is already bound via FileCreateSource)
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
 * 1. When a developer wants to generate an animated PNG (APNG) from a set of static PNG assets for a web banner and needs each frame to appear for a slightly different duration to create a more natural motion.
 * 2. When building a game UI in C# where character sprites are stored as individual PNG files and the animation speed should vary randomly between 50 ms and 150 ms to simulate jittery movement.
 * 3. When creating a data‑driven slideshow in a desktop application and the slide transition times must be randomized to keep the presentation engaging, using Aspose.Imaging to combine the PNG slides into a single APNG file.
 * 4. When developing an e‑learning platform that converts step‑by‑step tutorial screenshots (PNG) into an APNG tutorial animation with unpredictable frame delays to emphasize key steps.
 * 5. When automating the generation of promotional GIF‑like animations for social media, but preferring the lossless APNG format and needing C# code that assigns each PNG frame a random delay between 50 ms and 150 ms.
 */