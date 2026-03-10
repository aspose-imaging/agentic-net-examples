using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Folder containing the source APNG file
        string baseFolder = @"D:\Images";

        // Input APNG file path
        string inputFile = System.IO.Path.Combine(baseFolder, "animation.apng");

        // Output SVG file path (same name with .svg extension)
        string outputFile = System.IO.Path.ChangeExtension(inputFile, ".svg");

        // Load the APNG image
        using (Image image = Image.Load(inputFile))
        {
            // Configure rasterization options so the SVG page matches the source image size
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Save the loaded image as SVG using the configured options
            image.Save(outputFile, new SvgOptions { VectorRasterizationOptions = rasterizationOptions });
        }
    }
}