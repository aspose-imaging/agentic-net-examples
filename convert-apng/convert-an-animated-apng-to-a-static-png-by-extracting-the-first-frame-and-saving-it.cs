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
        string inputPath = "input.apng";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apngImage = image as ApngImage;
                if (apngImage == null || apngImage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the APNG image.");
                    return;
                }

                // Extract the first frame (as RasterImage)
                using (RasterImage firstFrame = (RasterImage)apngImage.Pages[0])
                {
                    // Save the first frame as a static PNG
                    firstFrame.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}