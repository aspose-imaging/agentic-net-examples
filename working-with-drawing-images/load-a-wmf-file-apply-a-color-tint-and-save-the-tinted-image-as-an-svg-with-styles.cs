using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Prepare SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                TextAsShapes = true // render text as shapes
            };

            // Configure rasterization options with a background tint (acts as a simple color tint)
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.LightBlue, // tint color
                PageSize = wmfImage.Size,
                RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
            };

            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the tinted image as SVG
            wmfImage.Save(outputPath, svgOptions);
        }
    }
}