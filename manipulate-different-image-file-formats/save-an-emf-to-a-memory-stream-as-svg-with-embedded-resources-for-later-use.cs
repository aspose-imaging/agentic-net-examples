using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    // Custom callback that forces all image resources to be embedded into the SVG.
    class EmbeddedResourceCallback : SvgResourceKeeperCallback
    {
        public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
        {
            // Instruct the exporter to embed the image data directly.
            useEmbeddedImage = true;
            // No external file is created, so return null.
            return null;
        }

        public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
        {
            // No external SVG file is written; the caller receives the data from the memory stream.
            return null;
        }
    }

    static void Main()
    {
        // Hard‑coded input path.
        string inputPath = @"C:\temp\test.emf";

        // Verify that the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the EMF image.
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Prepare SVG save options.
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    Callback = new EmbeddedResourceCallback()
                };

                // Configure rasterization options for the EMF source.
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                    BorderX = 50,
                    BorderY = 50
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the SVG into a memory stream.
                using (MemoryStream svgStream = new MemoryStream())
                {
                    emfImage.Save(svgStream, svgOptions);

                    // At this point svgStream contains the SVG data with embedded resources.
                    // The stream can be used later (e.g., written to a file, sent over a network, etc.).
                    // Example: write to a file for verification (optional).
                    string outputPath = @"C:\temp\test.output.svg";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    File.WriteAllBytes(outputPath, svgStream.ToArray());
                }
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
 * 1. When a developer needs to convert Windows Metafile (EMF) charts into scalable SVG graphics for web dashboards without creating external image files.
 * 2. When an application must embed all raster resources directly into an SVG payload to ensure the SVG can be sent over APIs or stored in a database as a single blob.
 * 3. When generating printable vector reports from EMF logos and embedding them in SVG for responsive email newsletters that must render correctly on any client.
 * 4. When a cloud service processes user‑uploaded EMF files and returns an in‑memory SVG stream for further manipulation or streaming to a front‑end without touching the file system.
 * 5. When building a C# microservice that transforms legacy EMF icons into self‑contained SVG assets for inclusion in mobile app resource bundles.
 */