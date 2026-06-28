using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to report errors without crashing
        try
        {
            // Hard‑coded input PDF path
            string inputPath = @"C:\Data\Maps\input.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hard‑coded output directory for the SVG pages
            string outputDir = @"C:\Data\Maps\output_svg";

            // Ensure the output directory exists (unconditional call as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

            // Load the PDF document (Aspose.Imaging can handle PDF as a multipage vector image)
            using (Image pdfImage = Image.Load(inputPath))
            {
                // Cast to IMultipageImage to work with individual pages
                IMultipageImage multipage = pdfImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("The loaded document does not contain any pages.");
                    return;
                }

                // Prepare common SVG save options (metadata preservation, text as shapes, etc.)
                SvgOptions svgOptions = new SvgOptions
                {
                    KeepMetadata = true,          // Preserve geographic metadata
                    TextAsShapes = true          // Render text as vector shapes
                };

                // Configure vector rasterization options (page size based on the source image)
                // For PDF each page shares the same size, so we can reuse the size of the first page
                svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = pdfImage.Size,
                    BackgroundColor = Color.Transparent
                };

                // Iterate over each page and save it as an individual SVG file
                for (int pageIndex = 0; pageIndex < multipage.PageCount; pageIndex++)
                {
                    // Define the range that selects only the current page
                    svgOptions.MultiPageOptions = new MultiPageOptions(new IntRange(pageIndex, pageIndex + 1));

                    // Build the output file name (e.g., page_1.svg, page_2.svg, ...)
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex + 1}.svg");

                    // Ensure the directory for the output file exists (unconditional as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the selected page as SVG
                    pdfImage.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime exception
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a GIS analyst needs to extract each page of a multi‑page PDF map into separate SVG files for web‑based interactive mapping while keeping the coordinate metadata intact.
 * 2. When a mobile‑app developer wants to convert vector map PDFs into lightweight SVG assets that can be rendered on different screen sizes without losing geographic reference data.
 * 3. When a publishing workflow requires batch conversion of cartographic PDFs into per‑page SVGs so that designers can edit individual map layers in vector graphics editors while preserving the original metadata.
 * 4. When an e‑learning platform must transform PDF map resources into scalable SVG diagrams for responsive HTML5 lessons, ensuring that the embedded geospatial metadata remains available for downstream processing.
 * 5. When a data‑visualization engineer needs to programmatically split a multi‑page PDF atlas into SVG pages to feed a custom map‑tiling service that relies on preserved geographic metadata for accurate tile alignment.
 */