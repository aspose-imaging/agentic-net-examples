using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Remove background if the image is a vector image
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground();
            }

            // Prepare PNG save options with default compression
            PngOptions pngOptions = new PngOptions();

            // Set rasterization options for vector images
            pngOptions.VectorRasterizationOptions = (VectorRasterizationOptions)image.GetDefaultOptions(
                new object[] { Aspose.Imaging.Color.White, image.Width, image.Height });

            // Save the rasterized image as PNG
            image.Save(outputPath, pngOptions);
        }
    }
}