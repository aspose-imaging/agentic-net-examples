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
        try
        {
            // Hardcoded input WebP file path
            string inputPath = "input.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Directory where extracted BMP frames will be saved
            string outputDirectory = "output_frames";

            // Load the WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Attempt to treat the loaded image as a multipage image
                IMultipageImage multipage = image as IMultipageImage;

                if (multipage != null && multipage.PageCount > 0)
                {
                    // Export each frame of the animation
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        // Cast the page to RasterImage
                        RasterImage frame = (RasterImage)multipage.Pages[i];

                        // Build output BMP file path
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as BMP
                        frame.Save(outputPath, new BmpOptions());
                    }
                }
                else
                {
                    // Single-frame WebP (or non-multipage) – save as a single BMP
                    RasterImage raster = (RasterImage)image;
                    string outputPath = Path.Combine(outputDirectory, "frame_0.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    raster.Save(outputPath, new BmpOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}