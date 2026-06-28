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
            // Create a memory stream to hold the BMP image.
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Set up BMP options with the memory stream as the destination.
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(memoryStream);

                // Define image dimensions.
                int width = 200;
                int height = 200;

                // Create the image.
                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    // Create a Graphics object for drawing.
                    Graphics graphics = new Graphics(image);

                    // Draw a green rectangle.
                    graphics.DrawRectangle(new Pen(Color.Green, 2), new Rectangle(50, 50, 100, 100));

                    // Save the image to the bound stream.
                    image.Save();
                }

                // Write the memory stream contents to a file.
                string outputPath = @"C:\temp\output.bmp";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
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
 * 1. When generating a thumbnail preview of a document on the fly and needing to store the BMP image in memory before saving it to disk or sending it over a network.
 * 2. When creating a dynamic watermark or annotation (e.g., a green rectangle) on a BMP image in a web service without writing intermediate files to the server’s file system.
 * 3. When implementing an in‑memory image processing pipeline that converts user‑drawn shapes into BMP format for later embedding into PDF reports.
 * 4. When building a desktop application that captures screen regions, draws diagnostic overlays, and writes the result directly to a MemoryStream for quick caching.
 * 5. When developing a unit test that verifies drawing operations on a BMP image by creating the image in a MemoryStream and comparing the byte array to an expected result.
 */