// HOW-TO: Batch Convert JPEG Images to HTML5 Canvas and Create Index Page in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";
        string finalHtmlPath = Path.Combine(outputDirectory, "index.html");

        try
        {
            // Ensure the output directory exists for individual canvas files and the final HTML page
            Directory.CreateDirectory(outputDirectory);

            // Collect all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            // Store paths of generated canvas fragments
            var canvasFragments = new System.Collections.Generic.List<string>();

            foreach (string jpegPath in jpegFiles)
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
                    // Determine canvas output file path
                    string canvasFileName = Path.GetFileNameWithoutExtension(jpegPath) + ".html";
                    string canvasPath = Path.Combine(outputDirectory, canvasFileName);

                    // Ensure directory exists (already created above, but call as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(canvasPath));

                    // Save only the canvas tag (no full HTML page)
                    var canvasOptions = new Html5CanvasOptions
                    {
                        FullHtmlPage = false
                    };
                    image.Save(canvasPath, canvasOptions);

                    // Store the fragment for later aggregation
                    canvasFragments.Add(canvasPath);
                }
            }

            // Build the final HTML page that includes all canvas fragments
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"utf-8\"/>");
            sb.AppendLine("<title>Canvas Gallery</title>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");

            foreach (string fragmentPath in canvasFragments)
            {
                // Read the canvas tag content
                string canvasTag = File.ReadAllText(fragmentPath);
                sb.AppendLine(canvasTag);
            }

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            // Ensure the directory for the final HTML exists
            Directory.CreateDirectory(Path.GetDirectoryName(finalHtmlPath));

            // Write the combined HTML page
            File.WriteAllText(finalHtmlPath, sb.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display a gallery of JPEG photos on a web page using canvas elements without loading full image files.
 * 2. When you want to pre‑process a large set of JPEGs into lightweight HTML5 canvas snippets for faster client‑side rendering.
 * 3. When you are building an offline HTML report that embeds images as canvas tags to avoid external image references.
 * 4. When you need to automate the creation of a single index.html that aggregates multiple canvas fragments for a slideshow or portfolio.
 * 5. When you are migrating legacy JPEG assets to a modern HTML5 canvas format to improve compatibility with responsive web designs.
 */
