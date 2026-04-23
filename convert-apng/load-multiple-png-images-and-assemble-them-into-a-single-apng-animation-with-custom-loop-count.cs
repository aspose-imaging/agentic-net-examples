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
            string outputPath = "output/animation.apng";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Validate each input file
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Load the first image to obtain canvas size
            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                int width = first.Width;
                int height = first.Height;

                // Configure APNG creation options
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    DefaultFrameTime = 100, // frame duration in milliseconds
                    ColorType = PngColorType.TruecolorWithAlpha,
                    NumPlays = 3 // custom loop count
                };

                // Create the APNG image bound to the output file
                using (ApngImage apng = (ApngImage)Image.Create(options, width, height))
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

                    // Save the animation (output already bound via FileCreateSource)
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