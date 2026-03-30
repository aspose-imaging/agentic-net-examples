using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths (preserve original filename)
        string inputPath = @"C:\Templates\sample.svg";
        string outputPath = @"C:\Templates\sample.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Here you could apply any filtering to the SVG.
            // For this example we simply re‑save it unchanged.

            // Save the SVG back to the templates folder preserving the original name
            var saveOptions = new SvgOptions(); // default options for SVG
            image.Save(outputPath, saveOptions);
        }
    }
}