using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PDF path
            string inputPath = "input.pdf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for SVG files
            string outputDir = "output";

            // Load the PDF document
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(outputDir);

                // Determine page count (PDF may be multipage)
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                // Export each page as a separate SVG file
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.svg");
                    // Ensure directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure SVG export options
                    SvgOptions exportOptions = new SvgOptions();

                    // Set vector rasterization options for vector sources
                    if (image is VectorImage)
                    {
                        exportOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                    }

                    // Export only the current page
                    exportOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                    // Save the page as SVG
                    image.Save(outputPath, exportOptions);
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
 * 1. When a GIS analyst needs to extract individual map pages from a multi‑page PDF and embed them as scalable SVG graphics in a web‑based mapping portal.
 * 2. When a mobile app developer wants to reduce the file size of vector map assets by converting each PDF page to an SVG that can be rendered on‑the‑fly in a Xamarin.Forms UI.
 * 3. When a data‑visualization engineer must preserve geographic metadata while converting engineering drawings stored in PDF to SVG for interactive D3.js charts.
 * 4. When a publishing workflow requires batch conversion of cartographic PDFs into separate SVG files so that each page can be edited independently in Adobe Illustrator or Inkscape.
 * 5. When an automated reporting system needs to programmatically generate SVG map tiles from a PDF source for inclusion in PDF‑to‑HTML conversion pipelines.
 */