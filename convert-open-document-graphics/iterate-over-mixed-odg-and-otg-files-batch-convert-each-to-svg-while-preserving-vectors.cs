using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded list of input files (ODG and OTG)
        string[] inputFiles = new[]
        {
            @"C:\Images\sample1.odg",
            @"C:\Images\sample2.otg",
            @"C:\Images\sample3.odg",
            @"C:\Images\sample4.otg"
        };

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output SVG path
            string outputPath = inputPath + ".svg";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (ODG or OTG)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG rasterization options preserving vector data
                var svgRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare SVG save options
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = svgRasterizationOptions,
                    // Keep vectors; no compression needed for lossless SVG
                    Compress = false
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }

            Console.WriteLine($"Converted '{inputPath}' to SVG at '{outputPath}'.");
        }
    }
}