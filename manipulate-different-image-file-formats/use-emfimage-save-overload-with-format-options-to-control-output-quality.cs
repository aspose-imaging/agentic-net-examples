// HOW-TO: Save EMF With Custom Vector Rasterization Options In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/input.emf";
            string outputPath = "output/output.emf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                EmfOptions options = new EmfOptions();

                VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions();
                vectorOptions.BackgroundColor = Color.White;
                vectorOptions.PageWidth = image.Width;
                vectorOptions.PageHeight = image.Height;
                vectorOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                vectorOptions.SmoothingMode = SmoothingMode.None;

                options.VectorRasterizationOptions = vectorOptions;

                image.Save(outputPath, options);
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
 * 1. When you need to re‑save an existing EMF file with a white background and no smoothing to ensure consistent printing results.
 * 2. When you want to render text in an EMF as single‑bit per pixel to reduce file size in a C# reporting tool.
 * 3. When you must preserve the original dimensions of an EMF while applying specific rasterization settings before embedding it in a PDF document.
 * 4. When you are generating EMF graphics programmatically and need to control page width, height, and rendering hints using Aspose.Imaging in .NET.
 * 5. When you need to apply custom vector rasterization options to an EMF to meet corporate branding guidelines for color and smoothing.
 */
