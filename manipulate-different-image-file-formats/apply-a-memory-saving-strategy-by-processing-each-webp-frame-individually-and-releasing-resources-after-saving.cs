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
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputDir = "output_frames";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Determine the number of frames in the WebP image
            int frameCount;
            using (WebPImage tempImage = new WebPImage(inputPath))
            {
                if (tempImage is IMultipageImage multipage && multipage.PageCount > 0)
                {
                    frameCount = multipage.PageCount;
                }
                else
                {
                    frameCount = 1; // Single-frame image
                }
            }

            // Process each frame individually
            for (int i = 0; i < frameCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"frame_{i}.png");

                // Ensure the directory for the current output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image anew for each frame to release memory after saving
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    // Configure options to export only the current frame
                    var multiPageOptions = new MultiPageOptions(new IntRange(i, 1));
                    var pngOptions = new PngOptions
                    {
                        MultiPageOptions = multiPageOptions
                    };

                    // Save the current frame as PNG
                    webPImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}