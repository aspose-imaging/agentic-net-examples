using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Temp\input.emf";
            string outputPath = @"C:\Temp\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Configure SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true,
                    // Use a callback that forces embedding of resources
                    Callback = new InMemorySvgResourceKeeperCallback()
                };

                // Configure rasterization options for the EMF source
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,
                    BackgroundColor = Color.WhiteSmoke,
                    RenderMode = EmfRenderMode.Auto,
                    BorderX = 0,
                    BorderY = 0
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save to a memory stream (SVG with embedded resources)
                using (MemoryStream ms = new MemoryStream())
                {
                    emfImage.Save(ms, svgOptions);

                    // For demonstration, also write the SVG to a file
                    File.WriteAllBytes(outputPath, ms.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Callback that forces all image resources to be embedded in the SVG
class InMemorySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType, string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Force embedding of the image resource
        useEmbeddedImage = true;
        // Return a dummy relative path (not used because the image is embedded)
        return suggestedFileName;
    }

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // No special handling needed for the SVG document itself
        return suggestedFileName;
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a Windows Metafile (EMF) into a scalable SVG for web display while embedding all fonts and images directly in a memory stream for later transmission.
 * 2. When an application must generate SVG thumbnails of EMF reports on the fly and store them in a database without creating temporary files on disk.
 * 3. When a server‑side service has to embed EMF‑based logos into an SVG email template, requiring the resources to be inlined so the email renders correctly in any client.
 * 4. When a document‑conversion pipeline needs to rasterize EMF pages to SVG with a white‑smoke background and then pass the SVG data through a REST API without writing to the file system.
 * 5. When a Windows desktop tool wants to preview an EMF drawing as SVG in a WPF control, using a memory stream to avoid file‑system I/O while preserving all vector and raster elements.
 */