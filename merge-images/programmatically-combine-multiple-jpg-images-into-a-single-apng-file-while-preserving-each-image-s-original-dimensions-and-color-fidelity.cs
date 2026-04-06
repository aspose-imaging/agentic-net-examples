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
        // Hardcoded input JPG files
        string[] inputPaths = {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Hardcoded output APNG file
        string outputPath = "output/combined.apng";

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
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
            outputDir = ".";
        Directory.CreateDirectory(outputDir);

        // Load the first image to obtain canvas size
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            int canvasWidth = firstImage.Width;
            int canvasHeight = firstImage.Height;

            // Prepare APNG creation options
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 500, // 500 ms per frame (adjust as needed)
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create the APNG image with the canvas size
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, canvasWidth, canvasHeight))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add each JPG as a frame
                foreach (string inputPath in inputPaths)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(inputPath))
                    {
                        // If dimensions differ, they will be scaled to the canvas size automatically
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the APNG (output path already defined in options)
                apngImage.Save();
            }
        }
    }
}