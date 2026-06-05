using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 200x200 BMP image
            using (BmpImage bmpImage = new BmpImage(200, 200))
            {
                // Obtain a Graphics object for drawing
                Graphics graphics = new Graphics(bmpImage);

                // Clear the entire canvas to red
                graphics.Clear(Color.Red);

                // Save the image to the specified file
                bmpImage.Save(outputPath);
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
 * 1. When a developer needs to generate a simple red placeholder BMP image of a fixed size for testing image upload functionality in a .NET application.
 * 2. When a C# program must create a 200 × 200 bitmap to serve as a background layer for dynamically compositing icons in a Windows desktop utility.
 * 3. When an automated build script has to produce a red BMP file to verify that the Aspose.Imaging library correctly writes BMP headers and pixel data on a CI server.
 * 4. When a developer wants to pre‑render a solid‑color thumbnail in BMP format for use in legacy systems that only accept uncompressed bitmap files.
 * 5. When a reporting tool needs to embed a red square BMP as a visual placeholder in generated PDF or Word documents when the original image is missing.
 */