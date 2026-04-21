using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.eps";
        string outputPath = "output/preview.jpg";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (var epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Extract the preview image using the default format
            var previewImage = epsImage.GetPreviewImage();

            if (previewImage == null)
            {
                Console.Error.WriteLine("No preview image found in the EPS file.");
                return;
            }

            // Save the preview image as JPEG with default settings
            previewImage.Save(outputPath);
        }
    }
}