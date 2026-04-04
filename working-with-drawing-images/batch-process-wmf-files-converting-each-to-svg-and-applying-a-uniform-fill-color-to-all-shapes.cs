using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input WMF files
        string[] inputFiles = new[]
        {
            @"c:\temp\example1.wmf",
            @"c:\temp\example2.wmf"
        };

        // Desired uniform fill color for all shapes
        Aspose.Imaging.Color uniformFillColor = Aspose.Imaging.Color.Blue;

        foreach (string inputPath in inputFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output SVG path (same folder, .svg extension)
            string outputPath = Path.ChangeExtension(inputPath, ".svg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WMF image
            using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                // Configure rasterization options with uniform fill color
                WmfRasterizationOptions rasterizationOptions = new WmfRasterizationOptions
                {
                    BackgroundColor = uniformFillColor, // applies as fill color
                    PageSize = wmfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
                };

                saveOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save as SVG
                wmfImage.Save(outputPath, saveOptions);
            }
        }
    }
}