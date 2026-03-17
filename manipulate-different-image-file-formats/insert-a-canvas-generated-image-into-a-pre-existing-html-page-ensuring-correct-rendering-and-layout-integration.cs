using System;
using System.IO;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class CanvasInsertionExample
{
    static void Main()
    {
        // Paths for the source vector image, the existing HTML page, and the output HTML page
        string vectorImagePath = @"Sample.svg";
        string existingHtmlPath = @"page.html";
        string outputHtmlPath = @"page_with_canvas.html";

        // Load the vector image (e.g., SVG) that will be rendered as a Canvas element
        using (Image vectorImage = Image.Load(vectorImagePath))
        {
            // Prepare HTML5 Canvas options:
            // - Export only the <canvas> tag (FullHtmlPage = false)
            // - Assign a unique identifier to the canvas element
            var canvasOptions = new Html5CanvasOptions
            {
                FullHtmlPage = false,
                CanvasTagId = "myCanvas",
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };

            // Save the canvas markup to a memory stream to avoid creating a temporary file
            using (var canvasStream = new MemoryStream())
            {
                vectorImage.Save(canvasStream, canvasOptions);
                // Convert the stream content to a string using the specified encoding (default UTF-8)
                string canvasHtml = Encoding.UTF8.GetString(canvasStream.ToArray());

                // Read the existing HTML page
                string existingHtml = File.ReadAllText(existingHtmlPath, Encoding.UTF8);

                // Determine where to insert the canvas tag.
                // Here we insert it just before the closing </body> tag.
                string insertionMarker = "</body>";
                int insertPos = existingHtml.IndexOf(insertionMarker, StringComparison.OrdinalIgnoreCase);
                string finalHtml;

                if (insertPos >= 0)
                {
                    finalHtml = existingHtml.Insert(insertPos, canvasHtml + Environment.NewLine);
                }
                else
                {
                    // If </body> is not found, append the canvas at the end of the file
                    finalHtml = existingHtml + Environment.NewLine + canvasHtml;
                }

                // Write the combined HTML to the output file
                File.WriteAllText(outputHtmlPath, finalHtml, Encoding.UTF8);
            }
        }

        Console.WriteLine("Canvas image inserted successfully into the HTML page.");
    }
}