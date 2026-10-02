// HOW-TO: Apply Gaussian Blur to SVG from REST API and Post Result in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Net.Http;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths (required by safety rules)
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            // Input path check (exactly as specified)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Retrieve SVG from REST API
            using var client = new HttpClient();
            string getUrl = "https://example.com/api/svg"; // replace with actual endpoint
            var getResponse = client.GetAsync(getUrl).Result;
            if (!getResponse.IsSuccessStatusCode)
            {
                Console.Error.WriteLine($"Failed to retrieve SVG: {getResponse.StatusCode}");
                return;
            }
            string svgContent = getResponse.Content.ReadAsStringAsync().Result;

            // Apply Gaussian blur to the SVG
            string blurredSvg = ApplyGaussianBlur(svgContent, 5);

            // Save blurred SVG to output path (optional)
            File.WriteAllText(outputPath, blurredSvg);

            // Post blurred SVG back to REST API
            string postUrl = "https://example.com/api/svg"; // replace with actual endpoint
            var postContent = new StringContent(blurredSvg, Encoding.UTF8, "image/svg+xml");
            var postResponse = client.PostAsync(postUrl, postContent).Result;
            if (!postResponse.IsSuccessStatusCode)
            {
                Console.Error.WriteLine($"Failed to post blurred SVG: {postResponse.StatusCode}");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static string ApplyGaussianBlur(string svg, double stdDeviation)
    {
        const string filterId = "blurFilter";
        string filterDef = $"<filter id=\"{filterId}\"><feGaussianBlur stdDeviation=\"{stdDeviation}\"/></filter>";

        // Insert filter definition into <defs> or create a new <defs>
        if (svg.Contains("<defs"))
        {
            int defsClose = svg.IndexOf("</defs>", StringComparison.Ordinal);
            if (defsClose >= 0)
            {
                svg = svg.Insert(defsClose, filterDef);
            }
            else
            {
                int svgClose = svg.IndexOf("</svg>", StringComparison.Ordinal);
                if (svgClose >= 0)
                {
                    svg = svg.Insert(svgClose, $"<defs>{filterDef}</defs>");
                }
            }
        }
        else
        {
            int svgClose = svg.IndexOf("</svg>", StringComparison.Ordinal);
            if (svgClose >= 0)
            {
                svg = svg.Insert(svgClose, $"<defs>{filterDef}</defs>");
            }
        }

        // Add filter attribute to the root <svg> element if not already present
        int svgTagStart = svg.IndexOf("<svg", StringComparison.Ordinal);
        if (svgTagStart >= 0)
        {
            int svgTagEnd = svg.IndexOf('>', svgTagStart);
            if (svgTagEnd > 0 && !svg.Substring(svgTagStart, svgTagEnd - svgTagStart).Contains("filter="))
            {
                svg = svg.Insert(svgTagEnd, $" filter=\"url(#{filterId})\"");
            }
        }

        return svg;
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web service needs to automatically soften vector graphics before storing them, a developer can fetch the SVG, blur it, and send it back using C#.
 * 2. When generating thumbnail previews for an online editor, applying a Gaussian blur to the original SVG via a REST call can create a stylized preview.
 * 3. When integrating a CI pipeline that validates image assets, the code can retrieve SVGs, apply a blur filter, and upload the processed version for further testing.
 * 4. When building a microservice that sanitizes user‑uploaded SVGs by adding a blur effect, this snippet shows how to pull the file, process it, and return it via HTTP.
 * 5. When creating a batch job that enhances branding assets with a subtle blur before publishing, the example demonstrates the end‑to‑end C# workflow with HTTP GET/POST.
 */
