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
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG export options
            var svgOptions = new SvgOptions
            {
                // Keep text as text (fonts will be referenced)
                TextAsShapes = false,
                // Provide a callback to handle embedded resources such as fonts
                Callback = new FontEmbeddingCallback()
            };

            // Save as SVG with embedded fonts
            image.Save(outputPath, svgOptions);
        }
    }

    // Callback that can be extended to embed fonts or other resources.
    private class FontEmbeddingCallback : SvgResourceKeeperCallback
    {
        // Called when the SVG document is ready for export.
        public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
        {
            // Save the SVG data to the suggested file name.
            string targetPath = Path.Combine(Path.GetDirectoryName(suggestedFileName) ?? ".", suggestedFileName);
            File.WriteAllBytes(targetPath, htmlData);
            return targetPath;
        }

        // Called when an image resource (e.g., embedded font) is ready for export.
        public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
                                                    string suggestedFileName, ref bool useEmbeddedImage)
        {
            // Indicate that the resource should be embedded.
            useEmbeddedImage = true;

            // Save the resource data to a file relative to the SVG document.
            string resourcePath = Path.Combine(Path.GetDirectoryName(suggestedFileName) ?? ".", suggestedFileName);
            File.WriteAllBytes(resourcePath, imageData);
            return resourcePath;
        }
    }
}