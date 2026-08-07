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
            // Base64 string of an HTML5 Canvas image (example placeholder)
            string base64 = "iVBORw0KGgoAAAANSUhEUgAAAAUA" +
                            "AAAFCAYAAACNbyblAAAAHElEQVQI12P4" +
                            "//8/w38GIAXDIBKE0DHxgljNBAAO" +
                            "9TXL0Y4OHwAAAABJRU5ErkJggg==";

            // Convert Base64 string to byte array
            byte[] imageBytes = Convert.FromBase64String(base64);

            // Load image from memory stream
            using (var memoryStream = new MemoryStream(imageBytes))
            using (Image image = Image.Load(memoryStream))
            {
                // Output JPEG file path (hard‑coded)
                string outputPath = "output\\canvas.jpg";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image as JPEG using default settings
                image.Save(outputPath);
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
 * 1. When a web application receives a canvas screenshot as a base64 string and needs to store it on the server as a JPEG file for later retrieval or display.
 * 2. When an email service converts user‑drawn canvas images into JPEG attachments before sending them to recipients.
 * 3. When a mobile app uploads a base64‑encoded drawing to a .NET backend that must decode the data and save it as a JPEG for archival purposes.
 * 4. When a reporting tool generates charts on an HTML5 canvas, encodes them to base64, and the server‑side code converts them to JPEG files to embed in PDF reports.
 * 5. When a content management system accepts base64 canvas uploads from editors and automatically creates JPEG thumbnails for gallery previews.
 */