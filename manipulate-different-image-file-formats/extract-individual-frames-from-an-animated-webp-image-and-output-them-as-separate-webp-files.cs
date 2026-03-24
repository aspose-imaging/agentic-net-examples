using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input path
        string inputPath = "C:\\temp\\animated.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the animated WebP image
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Access multipage interface to enumerate frames
            IMultipageImage multipage = webPImage as IMultipageImage;
            if (multipage == null || multipage.PageCount == 0)
            {
                Console.WriteLine("No frames found in the WebP image.");
                return;
            }

            // Iterate through each frame and save it as an individual WebP file
            for (int i = 0; i < multipage.PageCount; i++)
            {
                // Each page is a RasterImage
                RasterImage frame = multipage.Pages[i] as RasterImage;
                if (frame == null)
                    continue;

                // Hardcoded output path for the current frame
                string outputPath = $"C:\\temp\\frame_{i}.webp";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the frame as a WebP image using default options
                frame.Save(outputPath, new WebPOptions());
            }
        }
    }
}