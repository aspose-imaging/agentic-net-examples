// HOW-TO: Convert ODG to SVG with Embedded CSS Styling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class MySvgCallback : SvgResourceKeeperCallback
{
    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Convert SVG bytes to string
        string svgContent = System.Text.Encoding.UTF8.GetString(htmlData);

        // Simple CSS to enforce consistent appearance
        string css = "<style type=\"text/css\">svg {font-family:Arial;}</style>";

        // Insert CSS right after the opening <svg> tag
        int insertPos = svgContent.IndexOf('>');
        if (insertPos != -1)
        {
            svgContent = svgContent.Insert(insertPos + 1, css);
        }

        // Write the modified SVG to the suggested file name
        File.WriteAllText(suggestedFileName, svgContent);
        return suggestedFileName;
    }
}

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Input\sample.odg";
        string outputPath = @"C:\Output\sample.svg";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for ODG
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Set up SVG export options with CSS embedding callback
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    Callback = new MySvgCallback()
                };

                // Save as SVG
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
 * 1. When a developer needs to transform LibreOffice Draw (.odg) diagrams into web‑ready SVG files while preserving font consistency across browsers.
 * 2. When an application must generate scalable vector graphics from ODG assets and embed custom CSS to enforce a specific font family without manually editing the SVG.
 * 3. When a reporting tool requires converting multi‑page ODG documents to SVG for inclusion in HTML emails, ensuring the SVG uses a standard font through embedded style tags.
 * 4. When a design workflow automates the export of ODG illustrations to SVG for responsive UI components, and the code must guarantee the same appearance by adding CSS at export time.
 * 5. When a server‑side service processes user‑uploaded ODG files and returns SVG output with inline CSS to avoid external stylesheet dependencies in downstream applications.
 */
