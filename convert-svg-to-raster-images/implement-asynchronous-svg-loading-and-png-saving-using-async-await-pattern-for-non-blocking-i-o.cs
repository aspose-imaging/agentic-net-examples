using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static async Task Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image asynchronously
        using (Image image = await Task.Run(() => Image.Load(inputPath)))
        {
            // Cast to SvgImage
            SvgImage svgImage = image as SvgImage;
            if (svgImage == null)
            {
                Console.Error.WriteLine("Failed to load SVG image.");
                return;
            }

            // Configure rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White
            };

            // Configure PNG save options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save PNG image asynchronously
            await Task.Run(() => svgImage.Save(outputPath, pngOptions));
        }
    }
}