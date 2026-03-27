using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class EmbeddedImageCallback : SvgResourceKeeperCallback
{
    // Called when an image resource (e.g., raster image) is ready during SVG export.
    // Setting useEmbeddedImage to true forces the image to be embedded as Base64.
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
    {
        useEmbeddedImage = true; // embed the image data
        return null; // no external file path needed
    }

    // Optional: handle SVG document ready event (not required for embedding)
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Return null to let the library handle saving the SVG document.
        return null;
    }
}

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\test.emf";
        string outputPath = @"C:\temp\test.output.svg";

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
            // Configure SVG export options
            SvgOptions saveOptions = new SvgOptions
            {
                TextAsShapes = true,                     // render text as shapes
                Callback = new EmbeddedImageCallback()   // embed raster resources as Base64
            };

            // Configure rasterization options specific to EMF
            EmfRasterizationOptions rasterizationOptions = new EmfRasterizationOptions
            {
                BackgroundColor = Color.WhiteSmoke,
                PageSize = emfImage.Size,
                RenderMode = EmfRenderMode.Auto,
                BorderX = 0,
                BorderY = 0
            };

            saveOptions.VectorRasterizationOptions = rasterizationOptions;

            // Save as SVG with embedded images
            emfImage.Save(outputPath, saveOptions);
        }
    }
}