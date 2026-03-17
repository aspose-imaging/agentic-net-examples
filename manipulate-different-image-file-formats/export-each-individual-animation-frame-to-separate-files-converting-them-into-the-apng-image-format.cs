using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Input animated image path (any supported multi-page format)
        string inputPath = "input_animation.webp";
        // Directory to store extracted frames as APNG files
        string outputDir = "ExtractedFrames";
        Directory.CreateDirectory(outputDir);

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Check if the image supports multiple pages/frames
            if (image is IMultipageImage multipage)
            {
                // Iterate through each frame
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Cast the page to RasterImage for saving
                    using (RasterImage frame = (RasterImage)multipage.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.png");
                        // Save the single frame as an APNG image
                        frame.Save(outputPath, new ApngOptions());
                    }
                }
            }
            else
            {
                // Single-frame image case: save directly as APNG
                using (RasterImage raster = (RasterImage)image)
                {
                    string outputPath = Path.Combine(outputDir, "frame_1.png");
                    raster.Save(outputPath, new ApngOptions());
                }
            }
        }
    }
}