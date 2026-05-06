using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\animation.webp";
            string outputDirectory = @"C:\temp\frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (CreateDirectory works even if the path is null)
            Directory.CreateDirectory(outputDirectory);

            // Load the WebP animation
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Try to treat the image as a multipage image
                IMultipageImage multipage = webPImage as IMultipageImage;

                if (multipage != null && multipage.PageCount > 0)
                {
                    // Iterate through each frame
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        // Each page is an IFrame; cast to RasterImage for saving
                        RasterImage frame = multipage.Pages[i] as RasterImage;
                        if (frame == null)
                            continue;

                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.bmp");

                        // Ensure the directory for this file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as BMP
                        frame.Save(outputPath, new BmpOptions());
                    }
                }
                else
                {
                    // Single-frame WebP (fallback)
                    string outputPath = Path.Combine(outputDirectory, "frame_0.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    webPImage.Save(outputPath, new BmpOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}