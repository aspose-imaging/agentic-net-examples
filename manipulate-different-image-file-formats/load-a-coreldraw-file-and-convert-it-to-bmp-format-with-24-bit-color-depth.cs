using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP options with 24‑bit color depth
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    // Set up vector rasterization to render the vector image to raster
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
                };

                // Save the rasterized image as BMP
                image.Save(outputPath, bmpOptions);
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
 * 1. When a desktop publishing workflow requires converting legacy CorelDRAW (CDR) vector artwork into a 24‑bit BMP file for inclusion in a Windows‑based print catalog, a developer can use this code to rasterize and save the image.
 * 2. When an automated document processing system needs to generate high‑resolution bitmap thumbnails of CDR designs for preview in a web portal, the code provides a C# solution that loads the CDR file and outputs a 24‑bit BMP.
 * 3. When a legacy engineering application only accepts BMP images with 24‑bit color depth, developers can employ this snippet to import CorelDRAW schematics and convert them to the required format.
 * 4. When a batch conversion utility must ensure consistent background color and page dimensions while transforming multiple CDR files to BMP for archival storage, the code demonstrates how to configure VectorRasterizationOptions in Aspose.Imaging.
 * 5. When a game development pipeline needs to import vector assets created in CorelDRAW and rasterize them to 24‑bit BMP textures for use in DirectX rendering, this C# example shows the necessary steps.
 */