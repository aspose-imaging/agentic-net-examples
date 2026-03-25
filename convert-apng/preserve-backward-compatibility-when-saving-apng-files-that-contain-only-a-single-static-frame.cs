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

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // If the image is an APNG with a single frame, save as a regular PNG for compatibility
            if (image is ApngImage apng && apng.PageCount == 1)
            {
                // Save as static PNG
                apng.Save(outputPath, new PngOptions());
            }
            else
            {
                // Save as APNG (preserves animation if present)
                image.Save(outputPath, new ApngOptions());
            }
        }
    }
}