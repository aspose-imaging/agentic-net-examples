using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (null‑safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load BMP as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Resize using Bicubic (CubicConvolution) interpolation
                int newWidth = 800;   // example width
                int newHeight = 600;  // example height
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Embed digital signature with a 10‑character password
                image.EmbedDigitalSignature("Password10");

                // Save the result as BMP
                image.Save(outputPath, new BmpOptions());
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
 * 1. When a desktop application must generate a high‑quality thumbnail of a large BMP screenshot for a product catalog, it can resize the image with Bicubic (CubicConvolution) interpolation and embed a 10‑character password‑protected digital signature for security.
 * 2. When an automated archiving system needs to downsize scanned BMP drawings to a standard 800×600 size for faster retrieval while adding a tamper‑evident digital signature, this C# code provides the solution.
 * 3. When a medical imaging workflow requires converting large BMP radiology images to a smaller resolution for web viewing and must guarantee image integrity with a password‑secured digital signature, developers can use this snippet.
 * 4. When a game developer wants to preprocess BMP texture assets to a uniform resolution using bicubic interpolation and lock the assets with a short password‑protected digital signature before packaging, the example code fulfills that need.
 * 5. When a compliance‑focused financial reporting tool must resize BMP charts to fit a fixed‑size PDF page and embed a 10‑character password digital signature to meet audit‑trail requirements, this routine can be integrated.
 */