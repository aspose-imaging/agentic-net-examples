using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.wmf";
        string outputPath = "output/output.svg";

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
            // Calculate new canvas size (increase by 10%)
            int newWidth = (int)(wmfImage.Width * 1.1);
            int newHeight = (int)(wmfImage.Height * 1.1);

            // Center the original image within the new canvas
            int offsetX = (wmfImage.Width - newWidth) / 2;
            int offsetY = (wmfImage.Height - newHeight) / 2;
            var newRect = new Rectangle(offsetX, offsetY, newWidth, newHeight);

            // Resize the canvas
            wmfImage.ResizeCanvas(newRect);

            // Prepare SVG save options
            var saveOptions = new SvgOptions
            {
                TextAsShapes = true
            };

            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                RenderMode = WmfRenderMode.Auto
            };

            saveOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            wmfImage.Save(outputPath, saveOptions);
        }
    }
}