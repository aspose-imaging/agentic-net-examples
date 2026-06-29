using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a memory stream to hold the PNG data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Configure PNG options with a StreamSource bound to the memory stream
                PngOptions pngOptions = new PngOptions
                {
                    Source = new StreamSource(memoryStream)
                };

                // Create a 500x500 PNG image bound to the stream
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Draw on the image
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.LightGray);

                    // Save the image to the bound stream
                    image.Save();
                }

                // Write the PNG data from the memory stream to the output file
                File.WriteAllBytes(outputPath, memoryStream.ToArray());
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
 * 1. When a C# web API must create a 500×500 PNG thumbnail in memory using Aspose.Imaging and stream it directly to the client without creating temporary files on disk.
 * 2. When a desktop application needs to generate a square placeholder image, draw graphics on it, and store the PNG bytes in a database by using a MemoryStream and StreamSource.
 * 3. When an automated report generator has to embed a dynamically drawn PNG chart into an email attachment, building the image in memory before saving it to a file or sending it.
 * 4. When a cloud function processes user‑uploaded data, creates a 500×500 PNG preview with Aspose.Imaging, and returns the byte array from a MemoryStream for further processing.
 * 5. When a unit test validates image‑processing logic by creating a PNG image entirely in memory, drawing on it, and verifying the output without relying on the file system.
 */