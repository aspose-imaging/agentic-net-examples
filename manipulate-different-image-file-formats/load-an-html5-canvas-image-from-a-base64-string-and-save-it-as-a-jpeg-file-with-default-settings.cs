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
            // Base64 string representing an HTML5 Canvas image.
            // Replace the placeholder with an actual base64-encoded image.
            string base64String = "iVBORw0KGgoAAAANSUhEUgAAAAUA...";

            // If the string contains a data URI prefix, remove it.
            if (base64String.Contains(","))
            {
                base64String = base64String.Split(',')[1];
            }

            // Decode the base64 string to a byte array.
            byte[] imageBytes = Convert.FromBase64String(base64String);

            // Load the image from the memory stream.
            using (var memoryStream = new MemoryStream(imageBytes))
            using (Image image = Image.Load(memoryStream))
            {
                // Hard‑coded output path (includes a directory to satisfy the safety rule).
                string outputPath = "output/output.jpg";

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image as JPEG using default options.
                image.Save(outputPath, new JpegOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}