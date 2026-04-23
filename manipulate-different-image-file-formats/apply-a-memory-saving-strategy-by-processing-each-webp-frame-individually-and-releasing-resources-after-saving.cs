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
            string outputDir = "output_frames";
            Directory.CreateDirectory(outputDir);

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Check if the image has multiple frames
                if (webPImage is IMultipageImage multipageImage)
                {
                    int frameCount = multipageImage.PageCount;
                    for (int i = 0; i < frameCount; i++)
                    {
                        // Retrieve the frame and cast to RasterImage
                        using (RasterImage rasterFrame = (RasterImage)multipageImage.Pages[i])
                        {
                            string outputPath = Path.Combine(outputDir, $"frame_{i}.png");
                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            // Save the frame as PNG
                            rasterFrame.Save(outputPath, new PngOptions());
                        }
                    }
                }
                else
                {
                    // Single-frame WebP: save as a single PNG
                    string outputPath = Path.Combine(outputDir, "frame_0.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    webPImage.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}