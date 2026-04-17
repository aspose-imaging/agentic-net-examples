using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input_animation.webp";
        string outputPath = @"C:\Images\output_animation.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image
        using (Image webpImage = Image.Load(inputPath))
        {
            // Cast to multipage interface to access frames
            IMultipageImage multipage = webpImage as IMultipageImage;
            if (multipage == null || multipage.PageCount == 0)
            {
                Console.Error.WriteLine("The loaded image does not contain any frames.");
                return;
            }

            // Extract frames into a list
            List<RasterImage> frames = new List<RasterImage>();
            foreach (var page in multipage.Pages)
            {
                // Each page can be treated as a RasterImage
                frames.Add((RasterImage)page);
            }

            // Reverse the order of frames
            frames.Reverse();

            // Prepare APNG creation options with the output file as the source
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100, // default 100 ms per frame
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create a new APNG image with the same dimensions as the source WebP
            using (ApngImage apngImage = (ApngImage)Image.Create(
                createOptions,
                webpImage.Width,
                webpImage.Height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Add frames in the new (reversed) order
                foreach (RasterImage frame in frames)
                {
                    apngImage.AddFrame(frame);
                }

                // Save the APNG to the specified output path
                apngImage.Save();
            }
        }
    }
}