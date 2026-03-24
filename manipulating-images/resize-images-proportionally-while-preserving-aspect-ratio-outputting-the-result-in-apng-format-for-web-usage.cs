using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

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
            // Define the target width (height will be adjusted automatically to keep aspect ratio)
            int targetWidth = 800; // adjust as needed

            // Resize proportionally using a high‑quality resampling method
            image.ResizeWidthProportionally(targetWidth, ResizeType.BilinearResample);

            // Save the resized image as an APNG file
            var apngOptions = new ApngOptions();
            image.Save(outputPath, apngOptions);
        }
    }
}