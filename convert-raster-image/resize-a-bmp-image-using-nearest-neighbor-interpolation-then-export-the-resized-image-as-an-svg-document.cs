using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\source.bmp";
        string outputPath = @"C:\Images\resized.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image, resize it using the default NearestNeighbourResample,
        // and save the result as an SVG document.
        using (Image image = Image.Load(inputPath))
        {
            // Desired dimensions for the resized image
            int newWidth = 200;   // example width
            int newHeight = 200;  // example height

            // Resize with nearest‑neighbor interpolation (default behavior)
            image.Resize(newWidth, newHeight);

            // Save the resized image as SVG
            image.Save(outputPath, new SvgOptions());
        }
    }
}