using System;
using System.IO;
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

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the WebP image
            using (WebPImage webP = new WebPImage(inputPath))
            {
                // Cast to multipage interface to access frames
                var multipage = webP as Aspose.Imaging.IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image does not support multiple frames.");
                    return;
                }

                int pageCount = multipage.PageCount;

                // Iterate through each frame
                for (int i = 0; i < pageCount; i++)
                {
                    // Retrieve the frame
                    var frame = multipage.Pages[i];

                    // Cast frame to RasterImage for saving
                    var raster = frame as Aspose.Imaging.RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Frame {i} is not a raster image.");
                        continue;
                    }

                    // Define output BMP file path for the current frame
                    string outputPath = $"frame_{i}.bmp";

                    // Ensure the output directory exists (guard against null/empty)
                    string outputDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrWhiteSpace(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Save the frame as BMP
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