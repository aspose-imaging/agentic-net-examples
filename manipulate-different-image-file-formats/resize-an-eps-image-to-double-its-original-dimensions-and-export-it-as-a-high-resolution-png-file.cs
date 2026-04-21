using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.png";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image, resize it to double its original size, and save as PNG
        using (var image = Image.Load(inputPath) as EpsImage)
        {
            if (image == null)
            {
                Console.Error.WriteLine("Failed to load EPS image.");
                return;
            }

            // Calculate new dimensions (double the original width and height)
            int newWidth = image.Width * 2;
            int newHeight = image.Height * 2;

            // Resize using a high-quality interpolation method
            image.Resize(newWidth, newHeight, ResizeType.Mitchell);

            // Save the resized image as a high‑resolution PNG
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}