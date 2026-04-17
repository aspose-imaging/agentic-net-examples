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

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Try to treat it as an APNG image to access frames
            ApngImage apng = image as ApngImage;
            if (apng != null && apng.PageCount > 0)
            {
                // Extract the first frame
                Image firstFrame = (Image)apng.Pages[0];
                // Save the first frame as a static PNG
                firstFrame.Save(outputPath, new PngOptions());
            }
            else
            {
                // If not an APNG, save the loaded image directly as PNG
                image.Save(outputPath, new PngOptions());
            }
        }
    }
}