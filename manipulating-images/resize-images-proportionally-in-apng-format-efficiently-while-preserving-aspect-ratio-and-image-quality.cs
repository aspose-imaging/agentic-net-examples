using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output_resized.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the APNG image
        using (ApngImage apngImage = (ApngImage)Image.Load(inputPath))
        {
            // Determine new width (e.g., reduce size by 50%)
            int newWidth = apngImage.Width / 2;

            // Resize proportionally using a high‑quality resampling method
            apngImage.ResizeWidthProportionally(newWidth, ResizeType.BilinearResample);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the resized APNG image
            apngImage.Save(outputPath);
        }
    }
}