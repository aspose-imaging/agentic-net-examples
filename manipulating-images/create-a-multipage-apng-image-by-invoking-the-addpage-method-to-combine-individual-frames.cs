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
        // Hardcoded input frame paths
        string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png" };
        // Hardcoded output path
        string outputPath = "output_animation.png";

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load first frame to obtain canvas size
        using (RasterImage firstFrame = (RasterImage)Image.Load(inputPaths[0]))
        {
            int width = firstFrame.Width;
            int height = firstFrame.Height;

            // Set up APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // frame duration in ms
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image canvas
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Add each frame to the animation
                foreach (var path in inputPaths)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(path))
                    {
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the APNG file (output is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}