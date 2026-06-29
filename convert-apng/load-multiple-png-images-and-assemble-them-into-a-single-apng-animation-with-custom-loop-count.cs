using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input PNG files
            string[] inputPaths = {
                "frame1.png",
                "frame2.png",
                "frame3.png"
            };

            // Hard‑coded output APNG file
            string outputPath = "animation.apng";

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first image to obtain dimensions (assumes all frames share size)
            using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = firstImage.Width;
                int height = firstImage.Height;

                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    NumPlays = 3,                     // custom loop count (3 times)
                    DefaultFrameTime = 100,           // default frame duration in ms
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG image container
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                {
                    // Remove the default single frame
                    apngImage.RemoveAllFrames();

                    // Add each PNG as a frame
                    foreach (string path in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(path))
                        {
                            apngImage.AddFrame(frame);
                        }
                    }

                    // Save the assembled animation
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
 * 1. When creating a product showcase on a website, a developer can combine several PNG screenshots into an animated APNG that loops three times to highlight features.
 * 2. When generating a step‑by‑step tutorial, a developer can stitch PNG diagrams into a single APNG animation with a custom frame duration and loop count for easy embedding in documentation.
 * 3. When building a mobile game UI, a developer can merge PNG sprite frames into an APNG that plays a limited number of loops to animate character actions without using heavy video files.
 * 4. When preparing a marketing email, a developer can assemble promotional PNG images into an APNG banner that repeats three times, ensuring consistent animation across email clients that support APNG.
 * 5. When automating a reporting tool, a developer can convert a series of PNG charts into an APNG animation that cycles a set number of times to illustrate data trends in a compact, loop‑controlled format.
 */