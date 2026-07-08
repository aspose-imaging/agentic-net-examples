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
            string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png" };

            // Verify each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Hardcoded output APNG path (includes directory)
            string outputPath = "output\\animation.apng";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load first image to obtain canvas size
            int canvasWidth, canvasHeight;
            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                canvasWidth = first.Width;
                canvasHeight = first.Height;
            }

            // Create APNG with specified options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apng = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
            {
                apng.RemoveAllFrames();

                Random rnd = new Random();

                // Add each PNG as a frame with random delay between 50 and 150 ms
                foreach (string path in inputPaths)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(path))
                    {
                        uint delay = (uint)rnd.Next(50, 151); // Upper bound exclusive
                        apng.AddFrame(frame, delay);
                    }
                }

                // Save the APNG
                apng.Save();
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
 * 1. When a developer needs to generate an APNG web banner that cycles through several PNG product shots with random 50‑150 ms delays to create a lively, non‑uniform animation.
 * 2. When a game UI programmer wants to build an animated PNG cursor from a set of PNG frames, using Aspose.Imaging in C# to assign each frame a random delay for a more organic flicker effect.
 * 3. When an e‑learning platform creates animated instructional diagrams by converting a series of PNG slides into an APNG with varying frame timings to emphasize key steps.
 * 4. When a marketing automation script assembles user‑generated PNG memes into a single animated PNG email attachment, applying random delays to keep the viewer’s attention.
 * 5. When a desktop application produces a preview of a photo‑slideshow as an APNG file, using random frame delays to simulate a natural, unscripted transition between images.
 */