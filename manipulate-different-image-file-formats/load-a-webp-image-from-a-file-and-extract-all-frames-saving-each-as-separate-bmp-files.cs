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
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputDirectory = "output_frames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Cast to multipage interface to access frames
                IMultipageImage multipage = webPImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage WebP.");
                    return;
                }

                int frameCount = multipage.PageCount;

                for (int i = 0; i < frameCount; i++)
                {
                    // Retrieve the frame
                    var frame = multipage.Pages[i];

                    // Cast frame to RasterImage for saving
                    RasterImage raster = frame as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Frame {i} is not a raster image.");
                        continue;
                    }

                    // Build output path for this frame
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as BMP
                    BmpOptions bmpOptions = new BmpOptions();
                    raster.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}