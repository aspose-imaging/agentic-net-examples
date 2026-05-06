using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.webp";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the GIF image
            using (Image gifImage = Image.Load(inputPath))
            {
                // Cast to multipage image to access frames
                IMultipageImage multipage = gifImage as IMultipageImage;
                if (multipage == null || multipage.PageCount < 5)
                {
                    Console.Error.WriteLine("The GIF does not contain at least five frames.");
                    return;
                }

                // Get the fifth frame (zero‑based index 4)
                RasterImage fifthFrame = (RasterImage)multipage.Pages[4];

                // Create a WebP image from the selected frame
                using (WebPImage webPImage = new WebPImage(fifthFrame))
                {
                    // Set lossless compression options
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };

                    // Save as lossless WebP
                    webPImage.Save(outputPath, webpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}