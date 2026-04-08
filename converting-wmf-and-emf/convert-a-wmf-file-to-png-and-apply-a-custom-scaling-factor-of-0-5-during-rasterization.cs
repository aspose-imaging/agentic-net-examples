using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.wmf";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WMF image and rasterize to PNG with 0.5 scaling factor
        using (WmfImage wmfImage = (WmfImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Calculate half size for scaling
            float halfWidth = wmfImage.Width * 0.5f;
            float halfHeight = wmfImage.Height * 0.5f;

            // Configure rasterization options
            WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
            {
                PageSize = new Aspose.Imaging.SizeF(halfWidth, halfHeight),
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Set PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            wmfImage.Save(outputPath, pngOptions);
        }
    }
}