using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output/output.webp";

        // Validate input file existence
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
            using (Image image = Image.Load(inputPath))
            {
                // Configure WebP options for lossless compression and select the first frame (index 0)
                WebPOptions webpOptions = new WebPOptions
                {
                    Lossless = true,
                    MultiPageOptions = new MultiPageOptions(new IntRange(0, 0))
                };

                // Save the selected frame as a lossless WebP image
                image.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}