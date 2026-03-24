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
        // Define input raster images (frames) and output APNG path
        string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png" };
        string outputPath = "output\\animation.apng";

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

        // Desired size for resized frames
        const int targetWidth = 200;
        const int targetHeight = 200;

        // Prepare APNG creation options
        ApngOptions apngOptions = new ApngOptions
        {
            Source = new FileCreateSource(outputPath, false),
            DefaultFrameTime = 100, // 100 ms per frame
            ColorType = PngColorType.TruecolorWithAlpha
        };

        // Load the first image to initialize the APNG canvas
        using (RasterImage firstImage = (RasterImage)Image.Load(inputPaths[0]))
        {
            if (!firstImage.IsCached) firstImage.CacheData();
            firstImage.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

            using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, targetWidth, targetHeight))
            {
                // Remove the default empty frame
                apngImage.RemoveAllFrames();

                // Add the first resized frame
                apngImage.AddFrame(firstImage);

                // Process remaining frames
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (RasterImage frame = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        if (!frame.IsCached) frame.CacheData();
                        frame.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);
                        apngImage.AddFrame(frame);
                    }
                }

                // Save the APNG (output file is already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}