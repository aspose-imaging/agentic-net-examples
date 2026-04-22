using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.png";
            string outputPath = @"C:\Images\result.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Determine if the image is an animated PNG with more than one frame
                bool isAnimatedApng = image is ApngImage apng && apng.PageCount > 1;

                if (isAnimatedApng)
                {
                    // Save as APNG preserving animation
                    // Use .apng extension for clarity; adjust outputPath if needed
                    string apngOutput = Path.ChangeExtension(outputPath, ".apng");
                    Directory.CreateDirectory(Path.GetDirectoryName(apngOutput));
                    image.Save(apngOutput, new ApngOptions());
                }
                else
                {
                    // Single-frame image – save as regular PNG for maximum compatibility
                    image.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}