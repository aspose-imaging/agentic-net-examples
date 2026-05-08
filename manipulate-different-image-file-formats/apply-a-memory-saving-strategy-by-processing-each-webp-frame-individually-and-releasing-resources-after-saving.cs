using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WebP file path
            string inputPath = "input.webp";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory to store extracted frames
            string outputDir = "frames";
            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the animated WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Verify the image supports multiple pages/frames
                IMultipageImage multipage = webPImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage WebP.");
                    return;
                }

                int pageCount = multipage.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    // Retrieve the i‑th frame
                    var frame = multipage.Pages[i];

                    // Cast the frame to RasterImage for saving
                    using (RasterImage frameImage = (RasterImage)frame)
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{i}.png");
                        // Ensure the directory for this frame exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as PNG
                        frameImage.Save(outputPath, new PngOptions());
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