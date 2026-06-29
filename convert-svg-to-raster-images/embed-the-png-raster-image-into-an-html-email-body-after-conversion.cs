using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputHtmlPath = "output.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as an HTML5 Canvas page
                var options = new Html5CanvasOptions
                {
                    FullHtmlPage = true,
                    // For raster images, VectorRasterizationOptions can be left null
                };
                image.Save(outputHtmlPath, options);
            }

            // Read the generated HTML content
            string canvasHtml = File.ReadAllText(outputHtmlPath);

            // Build the final email body embedding the canvas HTML
            string emailBody = $"<html><body>{canvasHtml}</body></html>";

            // Output the email body to console (or write to a file as needed)
            Console.WriteLine(emailBody);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# developer needs to convert a PNG raster image into an HTML5 canvas snippet and embed it directly into an HTML email body for consistent rendering across email clients.
 * 2. When an automated reporting system must include dynamically generated PNG charts inside HTML email notifications without attaching separate image files.
 * 3. When a marketing application uses Aspose.Imaging to transform product PNG visuals into inline HTML canvas code for responsive email newsletters.
 * 4. When a corporate workflow requires embedding PNG logos into transactional email templates by converting them to HTML5 canvas using C# and saving the result as a single HTML string.
 * 5. When a developer builds a bulk‑email sender that programmatically loads PNG assets, converts them with Aspose.Imaging’s Html5CanvasOptions, and inserts the canvas HTML into the email’s body to avoid external image references.
 */