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
        string inputPath = "input\\animation.webp";
        string outputPath = "output\\animation.apng.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image webpImage = Image.Load(inputPath))
            {
                IMultipageImage multipage = webpImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No animation frames found in the WebP image.");
                    return;
                }

                int newWidth = webpImage.Width / 2;
                int newHeight = webpImage.Height / 2;

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, newWidth, newHeight))
                {
                    apngImage.RemoveAllFrames();

                    foreach (Image page in multipage.Pages)
                    {
                        RasterImage frame = page as RasterImage;
                        if (frame == null)
                            continue;

                        frame.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
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