using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    // Called when an image resource is ready during SVG export.
    // Setting useEmbeddedImage to true forces the image to be embedded as a Base64 string.
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        useEmbeddedImage = true;               // embed the image
        return string.Empty;                   // path is not needed for embedded resources
    }

    // Optional: handle the SVG document ready event (not required for embedding).
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Return empty string to let Aspose handle the default saving.
        return string.Empty;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.emf";
        string outputPath = "output.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the metafile (EMF/WMF) image
            using (Image image = Image.Load(inputPath))
            {
                // Configure SVG export options with the custom callback
                SvgOptions svgOptions = new SvgOptions
                {
                    Callback = new MySvgResourceKeeperCallback(),
                    Compress = false // no compression; images will be embedded as Base64
                };

                // Save the image as SVG with embedded resources
                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to convert Windows Metafile (EMF/WMF) graphics into a self‑contained SVG for web pages, ensuring all raster images are embedded as Base64 strings so the SVG can be displayed without external files.
 * 2. When an application must generate portable vector assets for email newsletters or PDF reports and wants to avoid broken image links by embedding the bitmap resources directly inside the SVG.
 * 3. When a CI/CD pipeline processes legacy design assets and requires automated conversion of metafiles to SVG with embedded images to meet a company's policy of single‑file deliverables.
 * 4. When a mobile app downloads vector icons stored as EMF files and needs to render them in an HTML view without additional network requests for separate image files.
 * 5. When a document management system archives graphics and wants to store each diagram as a single SVG file that includes all embedded raster content, simplifying storage and retrieval.
 */