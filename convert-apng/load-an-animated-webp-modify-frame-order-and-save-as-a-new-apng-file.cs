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
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image
            using (Image webpImage = Image.Load(inputPath))
            {
                IMultipageImage multipage = webpImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The input file is not a multipage (animated) image.");
                    return;
                }

                // Extract frames as RasterImage objects
                List<RasterImage> frames = new List<RasterImage>();
                foreach (var page in multipage.Pages)
                {
                    frames.Add((RasterImage)page);
                }

                if (frames.Count == 0)
                {
                    Console.Error.WriteLine("No frames found in the input image.");
                    return;
                }

                // Modify frame order (example: reverse the order)
                frames.Reverse();

                // Prepare APNG creation options
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create APNG image with the size of the first frame
                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, frames[0].Width, frames[0].Height))
                {
                    apngImage.RemoveAllFrames();

                    // Add frames in the new order
                    foreach (var frame in frames)
                    {
                        apngImage.AddFrame(frame);
                    }

                    // Save the APNG (output path is already bound via FileCreateSource)
                    apngImage.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}