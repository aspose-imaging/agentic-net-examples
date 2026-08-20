// HOW-TO: Create Animated APNG from PNG with Custom Frame Delays in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output_animation.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source PNG image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // default frame duration in ms
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(
                    createOptions,
                    sourceImage.Width,
                    sourceImage.Height))
                {
                    // Remove the automatically added first frame
                    apngImage.RemoveAllFrames();

                    // Add the first frame using the default frame time
                    apngImage.AddFrame(sourceImage);

                    // Define custom frame delays (in milliseconds)
                    uint[] customDelays = new uint[] { 50, 150, 200, 100 };

                    // Add additional frames with custom delays
                    foreach (uint delay in customDelays)
                    {
                        apngImage.AddFrame(sourceImage, delay);
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
 * 1. When you need to turn a static PNG logo into a looping APNG banner with specific timing for each frame.
 * 2. When you want to generate an animated product preview from a series of PNG screenshots, controlling the display duration of each step.
 * 3. When building a C# desktop application that creates lightweight animated icons by adding custom frame delays to a base PNG image.
 * 4. When exporting a sequence of PNG charts as an APNG file to illustrate data changes over time with precise frame intervals.
 * 5. When automating the creation of animated UI tutorials in .NET, using Aspose.Imaging to combine PNG assets into an APNG with tailored frame speeds.
 */
