using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\HighResPhoto.jpg";
            string outputPath = @"C:\Images\CanvasOutput.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the high‑resolution image
            using (Image image = Image.Load(inputPath))
            {
                // Desired viewport size
                const int maxWidth = 1920;
                const int maxHeight = 1080;

                // Calculate scaling factor while preserving aspect ratio
                double widthScale = (double)maxWidth / image.Width;
                double heightScale = (double)maxHeight / image.Height;
                double scale = Math.Min(1.0, Math.Min(widthScale, heightScale));

                // Determine new dimensions
                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                // Resize only if scaling down is needed
                if (scale < 1.0)
                {
                    image.Resize(newWidth, newHeight);
                }

                // Prepare HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    FullHtmlPage = true // generate a full HTML page
                };

                // Save the image as an HTML5 Canvas file
                image.Save(outputPath, canvasOptions);
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
 * 1. When a web developer wants to embed a high‑resolution photograph in a responsive web page without slowing down the browser, they can downscale it to 1920×1080 and export it as an HTML5 Canvas file using C# and Aspose.Imaging.
 * 2. When an e‑learning platform needs to display large classroom photos on student devices, the code can resize the image to fit a 1080p viewport and generate a canvas‑based HTML page for fast loading.
 * 3. When a digital signage system must convert high‑resolution product images into lightweight HTML5 Canvas assets that fit a 1920×1080 screen, this snippet automates the resizing and export process.
 * 4. When a photo‑sharing app wants to provide a preview version of a user’s ultra‑high‑resolution picture that works in any browser, the developer can use this code to create a downscaled canvas HTML file.
 * 5. When a content management system needs to generate HTML5 Canvas thumbnails for archival photos that preserve aspect ratio and fit a standard HD viewport, the example shows how to achieve it with Aspose.Imaging in C#.
 */