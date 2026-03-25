using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.apng";

        // Validate input file existence
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

            // Collect frames as RasterImage instances
            List<RasterImage> frames = new List<RasterImage>();
            foreach (var page in multipage.Pages)
            {
                frames.Add((RasterImage)page);
            }

            // Modify frame order (example: reverse the order)
            frames.Reverse();

            // Prepare options for creating the APNG
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Use dimensions of the first frame for the new APNG canvas
            int width = frames[0].Width;
            int height = frames[0].Height;

            // Create the APNG image bound to the output file
            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
            {
                // Remove the default single frame
                apngImage.RemoveAllFrames();

                // Add frames in the new order
                foreach (RasterImage frame in frames)
                {
                    apngImage.AddFrame(frame);
                }

                // Save the APNG (output path already bound via FileCreateSource)
                apngImage.Save();
            }
        }
    }
}