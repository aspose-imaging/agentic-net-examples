using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            string inputPath = "input.webp";
            string outputPath = "output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webpImage = new WebPImage(inputPath))
            {
                // Extract frames as RasterImage objects
                List<RasterImage> frames = ((IMultipageImage)webpImage).Pages
                    .Cast<RasterImage>()
                    .ToList();

                // Reverse frame order (example modification)
                frames.Reverse();

                // Prepare options for creating APNG
                Source source = new FileCreateSource(outputPath, false);
                ApngOptions apngOptions = new ApngOptions
                {
                    Source = source,
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, webpImage.Width, webpImage.Height))
                {
                    apngImage.RemoveAllFrames();

                    foreach (RasterImage frame in frames)
                    {
                        apngImage.AddFrame(frame);
                    }

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