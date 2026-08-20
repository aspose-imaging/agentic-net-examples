// HOW-TO: Convert Base64 HTML5 Canvas Image To JPEG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Base64 string representing the HTML5 Canvas image (replace with actual data)
            string base64 = "YOUR_BASE64_STRING";

            // Remove possible data URI prefix
            string base64Data = base64.Contains(",") ? base64.Split(',')[1] : base64;

            // Decode Base64 to byte array
            byte[] imageBytes = Convert.FromBase64String(base64Data);

            // Load image from memory stream
            using (var memoryStream = new MemoryStream(imageBytes))
            using (Image image = Image.Load(memoryStream))
            {
                // Output JPEG file path (hard‑coded)
                string outputPath = "output.jpg";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Save the image as JPEG with default settings
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
 * 1. When a web application receives a canvas screenshot as a Base64 string and needs to store it as a JPEG file on the server using C#.
 * 2. When you want to programmatically convert user‑drawn HTML5 canvas data into a standard image format for email attachments or reports.
 * 3. When an API endpoint must decode a Base64‑encoded canvas image and persist it in a file system without manual image editing.
 * 4. When you need to batch‑process multiple Base64 canvas strings and generate JPEG thumbnails for a gallery using Aspose.Imaging.
 * 5. When a mobile backend receives canvas data from a hybrid app and must save it as JPEG with default compression for later retrieval.
 */
