using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input folder containing raster images for each frame
        string inputFolder = args.Length > 0 ? args[0] : "frames";
        // Output APNG file path
        string outputPath = args.Length > 1 ? args[1] : "animation.png";
        // Default duration for each frame (in milliseconds)
        const uint frameDuration = 100;

        // Collect all image files from the input folder (supports common raster formats)
        List<string> frameFiles = new List<string>();
        foreach (string file in Directory.GetFiles(inputFolder))
        {
            string ext = Path.GetExtension(file).ToLowerInvariant();
            if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".gif")
                frameFiles.Add(file);
        }

        if (frameFiles.Count == 0)
        {
            Console.WriteLine("No suitable image files found in the specified folder.");
            return;
        }

        // Load the first image to obtain canvas dimensions
        int canvasWidth, canvasHeight;
        using (RasterImage first = (RasterImage)Image.Load(frameFiles[0]))
        {
            canvasWidth = first.Width;
            canvasHeight = first.Height;
        }

        // Configure APNG creation options
        var createOptions = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            DefaultFrameTime = frameDuration,
            ColorType = PngColorType.TruecolorWithAlpha
        };

        // Create the APNG image canvas
        using (Aspose.Imaging.FileFormats.Apng.ApngImage apngImage = (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Create(
            createOptions,
            canvasWidth,
            canvasHeight))
        {
            // Ensure the image starts with an empty frame collection
            apngImage.RemoveAllFrames();

            // Add each raster image as a frame
            foreach (string framePath in frameFiles)
            {
                using (RasterImage frame = (RasterImage)Image.Load(framePath))
                {
                    apngImage.AddFrame(frame);
                }
            }

            // Save the animated PNG to the specified output file
            apngImage.Save();
        }

        Console.WriteLine($"APNG animation saved to '{outputPath}'.");
    }
}