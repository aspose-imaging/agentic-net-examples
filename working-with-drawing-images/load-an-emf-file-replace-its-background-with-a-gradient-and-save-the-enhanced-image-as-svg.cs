using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf.Emf.Records;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.emf";
            string outputPath = @"C:\temp\output.svg";

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
                // Prepare SVG save options with transparent background (will be replaced by gradient later)
                SvgOptions svgOptions = new SvgOptions
                {
                    TextAsShapes = true
                };

                EmfRasterizationOptions rasterOptions = new EmfRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageSize = emfImage.Size,
                    RenderMode = Aspose.Imaging.FileFormats.Emf.EmfRenderMode.Auto
                };

                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                emfImage.Save(outputPath, svgOptions);
            }

            // Load the generated SVG and inject a linear gradient background
            XDocument svgDoc = XDocument.Load(outputPath);
            XNamespace ns = "http://www.w3.org/2000/svg";

            // Define a linear gradient (top-left to bottom-right)
            XElement defs = new XElement(ns + "defs",
                new XElement(ns + "linearGradient",
                    new XAttribute("id", "bgGrad"),
                    new XAttribute("x1", "0%"),
                    new XAttribute("y1", "0%"),
                    new XAttribute("x2", "100%"),
                    new XAttribute("y2", "100%"),
                    new XElement(ns + "stop",
                        new XAttribute("offset", "0%"),
                        new XAttribute("stop-color", "#FF5733")), // start color
                    new XElement(ns + "stop",
                        new XAttribute("offset", "100%"),
                        new XAttribute("stop-color", "#33C1FF"))  // end color
                )
            );

            // Insert <defs> as the first child of <svg>
            XElement svgRoot = svgDoc.Root;
            svgRoot.AddFirst(defs);

            // Insert a rectangle that covers the whole canvas and uses the gradient
            XElement rect = new XElement(ns + "rect",
                new XAttribute("width", "100%"),
                new XAttribute("height", "100%"),
                new XAttribute("fill", "url(#bgGrad)")
            );

            // Insert the rectangle just after <defs> so it sits behind other content
            defs.AddAfterSelf(rect);

            // Save the modified SVG
            svgDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy Windows Metafile (EMF) graphics into scalable SVG files for web display while applying a custom gradient background.
 * 2. When an application must replace the solid background of an EMF diagram with a smooth linear gradient before exporting it to SVG for inclusion in responsive UI designs.
 * 3. When a reporting tool requires automated transformation of EMF charts into SVG format with transparent backgrounds that are later enhanced with gradient fills for visual consistency.
 * 4. When a batch processing script has to read EMF assets, rasterize them with Aspose.Imaging, inject a gradient definition into the SVG markup, and save the result for print‑ready publishing.
 * 5. When a cross‑platform C# service needs to load an EMF logo, apply a brand‑color gradient background, and deliver the final SVG to client browsers without manual editing.
 */