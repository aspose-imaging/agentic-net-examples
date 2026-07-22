using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\sample.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    Callback = new Base64EmbeddingCallback() // embed images as Base64
                };

                // Configure rasterization options for EMF
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                    BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                    BorderX = 0,
                    BorderY = 0
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG with embedded resources
                emfImage.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Callback that forces image resources to be embedded as Base64 data URIs
    private class Base64EmbeddingCallback : SvgResourceKeeperCallback
    {
        public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
        {
            // Request embedding of the image data
            useEmbeddedImage = true;
            // No external file path is needed
            return null;
        }

        public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
        {
            // No special handling for the final SVG document
            return null;
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) graphics into scalable SVG files for responsive web pages while preserving embedded raster images as Base64 data URIs.
 * 2. When an application must generate SVG reports from EMF charts and ensure all images are self‑contained, eliminating external file dependencies.
 * 3. When a document‑processing service has to embed EMF logos into SVG templates for email newsletters, requiring Base64‑encoded images for reliable rendering across email clients.
 * 4. When a CAD‑to‑web workflow converts engineering drawings stored as EMF into SVG for interactive browsers, and the drawings contain raster textures that must be embedded directly in the SVG.
 * 5. When a batch‑processing tool automates the migration of a legacy asset library from EMF to SVG, embedding each image as Base64 to simplify storage and CDN delivery.
 */