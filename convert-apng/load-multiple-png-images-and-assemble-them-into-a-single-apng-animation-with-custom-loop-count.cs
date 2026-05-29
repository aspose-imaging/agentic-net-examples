using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input PNG files
            string[] inputPaths = new string[] { "frame1.png", "frame2.png", "frame3.png" };
            // Output APNG file
            string outputPath = "output/animation.apng";

            // Validate input files
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

            // Create source and APNG options
            Source source = new FileCreateSource(outputPath, false);
            ApngOptions options = new ApngOptions
            {
                Source = source,
                DefaultFrameTime = 100, // milliseconds per frame
                ColorType = PngColorType.TruecolorWithAlpha,
                NumPlays = 3 // custom loop count
            };

            // Load first image to obtain dimensions
            using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
            {
                // Create APNG canvas bound to the output file
                using (ApngImage apng = (ApngImage)Image.Create(options, first.Width, first.Height))
                {
                    apng.RemoveAllFrames();

                    // Add each PNG as a frame
                    foreach (var path in inputPaths)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(path))
                        {
                            apng.AddFrame(frame);
                        }
                    }

                    // Save the animation
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