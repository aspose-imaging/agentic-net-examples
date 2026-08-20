// HOW-TO: Convert EMF to SVG with Embedded Resources Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Temp\test.emf";
            string outputPath = @"C:\Temp\output.svg";

            // Verify that the input file exists
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
                // Set up SVG save options
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true // render text as shapes
                };

                // Configure rasterization options specific to EMF
                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.WhiteSmoke,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto,
                    BorderX = 0,
                    BorderY = 0
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save the SVG to a memory stream (embedded resources are kept in the stream)
                using (MemoryStream ms = new MemoryStream())
                {
                    emfImage.Save(ms, svgOptions);

                    // Example: write the memory stream to a file for later inspection
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

/*
 * Real-World Use Cases:
 * 1. When you need to display vector graphics from a Windows Metafile on a web page without external files, you can convert the EMF to an SVG stored in a memory stream.
 * 2. When generating dynamic reports that embed charts as EMF files and require them to be exported as scalable SVGs for PDF or HTML output, this code handles the conversion.
 * 3. When building a server‑side service that receives EMF uploads and must return SVG data for further processing or storage, the memory‑stream approach avoids temporary disk files.
 * 4. When preserving the original appearance of text in an EMF by rendering it as shapes in SVG, the SvgOptions.TextAsShapes setting ensures accurate visual fidelity.
 * 5. When creating a batch conversion tool that processes multiple EMF files and saves the resulting SVGs with embedded raster resources for later reuse, this pattern provides a reliable workflow.
 */
