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
        // Hardcoded input JPG files
        string[] inputPaths = new[]
        {
            "input\\image1.jpg",
            "input\\image2.jpg",
            "input\\image3.jpg"
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

        // Hardcoded output APNG file
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

        // Create APNG options
        ApngOptions apngOptions = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            ColorType = PngColorType.TruecolorWithAlpha,
            DefaultFrameTime = 100 // default frame duration in milliseconds
        };

        // Create APNG canvas bound to the output file
        using (ApngImage apng = (ApngImage)Image.Create(apngOptions, canvasWidth, canvasHeight))
        {
            // Remove the default empty frame
            apng.RemoveAllFrames();

            // Add each JPG as a frame
            foreach (string path in inputPaths)
            {
                using (RasterImage frame = (RasterImage)Image.Load(path))
                {
                    apng.AddFrame(frame);
                }
            }

            // Save the animated PNG (bound image, so just call Save())
            apng.Save();
        }
    }
}