using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up SVG export options
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = otgRasterizationOptions,
                Compress = false // keep as plain SVG; we'll minify manually
            };

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }

        // Minify the SVG XML by removing whitespace between tags
        string svgContent = File.ReadAllText(outputPath);
        string minifiedSvg = Regex.Replace(svgContent, @">\s+<", "><");
        File.WriteAllText(outputPath, minifiedSvg);
    }
}