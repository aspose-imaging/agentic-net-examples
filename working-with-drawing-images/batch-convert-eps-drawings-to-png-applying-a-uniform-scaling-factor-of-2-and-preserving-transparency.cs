using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded list of EPS files to convert
        string[] inputFiles = new[]
        {
            "input1.eps",
            "input2.eps"
        };

        // Output directory (hardcoded)
        string outputDirectory = "output";

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Determine output PNG path
            string outputPath = Path.Combine(outputDirectory,
                Path.GetFileNameWithoutExtension(inputPath) + ".png");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Calculate new dimensions (scale factor 2)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize using nearest neighbour resampling (preserves transparency)
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Save as PNG with default options (transparency preserved)
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
    }
}