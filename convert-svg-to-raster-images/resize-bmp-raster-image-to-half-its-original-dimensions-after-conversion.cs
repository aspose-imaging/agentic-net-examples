using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths (relative)
        string inputPath = "Input/sample.bmp";
        string outputPath = "Output/resized.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Resize to half of original dimensions (default NearestNeighbourResample)
            image.Resize(image.Width / 2, image.Height / 2);

            // Save the resized image as BMP
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}