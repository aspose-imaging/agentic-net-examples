using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect input APNG path and output SVG path as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <input_apng_path> <output_svg_path>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Save as SVG using default options
            image.Save(outputPath, new SvgOptions());
        }

        Console.WriteLine("Conversion completed.");
    }
}