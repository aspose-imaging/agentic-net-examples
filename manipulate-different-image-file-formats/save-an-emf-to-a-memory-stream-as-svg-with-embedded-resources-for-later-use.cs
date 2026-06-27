using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Svg;

class MySvgResourceKeeperCallback : SvgResourceKeeperCallback
{
    // Called when an image resource (e.g., embedded bitmap) is ready.
    public override string OnImageResourceReady(byte[] imageData, SvgImageType imageType,
        string suggestedFileName, ref bool useEmbeddedImage)
    {
        // Request embedding the image directly into the SVG.
        useEmbeddedImage = true;
        // Return a placeholder path; the actual data will be embedded.
        return suggestedFileName;
    }

    // Called when the SVG document itself is ready.
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Return the suggested file name; not used when saving to a stream.
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = @"C:\temp\test.emf";
        string outputPath = @"C:\temp\output.svg";

        // Ensure any runtime exception is reported cleanly.
        try
        {
            // Verify the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (even though we save to a stream).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image.
            using (EmfImage emfImage = (EmfImage)Image.Load(inputPath))
            {
                // Configure SVG save options.
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true,                     // Render text as shapes.
                    Callback = new MySvgResourceKeeperCallback()
                };

                // Set up rasterization options specific to EMF.
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = emfImage.Size,                // Use the original EMF size.
                    BackgroundColor = Color.WhiteSmoke,     // Optional background.
                    RenderMode = EmfRenderMode.Auto,        // Auto‑detect rendering mode.
                    BorderX = 0,
                    BorderY = 0
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the SVG to a memory stream.
                using (MemoryStream ms = new MemoryStream())
                {
                    emfImage.Save(ms, svgOptions);
                    // The SVG bytes are now in ms; they can be used later.
                    // Example: reset position and read as string (optional).
                    ms.Position = 0;
                    string svgContent = new StreamReader(ms).ReadToEnd();
                    Console.WriteLine("SVG conversion succeeded. Length: " + svgContent.Length);
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
 * 1. When a developer needs to convert a Windows Metafile (EMF) into an SVG stream with all bitmap resources embedded for seamless web rendering, this code provides a ready‑to‑use solution.
 * 2. When an application must generate scalable vector graphics from legacy EMF assets on the fly without writing intermediate files, the in‑memory save approach shown here is ideal.
 * 3. When a reporting tool requires SVG output that preserves text as shapes and includes embedded images to avoid external dependencies, this snippet demonstrates the necessary Aspose.Imaging configuration.
 * 4. When a cloud‑based service processes user‑uploaded EMF files and returns SVG content via an API response, the memory‑stream workflow ensures fast, file‑system‑free delivery.
 * 5. When a developer is building a document conversion pipeline that needs to maintain visual fidelity by embedding all image resources directly into the SVG, the custom SvgResourceKeeperCallback illustrated in this example handles the embedding automatically.
 */