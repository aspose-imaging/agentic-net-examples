using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\source.bigtiff";
        string tempSvgPath = @"C:\Images\temp.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure directories for temporary SVG and final output exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BIGTIFF image and export it to SVG
        using (Image bigTiff = Image.Load(inputPath))
        {
            var svgOptions = new SvgOptions
            {
                // Configure rasterization options for the SVG export
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = bigTiff.Size,
                    BackgroundColor = Color.White
                }
            };
            bigTiff.Save(tempSvgPath, svgOptions);
        }

        // Load the generated SVG and rasterize it to a PNG raster image
        using (SvgImage svgImage = new SvgImage(tempSvgPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                }
            };
            svgImage.Save(outputPath, pngOptions);
        }
    }
}