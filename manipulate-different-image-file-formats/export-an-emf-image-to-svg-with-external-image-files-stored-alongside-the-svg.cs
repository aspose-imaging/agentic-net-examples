using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    private readonly string _outputDirectory;

    public MySvgResourceKeeperCallback(string outputDirectory)
    {
        _outputDirectory = outputDirectory;
    }

    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Save the external image next to the SVG file.
        string fullPath = Path.Combine(_outputDirectory, suggestedFileName);
        File.WriteAllBytes(fullPath, imageData);
        // Return the relative path (just the file name) for the SVG document.
        return suggestedFileName;
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Not used in this scenario; default handling.
        return base.OnSvgDocumentReady(htmlData, suggestedFileName);
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = @"C:\temp\test.emf";
        string outputPath = @"C:\temp\test.output.svg";

        try
        {
            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image.
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options.
                var saveOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    Callback = new MySvgResourceKeeperCallback(Path.GetDirectoryName(outputPath))
                };

                // Configure rasterization options for EMF.
                var rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = EmfRenderMode.Auto,
                    BorderX = 0,
                    BorderY = 0
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG; external resources will be written by the callback.
                emfImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a Windows desktop application needs to convert legacy EMF vector drawings into web‑ready SVG files while keeping embedded raster images as separate files for faster loading.
 * 2. When an automated reporting system generates charts as EMF and must publish them to an HTML portal that requires SVG with external PNG resources for responsive design.
 * 3. When a document conversion service processes engineering diagrams stored in EMF and must preserve image fidelity by exporting them to SVG with linked image assets for downstream CAD tools.
 * 4. When a batch migration script moves a library of EMF icons to an SVG sprite sheet and needs to store each icon’s bitmap components as individual files next to the SVG for caching.
 * 5. When a GIS application exports map overlays created in EMF to SVG and wants to keep large raster layers as external image files to reduce the SVG file size and improve rendering performance.
 */