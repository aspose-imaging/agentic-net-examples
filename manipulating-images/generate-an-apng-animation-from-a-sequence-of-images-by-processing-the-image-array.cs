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
        // Hardcoded input image paths
        string[] inputPaths = new string[]
        {
            "frame1.png",
            "frame2.png",
            "frame3.png"
        };

        // Hardcoded output path
        string outputPath = "animation.apng";

        // Validate input files
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

        // Load first image to obtain dimensions
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            int width = firstImage.Width;
            int height = firstImage.Height;

            // Configure APNG creation options
            ApngOptions options = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // milliseconds per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create APNG image bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(options, width, height))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add each input image as a frame
                foreach (var path in inputPaths)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(path))
                    {
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the animation (output is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}