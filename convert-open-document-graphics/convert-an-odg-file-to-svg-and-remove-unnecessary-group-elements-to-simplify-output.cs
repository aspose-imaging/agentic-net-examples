using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.odg";
        string outputPath = "sample.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image and save it as SVG
        using (Image image = Image.Load(inputPath))
        {
            var svgOptions = new SvgOptions();
            // Additional options can be set here if needed (e.g., TextAsShapes)

            image.Save(outputPath, svgOptions);
        }
    }
}