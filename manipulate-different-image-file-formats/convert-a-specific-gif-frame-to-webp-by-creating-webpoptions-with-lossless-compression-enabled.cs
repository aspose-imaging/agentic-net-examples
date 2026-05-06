using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output_frame0.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF animation
            using (Image image = Image.Load(inputPath))
            {
                // Prepare WebP options with lossless compression
                WebPOptions exportOptions = new WebPOptions
                {
                    Lossless = true,
                    // Export only the first frame (index 0)
                    MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(0, 1))
                };

                // Save the selected frame as WebP
                image.Save(outputPath, exportOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}