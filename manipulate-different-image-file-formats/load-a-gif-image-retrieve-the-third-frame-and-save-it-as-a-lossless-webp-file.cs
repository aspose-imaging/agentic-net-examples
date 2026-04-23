using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output\\frame3.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load GIF image
            using (Image gifImage = Image.Load(inputPath))
            {
                // Cast to multipage interface
                IMultipageImage multipage = gifImage as IMultipageImage;
                if (multipage == null || multipage.PageCount <= 2)
                {
                    Console.Error.WriteLine("The GIF does not contain a third frame.");
                    return;
                }

                // Retrieve the third frame (zero‑based index 2)
                RasterImage thirdFrame = (RasterImage)multipage.Pages[2];

                // Convert the frame to a lossless WebP image
                using (WebPImage webpImage = new WebPImage(thirdFrame))
                {
                    WebPOptions options = new WebPOptions
                    {
                        Lossless = true
                    };
                    webpImage.Save(outputPath, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}