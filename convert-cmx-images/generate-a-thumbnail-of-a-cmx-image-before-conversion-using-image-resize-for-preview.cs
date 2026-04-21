using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.cmx";
        string outputPath = "Output\\thumbnail.png";

        // Verify that the input CMX file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image using a fully qualified type name
        using (Aspose.Imaging.FileFormats.Cmx.CmxImage cmxImage = (Aspose.Imaging.FileFormats.Cmx.CmxImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Cache data for better performance (optional)
            cmxImage.CacheData();

            // Determine thumbnail dimensions (e.g., quarter size)
            int thumbWidth = cmxImage.Width / 4;
            int thumbHeight = cmxImage.Height / 4;

            // Resize the image to create a thumbnail
            cmxImage.Resize(thumbWidth, thumbHeight);

            // Save the thumbnail as a PNG file
            cmxImage.Save(outputPath, new PngOptions());
        }
    }
}