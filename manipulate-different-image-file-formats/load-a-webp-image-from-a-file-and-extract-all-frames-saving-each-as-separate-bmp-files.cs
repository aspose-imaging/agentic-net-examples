using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputDir = "output_frames";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure the output directory exists before any saves
            Directory.CreateDirectory(outputDir);

            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // WebPImage implements IMultipageImage
                var multipage = webPImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Each page is a frame; cast to RasterImage for saving
                    using (RasterImage frame = (RasterImage)multipage.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");
                        // Create directory for each output file (safeguard)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        BmpOptions bmpOptions = new BmpOptions();
                        frame.Save(outputPath, bmpOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}