using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.odg";
        string outputPath = "output.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load ODG image and save as SVG preserving vector data
        using (Image image = Image.Load(inputPath))
        {
            SvgOptions saveOptions = new SvgOptions();

            // Configure vector rasterization options
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White
            };
            saveOptions.VectorRasterizationOptions = vectorOptions;

            // Save to SVG
            image.Save(outputPath, saveOptions);
        }
    }
}