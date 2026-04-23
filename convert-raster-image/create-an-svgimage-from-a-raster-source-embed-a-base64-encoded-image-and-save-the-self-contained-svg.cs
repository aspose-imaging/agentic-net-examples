using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

// Custom callback that embeds the raster image as a base64 data URI
class EmbedRasterCallback : SvgResourceKeeperCallback
{
    private readonly byte[] _rasterData;
    private readonly string _mimeType;

    public EmbedRasterCallback(byte[] rasterData, string mimeType = "image/png")
    {
        _rasterData = rasterData;
        _mimeType = mimeType;
    }

    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Force embedding and return a data URI containing the base64‑encoded raster
        useEmbeddedImage = true;
        string base64 = Convert.ToBase64String(_rasterData);
        return $"data:{_mimeType};base64,{base64}";
    }

    // The other callback methods are not needed for this scenario
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        return null;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input (raster) and output (self‑contained SVG) paths
        string inputPath = @"C:\Temp\input.png";
        string outputPath = @"C:\Temp\output.svg";

        // Verify the raster source exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image rasterImage = Image.Load(inputPath))
        {
            // Export the raster image to a memory stream (PNG format) to obtain raw bytes
            byte[] rasterBytes;
            using (var ms = new MemoryStream())
            {
                rasterImage.Save(ms, new PngOptions());
                rasterBytes = ms.ToArray();
            }

            // Prepare a minimal SVG document that references a placeholder image
            int width = rasterImage.Width;
            int height = rasterImage.Height;
            string svgTemplate = $@"
<svg xmlns='http://www.w3.org/2000/svg' width='{width}' height='{height}'>
    <image href='placeholder.png' width='{width}' height='{height}'/>
</svg>";

            // Load the SVG template from a stream
            using (var svgStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(svgTemplate)))
            using (SvgImage svgImage = new SvgImage(svgStream))
            {
                // Configure SVG options with the custom callback for embedding
                var svgOptions = new SvgOptions
                {
                    Callback = new EmbedRasterCallback(rasterBytes)
                };

                // Save the self‑contained SVG; the callback will replace the placeholder with the base64 image
                svgImage.Save(outputPath, svgOptions);
            }
        }
    }
}