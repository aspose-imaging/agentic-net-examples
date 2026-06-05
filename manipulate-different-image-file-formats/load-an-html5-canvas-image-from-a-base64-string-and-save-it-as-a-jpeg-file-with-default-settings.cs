using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Base64-encoded image data (replace with actual data)
            string base64Image = "iVBORw0KGgoAAAANSUhEUgAAAAUA" +
                                 "AAAFCAYAAACNbyblAAAAHElEQVQI12P4" +
                                 "//8/w38GIAXDIBKE0DHxgljNBAAO" +
                                 "9TXL0Y4OHwAAAABJRU5ErkJggg==";

            // Convert the Base64 string to a byte array
            byte[] imageBytes = Convert.FromBase64String(base64Image);

            // Load the image from the memory stream
            using (var memoryStream = new MemoryStream(imageBytes))
            using (Image image = Image.Load(memoryStream))
            {
                // Output JPEG file path (hard‑coded)
                string outputPath = @"C:\Temp\output.jpg";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a web application receives an HTML5 Canvas image as a Base64 string from a browser and needs to store it as a JPEG file on the server for later retrieval or display.
 * 2. When a desktop utility processes user‑generated Base64‑encoded PNG data and converts it to a standard JPEG format for compatibility with legacy image viewers.
 * 3. When an automated email system embeds a Canvas snapshot as Base64 and must decode and save it as a JPEG attachment before sending.
 * 4. When a cloud service ingests Base64 image payloads from API clients and requires conversion to JPEG files for efficient storage and CDN distribution.
 * 5. When a batch job reads Base64‑encoded images from a database, loads them into Aspose.Imaging, and saves each as a JPEG to generate thumbnails for a gallery.
 */