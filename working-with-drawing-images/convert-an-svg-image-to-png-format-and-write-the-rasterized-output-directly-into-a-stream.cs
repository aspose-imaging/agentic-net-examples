using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.svg";
        string outputPath = @"C:\Temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Open input SVG stream and rasterize to PNG written into an output stream
        using (Stream inputStream = File.OpenRead(inputPath))
        using (SvgImage svgImage = new SvgImage(inputStream))
        using (FileStream outputStream = File.Open(outputPath, FileMode.Create, FileAccess.Write))
        {
            // Set up rasterization options for SVG
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

            // Configure PNG save options and attach rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save rasterized PNG directly to the output stream
            svgImage.Save(outputStream, pngOptions);
        }
    }
}