using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.eps";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            // Prepare SVG rasterization options matching the EPS size
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = epsImage.Size
            };

            // Configure SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions,
                // Render all text as shapes to avoid text gradients (optional)
                TextAsShapes = true
            };

            // Save as SVG
            epsImage.Save(outputPath, svgOptions);
        }
    }
}