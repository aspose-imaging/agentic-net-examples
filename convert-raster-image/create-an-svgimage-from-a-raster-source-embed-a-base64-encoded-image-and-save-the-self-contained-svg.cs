using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image rasterImage = Image.Load(inputPath))
        {
            // Prepare SVG save options with a callback that forces embedding
            var svgOptions = new SvgOptions
            {
                Callback = new EmbedCallback()
            };

            // Set rasterization options so the generated SVG matches the source size
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = rasterImage.Size
            };
            svgOptions.VectorRasterizationOptions = vectorOptions;

            // Save as a self‑contained SVG (raster image will be base64‑encoded)
            rasterImage.Save(outputPath, svgOptions);
        }
    }

    // Callback that tells Aspose.Imaging to embed the raster image as base64
    class EmbedCallback : SvgResourceKeeperCallback
    {
        public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
                                                    string suggestedFileName, ref bool useEmbeddedImage)
        {
            useEmbeddedImage = true; // Force embedding
            return null; // No external file path needed
        }

        public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
        {
            // Not required for this scenario
            return null;
        }
    }
}