using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input PNG file paths
        string[] inputPaths = new[]
        {
            "frames\\frame1.png",
            "frames\\frame2.png",
            "frames\\frame3.png",
            "frames\\frame4.png"
        };

        // Hardcoded output APNG file path
        string outputPath = "output\\animation.png";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Load all input images as RasterImage instances
        List<RasterImage> frames = new List<RasterImage>();
        foreach (string inputPath in inputPaths)
        {
            RasterImage img = (RasterImage)Image.Load(inputPath);
            frames.Add(img);
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Use the first frame to obtain width and height for the APNG canvas
        int width = frames[0].Width;
        int height = frames[0].Height;

        // Prepare APNG creation options
        ApngOptions createOptions = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            ColorType = PngColorType.TruecolorWithAlpha
        };

        // Random number generator for frame delays (50‑150 ms)
        Random rnd = new Random();

        // Create the APNG image, add frames with random delays, and save
        using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
        {
            // Remove the default empty frame
            apngImage.RemoveAllFrames();

            // Add each loaded frame with a random delay
            foreach (RasterImage frame in frames)
            {
                uint delay = (uint)rnd.Next(50, 151); // 50‑150 ms inclusive
                apngImage.AddFrame(frame, delay);
            }

            // Save the APNG to the specified output path
            apngImage.Save();
        }

        // Dispose loaded frames
        foreach (RasterImage frame in frames)
        {
            frame.Dispose();
        }
    }
}