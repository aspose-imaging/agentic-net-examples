using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing JPEG files
            string inputDirectory = @"C:\Images\Input";
            // Hardcoded output directory for canvas snippets and final HTML page
            string outputDirectory = @"C:\Images\Output";
            // Hardcoded path for the final combined HTML page
            string finalHtmlPath = Path.Combine(outputDirectory, "AllCanvases.html");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFilesAlt = Directory.GetFiles(inputDirectory, "*.jpeg");
            string[] allJpegFiles = new string[jpegFiles.Length + jpegFilesAlt.Length];
            jpegFiles.CopyTo(allJpegFiles, 0);
            jpegFilesAlt.CopyTo(allJpegFiles, jpegFiles.Length);

            // StringBuilder to accumulate canvas HTML snippets
            StringBuilder canvasBuilder = new StringBuilder();

            foreach (string jpegPath in allJpegFiles)
            {
                // Verify input file exists
                if (!File.Exists(jpegPath))
                {
                    Console.Error.WriteLine($"File not found: {jpegPath}");
                    return;
                }

                // Load the JPEG image
                using (Image image = Image.Load(jpegPath))
                {
                    // Prepare canvas output path (individual snippet)
                    string canvasFileName = Path.GetFileNameWithoutExtension(jpegPath) + "_canvas.html";
                    string canvasPath = Path.Combine(outputDirectory, canvasFileName);

                    // Ensure directory for canvas file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

                    // Save as HTML5 Canvas snippet (only the <canvas> tag)
                    var canvasOptions = new Html5CanvasOptions
                    {
                        FullHtmlPage = false,
                        VectorRasterizationOptions = new SvgRasterizationOptions()
                    };
                    image.Save(canvasPath, canvasOptions);
                    
                    // Read the generated canvas snippet and append to the builder
                    string canvasHtml = File.ReadAllText(canvasPath);
                    canvasBuilder.AppendLine(canvasHtml);
                }
            }

            // Build the final HTML page containing all canvases
            string finalHtmlContent = $"<html><head><meta charset=\"utf-8\"><title>All Canvases</title></head><body>{canvasBuilder}</body></html>";

            // Ensure directory for final HTML exists (already created)
            Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

            // Write the combined HTML page
            File.WriteAllText(finalHtmlPath, finalHtmlContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a folder of JPEG photos into HTML5 Canvas snippets and combine them into a single web page for quick visual review without loading external image files.
 * 2. When an e‑commerce platform wants to generate lightweight, script‑based product previews by batch processing JPEG product images into canvas elements embedded in one HTML catalog page.
 * 3. When a digital archivist must create an offline HTML gallery that renders scanned JPEG documents on canvas to preserve layout while avoiding browser image caching issues.
 * 4. When a marketing team requires an automated C# tool that transforms multiple JPEG assets into canvas code for embedding in email newsletters that only support HTML5 Canvas.
 * 5. When a learning management system needs to batch convert lecture slide JPEGs into canvas elements and assemble them into a single HTML lesson page for seamless in‑browser playback.
 */