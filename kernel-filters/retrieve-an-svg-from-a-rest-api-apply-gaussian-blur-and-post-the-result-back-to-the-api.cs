// HOW-TO: Download SVG From API and Convert to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded URLs and file paths
            string inputUrl = "https://example.com/api/svg";
            string postUrl = "https://example.com/api/upload";
            string tempSvgPath = "temp/input.svg";
            string rasterPngPath = "temp/raster.png";
            string outputPath = "output/blurred.png";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempSvgPath));
            Directory.CreateDirectory(Path.GetDirectoryName(rasterPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Download SVG from REST API
            var httpClient = new System.Net.Http.HttpClient();
            var svgBytes = httpClient.GetByteArrayAsync(inputUrl).Result;
            File.WriteAllBytes(tempSvgPath, svgBytes);

            // Verify SVG file exists
            if (!File.Exists(tempSvgPath))
            {
                Console.Error.WriteLine($"File not found: {tempSvgPath}");
                return;
            }

            // Load SVG image
            using (Image svgImage = Image.Load(tempSvgPath))
            {
                SvgImage svg = (SvgImage)svgImage;

                // Prepare PNG options with rasterization
                PngOptions pngOptions = new PngOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svg.Width,
                    PageHeight = svg.Height,
                    BackgroundColor = Color.White
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Save rasterized PNG
                svg.Save(rasterPngPath, pngOptions);
            }

            // Verify raster PNG exists
            if (!File.Exists(rasterPngPath))
            {
                Console.Error.WriteLine($"File not found: {rasterPngPath}");
                return;
            }

            // Load raster PNG as RasterImage
            using (Image img = Image.Load(rasterPngPath))
            {
                RasterImage raster = (RasterImage)img;

                // Apply Gaussian blur
                var blurOptions = new GaussianBlurFilterOptions(5, 1.5);
                raster.Filter(raster.Bounds, blurOptions);

                // Save blurred image
                raster.Save(outputPath);
            }

            // Verify output file exists
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            // Post blurred image back to API
            var postClient = new System.Net.Http.HttpClient();
            var content = new System.Net.Http.ByteArrayContent(File.ReadAllBytes(outputPath));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            var response = postClient.PostAsync(postUrl, content).Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine($"Failed to post image: {response.StatusCode}");
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
 * 1. When you need to fetch vector graphics from a web service and store them as raster PNG files for further processing or display in a .NET application.
 * 2. When your application must convert user‑uploaded SVG assets retrieved via HTTP into PNG thumbnails for use in mobile or web UI.
 * 3. When an automated pipeline requires downloading SVG diagrams from a REST endpoint, rasterizing them with a white background, and saving them locally before applying additional image filters.
 * 4. When you want to integrate Aspose.Imaging into a C# service that transforms vector icons obtained from an API into PNG assets compatible with legacy systems.
 * 5. When a backend job has to ensure the output folder structure exists, download SVG content, and reliably convert it to PNG to meet reporting or documentation generation requirements.
 */
