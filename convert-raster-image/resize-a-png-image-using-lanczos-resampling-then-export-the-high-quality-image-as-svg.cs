using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "Output\\output.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Define new dimensions (example: half the original size)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize using Lanczos resampling
            image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Save the resized image as SVG
            SvgOptions svgOptions = new SvgOptions();
            image.Save(outputPath, svgOptions);
        }
    }
}