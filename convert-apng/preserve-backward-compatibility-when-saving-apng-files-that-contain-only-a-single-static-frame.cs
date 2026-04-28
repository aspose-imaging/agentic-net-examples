using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Determine whether the image has more than one frame
                bool isMultiFrame = false;
                if (image is IMultipageImage multiPageImage)
                {
                    isMultiFrame = multiPageImage.PageCount > 1;
                }

                if (isMultiFrame)
                {
                    // Save as animated PNG (APNG) when multiple frames are present
                    image.Save(outputPath, new ApngOptions());
                }
                else
                {
                    // Save as regular PNG to maintain compatibility for single‑frame images
                    image.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}