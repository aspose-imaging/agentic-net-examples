using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image raster = Image.Load(inputPath))
            {
                // Create an SVG image with the same dimensions as the raster
                using (SvgImage svgImage = new SvgImage(raster.Width, raster.Height))
                {
                    // Configure SVG options with a callback that forces embedding of resources as Base64
                    SvgOptions svgOptions = new SvgOptions
                    {
                        Callback = new Base64ResourceKeeperCallback()
                    };

                    // Save the self‑contained SVG
                    svgImage.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Callback that forces image resources to be embedded as Base64 data URIs
    private class Base64ResourceKeeperCallback : SvgResourceKeeperCallback
    {
        public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
            string suggestedFileName, ref bool useEmbeddedImage)
        {
            // Indicate that the image should be embedded
            useEmbeddedImage = true;
            // Returning an empty string tells Aspose to embed the image directly
            return string.Empty;
        }

        public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
        {
            // No special handling needed for the SVG document itself
            return string.Empty;
        }
    }
}