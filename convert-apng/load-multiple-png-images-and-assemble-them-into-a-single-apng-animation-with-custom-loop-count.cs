// HOW-TO: Create APNG Animation From Multiple PNGs With Loop Count In C# (Aspose.Imaging for .NET)
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

            // Verify each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Hardcoded output APNG path (ensure it contains a directory)
            string outputPath = "output\\animation.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first image to obtain canvas dimensions
            using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
            {
                // Configure APNG creation options
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // default frame duration in milliseconds
                    ColorType = PngColorType.TruecolorWithAlpha,
                    NumPlays = 3 // custom loop count (0 = infinite)
                };

                // Create the APNG canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, firstImage.Width, firstImage.Height))
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

                    // Save the assembled animation (output path already bound via FileCreateSource)
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
 * 1. When you need to merge several PNG screenshots into a single APNG file for a product demo using C#.
 * 2. When you want to generate a looping animated PNG banner for a website by programmatically adding PNG frames with a custom loop count.
 * 3. When you have individual sprite PNG images and must create an APNG with a defined number of plays for a game UI.
 * 4. When you must produce an APNG email attachment that plays each frame for a set duration and stops after three repetitions.
 * 5. When you are building a C# desktop utility that converts a folder of PNG icons into an animated PNG with three loops for visual feedback.
 */
