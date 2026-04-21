using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "preview.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Retrieve the preview image (default format)
            using (Image preview = epsImage.GetPreviewImage())
            {
                if (preview == null)
                {
                    Console.Error.WriteLine("No preview image found in the EPS file.");
                    return;
                }

                // Save the preview image as PNG
                preview.Save(outputPath, new PngOptions());
            }
        }

        Console.WriteLine($"Preview image saved to: {outputPath}");
    }
}