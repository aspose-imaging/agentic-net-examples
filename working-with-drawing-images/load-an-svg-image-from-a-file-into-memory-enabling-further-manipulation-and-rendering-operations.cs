using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input SVG file path
        string inputPath = @"C:\Images\sample.svg";

        // Verify that the input file exists; if not, write error and exit
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the SVG image into memory using Aspose.Imaging
        // The SvgImage constructor that accepts a file path is used here
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // At this point the SVG image is loaded and can be manipulated.
            // Example: access image dimensions
            Console.WriteLine($"Loaded SVG - Width: {svgImage.Width}, Height: {svgImage.Height}");

            // Placeholder for further manipulation or rendering operations
            // e.g., rasterization, resizing, etc.
        }

        // No output file is saved in this example, but if saving were required,
        // the following pattern must be used for the output path:
        // string outputPath = @"C:\Images\output.png";
        // Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        // svgImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
    }
}