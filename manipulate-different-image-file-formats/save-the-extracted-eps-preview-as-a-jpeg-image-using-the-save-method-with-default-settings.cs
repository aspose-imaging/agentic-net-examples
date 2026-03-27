using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input/sample.eps";
        string outputPath = "output/preview.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Retrieve the preview image (default format)
            var preview = epsImage.GetPreviewImage();

            if (preview != null)
            {
                // Save preview as JPEG with default settings
                preview.Save(outputPath);
            }
            else
            {
                Console.Error.WriteLine("No preview image found in the EPS file.");
            }
        }
    }
}