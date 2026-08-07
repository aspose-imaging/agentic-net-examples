using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\input.pdf";
        string outputPath = @"C:\Data\output.svg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PDF (vector multipage image)
            using (Image image = Image.Load(inputPath))
            {
                var multipage = image as IMultipageImage;
                if (multipage == null || multipage.Pages == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("The loaded document does not contain any pages.");
                    return;
                }

                // Determine total canvas size (max width, sum of heights)
                int totalWidth = 0;
                int totalHeight = 0;
                foreach (var page in multipage.Pages)
                {
                    totalWidth = Math.Max(totalWidth, page.Width);
                    totalHeight += page.Height;
                }

                var sb = new StringBuilder();
                sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{totalWidth}\" height=\"{totalHeight}\">");

                int currentY = 0;
                foreach (var page in multipage.Pages)
                {
                    // Export each page to an intermediate SVG stored in memory
                    using (var ms = new MemoryStream())
                    {
                        var svgOptions = new SvgOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageSize = page.Size
                            }
                        };
                        page.Save(ms, svgOptions);
                        string pageSvg = Encoding.UTF8.GetString(ms.ToArray());

                        // Extract inner SVG content (exclude outer <svg> tags)
                        int start = pageSvg.IndexOf('>') + 1;
                        int end = pageSvg.LastIndexOf("</svg>", StringComparison.Ordinal);
                        string innerContent = (start < end) ? pageSvg.Substring(start, end - start) : string.Empty;

                        // Place the page content at the correct vertical offset
                        sb.AppendLine($"  <g transform=\"translate(0,{currentY})\">");
                        sb.AppendLine(innerContent);
                        sb.AppendLine("  </g>");
                    }

                    currentY += page.Height;
                }

                sb.AppendLine("</svg>");

                // Write the combined SVG to the output file
                File.WriteAllText(outputPath, sb.ToString());
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
 * 1. When a developer needs to embed a multi‑page vector PDF brochure into a web page as a single scalable SVG canvas for responsive design.
 * 2. When an automated reporting tool must combine several PDF chart pages into one SVG file for high‑resolution printing without rasterization.
 * 3. When a document conversion service wants to transform a multi‑page PDF invoice into a single SVG document to preserve vector quality for downstream editing.
 * 4. When a GIS application requires merging multiple PDF map sheets into one SVG layer to enable pan‑and‑zoom interactions in a C# desktop client.
 * 5. When a digital asset pipeline needs to batch‑process engineering drawings stored as multi‑page PDFs and output a consolidated SVG for inclusion in technical documentation.
 */