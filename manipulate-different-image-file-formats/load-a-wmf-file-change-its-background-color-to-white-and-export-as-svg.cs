using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Prepare SVG save options
            SvgOptions saveOptions = new SvgOptions
            {
                TextAsShapes = true
            };

            // Configure rasterization options with white background
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageSize = wmfImage.Size,
                RenderMode = Aspose.Imaging.FileFormats.Wmf.WmfRenderMode.Auto
            };

            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            wmfImage.Save(outputPath, saveOptions);
        }
    }
}