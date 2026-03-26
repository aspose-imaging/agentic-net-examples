using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image and convert it to PNG
        using (Image image = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }

        // Validate that the generated PNG can be loaded (viewable)
        using (PngImage png = (PngImage)Image.Load(outputPath))
        {
            Console.WriteLine($"Saved PNG loaded successfully. Size: {png.Width}x{png.Height}");
        }
    }
}