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
        string inputPath = @"C:\Input\sample.otg";
        string outputPath = @"C:\Output\sample.svg";

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
            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set up SVG save options with a callback to embed CSS
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = otgRasterOptions,
                    Callback = new CssEmbeddingCallback()
                };

                // Save as SVG; the callback will handle writing the final file
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Callback that injects CSS into the generated SVG before it is written to disk
class CssEmbeddingCallback : SvgResourceKeeperCallback
{
    // Define the CSS you want to embed
    private const string CssContent = @"
        <![CDATA[
            svg { font-family: Arial, Helvetica, sans-serif; }
            .myClass { fill: #ff0000; stroke: #000000; stroke-width: 1; }
        ]]>
    ";

    public override string OnSvgDocumentReady(byte[] htmlData, string suggestedFileName)
    {
        // Convert SVG bytes to string
        string svg = Encoding.UTF8.GetString(htmlData);

        // Find the position after the opening <svg> tag
        int insertPos = svg.IndexOf('>');
        if (insertPos != -1)
        {
            // Insert a <style> element with the CSS
            string styleElement = $"<style type=\"text/css\">{CssContent}</style>";
            svg = svg.Insert(insertPos + 1, styleElement);
        }

        // Determine final output path (use the suggested file name if provided)
        string outputPath = string.IsNullOrEmpty(suggestedFileName) ? "output.svg" : suggestedFileName;

        // Ensure the directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Write the modified SVG to disk
        File.WriteAllText(outputPath, svg, Encoding.UTF8);

        // Return the path to the saved SVG document
        return outputPath;
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application must display legacy OTG diagrams as scalable SVG graphics with consistent fonts and colors, this code converts the OTG file to SVG and embeds CSS styles for uniform rendering.
 * 2. When an automated reporting tool needs to generate printable SVG charts from OTG assets while preserving brand‑specific styling, the example loads the OTG image, rasterizes it, and injects a CSS stylesheet into the SVG output.
 * 3. When a desktop utility processes batches of OTG files to create responsive vector images for mobile devices, the code ensures each SVG includes embedded CSS so the visuals look identical across browsers.
 * 4. When a document conversion service transforms engineering OTG schematics into web‑ready SVG files and must apply custom fill and stroke rules, this snippet loads the source, applies rasterization options, and adds the required CSS via a callback.
 * 5. When a C#‑based content management system imports OTG artwork and needs to store it as SVG with predefined styling for later editing, the provided code performs the conversion and embeds the CSS directly into the generated SVG file.
 */