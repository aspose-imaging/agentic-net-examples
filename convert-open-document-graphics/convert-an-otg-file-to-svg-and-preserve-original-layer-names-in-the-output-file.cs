using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
            // Configure OTG rasterization options (preserve original size)
            OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up SVG export options and attach rasterization settings
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = otgRasterOptions
            };

            // Save as SVG; layer names are retained in the exported SVG
            image.Save(outputPath, svgOptions);
        }
    }
}