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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.apng";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the source PNG image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Define custom frame delays (in milliseconds)
                int[] frameDelays = new int[] { 100, 200, 300, 400 };

                // Create APNG options with desired settings
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // fallback default
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG image canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Remove the initial placeholder frame
                    apngImage.RemoveAllFrames();

                    // Add frames with custom delays
                    foreach (int delay in frameDelays)
                    {
                        apngImage.AddFrame(sourceImage);
                        ApngFrame lastFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];
                        lastFrame.FrameTime = delay;
                    }

                    // Save the animated APNG (output path already bound via FileCreateSource)
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
 * 1. When a developer wants to convert a static PNG logo into a looping animated APNG banner with precise timing for each frame in a C# web application.
 * 2. When an e‑learning platform needs to generate step‑by‑step tutorial animations from a single PNG diagram by adding custom frame delays using Aspose.Imaging for .NET.
 * 3. When a mobile game developer must create lightweight animated sprites from a base PNG asset, controlling the display duration of each sprite frame with C# code.
 * 4. When a marketing automation tool has to produce personalized animated product previews by reusing a source PNG and specifying different frame intervals for each promotional variant.
 * 5. When a desktop reporting solution requires embedding an animated APNG chart that shows data changes over time, with each frame’s delay tuned for smooth visual transitions.
 */