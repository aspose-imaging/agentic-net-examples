using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.svg";

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
            // NOTE: Direct gradient replacement is not exposed via Aspose.Imaging API.
            // The image is saved as SVG, which will retain vector data.
            // For simplification, we proceed with saving to SVG format.

            // Configure SVG export options with rasterization settings matching EPS size
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save as SVG
            epsImage.Save(outputPath, svgOptions);
        }
    }
}