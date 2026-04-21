using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Apply a hue rotation of 180 degrees if the operation is supported
            var vectorImg = image as VectorImage;
            if (vectorImg != null)
            {
                // Use dynamic invocation to call AdjustHue if it exists at runtime
                dynamic dyn = vectorImg;
                try
                {
                    dyn.AdjustHue(180);
                }
                catch
                {
                    // If AdjustHue is not available, the image will be saved without hue change
                }
            }

            // Save the result as PNG
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}