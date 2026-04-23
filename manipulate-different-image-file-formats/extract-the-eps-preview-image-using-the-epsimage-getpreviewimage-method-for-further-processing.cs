using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.eps";
            string outputPath = "output/preview.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the preview image (default format)
                using (Image preview = epsImage.GetPreviewImage())
                {
                    if (preview != null)
                    {
                        // Save preview as PNG
                        preview.Save(outputPath, new PngOptions());
                        Console.WriteLine($"Preview image saved to: {outputPath}");
                    }
                    else
                    {
                        Console.Error.WriteLine("No preview image found in the EPS file.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}