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
        // Hardcoded input vector image paths
        string[] inputPaths = {
            "vector1.svg",
            "vector2.svg",
            "vector3.svg"
        };

        // Verify each input file exists
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Hardcoded output APNG path
        string outputPath = "output.apng";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Determine canvas size from the first image
        int canvasWidth = 0;
        int canvasHeight = 0;
        using (RasterImage first = (RasterImage)Image.Load(inputPaths[0]))
        {
            canvasWidth = first.Width;
            canvasHeight = first.Height;
        }

        // Create APNG options with bound output source
        Source source = new FileCreateSource(outputPath, false);
        ApngOptions apngOptions = new ApngOptions
        {
            Source = source,
            DefaultFrameTime = 100, // 100 ms per frame
            ColorType = PngColorType.TruecolorWithAlpha
        };

        // Create APNG canvas
        using (ApngImage apng = (ApngImage)Image.Create(apngOptions, canvasWidth, canvasHeight))
        {
            // Remove the default empty frame
            apng.RemoveAllFrames();

            // Add each vector image as a frame
            foreach (string path in inputPaths)
            {
                using (RasterImage frame = (RasterImage)Image.Load(path))
                {
                    apng.AddFrame(frame);
                }
            }

            // Save the bound APNG image
            apng.Save();
        }
    }
}