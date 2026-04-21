using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input EPS files
        string[] inputPaths = new string[]
        {
            @"C:\Images\Input1.eps",
            @"C:\Images\Input2.eps"
        };

        // Corresponding output PNG files
        string[] outputPaths = new string[]
        {
            @"C:\Images\Output1.png",
            @"C:\Images\Output2.png"
        };

        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Apply uniform scaling factor of 2
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize the image (default interpolation)
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Save as PNG preserving transparency
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
    }
}