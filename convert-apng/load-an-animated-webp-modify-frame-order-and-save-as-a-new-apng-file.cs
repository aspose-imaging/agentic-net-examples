// HOW-TO: Reverse Animated WebP Frames and Save as APNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "./input.webp";
            string outputPath = "./output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = new WebPImage(inputPath))
            {
                var frameList = new List<RasterImage>();
                foreach (var page in ((IMultipageImage)webp).Pages)
                {
                    if (page is RasterImage raster)
                    {
                        frameList.Add(raster);
                    }
                }

                frameList.Reverse();

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 100
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, webp.Width, webp.Height))
                {
                    apng.RemoveAllFrames();

                    foreach (var frame in frameList)
                    {
                        apng.AddFrame(frame);
                    }

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

/*
 * Real-World Use Cases:
 * 1. When you need to display an animated image with reversed playback on a website that only supports APNG, you can load the animated WebP, reverse its frames, and export it as an APNG using C#.
 * 2. When creating a visual effect that plays a WebP animation backwards for a mobile app, this code lets you reorder the frames and save the result as an APNG compatible with iOS.
 * 3. When a game engine requires APNG sprites but the assets are provided as animated WebP files, you can convert and reorder the frames programmatically with Aspose.Imaging for .NET.
 * 4. When generating a thumbnail sequence that shows the last frames first for a video preview, the snippet extracts WebP frames, reverses them, and outputs an APNG for easy embedding.
 * 5. When automating a batch process to convert a library of animated WebP files into APNGs with a custom frame order, this example demonstrates the necessary steps in C#.
 */
