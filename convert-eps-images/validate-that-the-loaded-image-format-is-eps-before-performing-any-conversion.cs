using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Verify that the loaded image is an EPS image
            var epsImage = image as Aspose.Imaging.FileFormats.Eps.EpsImage;
            if (epsImage == null)
            {
                Console.Error.WriteLine("The loaded image is not an EPS file.");
                return;
            }

            // Convert EPS to PNG
            epsImage.Save(outputPath, new PngOptions());
        }
    }
}