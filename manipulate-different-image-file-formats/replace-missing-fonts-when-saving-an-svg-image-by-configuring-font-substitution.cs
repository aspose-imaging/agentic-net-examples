using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Configure font substitution: use a default fallback font
            FontSettings.DefaultFontName = "Arial";

            // Optionally, point to a folder containing additional fonts
            // FontSettings.SetFontsFolder(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Save as SVG, the configured FontSettings will be applied automatically
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}