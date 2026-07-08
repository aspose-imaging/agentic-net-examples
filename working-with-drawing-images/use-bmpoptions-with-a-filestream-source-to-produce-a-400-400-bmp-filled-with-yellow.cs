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
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a FileStream for the output file
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Configure BmpOptions with the stream source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new StreamSource(stream);

                // Create a 400x400 BMP image bound to the stream
                using (Image image = Image.Create(bmpOptions, 400, 400))
                {
                    // Fill the entire image with yellow
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.Yellow);

                    // Save the bound image to the stream
                    image.Save();
                }
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
 * 1. A developer can use this code to generate a 400 × 400 yellow BMP file as a placeholder image for UI mockups when the final graphics are not yet available.
 * 2. This snippet is useful for creating a solid‑color test image in BMP format to validate image‑processing pipelines that rely on Aspose.Imaging and C# FileStream handling.
 * 3. When a legacy system requires a simple BMP icon, a developer can produce a 400 × 400 yellow bitmap programmatically instead of manually designing the file.
 * 4. The code can be employed to generate a uniform yellow background BMP for batch printing jobs that need a known canvas size and color.
 * 5. In automated documentation generation, a developer may create a yellow BMP thumbnail on the fly to illustrate image‑format support without storing static assets.
 */