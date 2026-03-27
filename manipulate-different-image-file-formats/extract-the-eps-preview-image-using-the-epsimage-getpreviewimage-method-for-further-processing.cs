using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.eps";
        string outputPath = "preview.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Get the preview image (default format)
            using (var preview = epsImage.GetPreviewImage())
            {
                if (preview == null)
                {
                    Console.Error.WriteLine("No preview image found in the EPS file.");
                    return;
                }

                // Save the preview image as PNG
                var pngOptions = new PngOptions();
                preview.Save(outputPath, pngOptions);
            }
        }
    }
}