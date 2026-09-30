// HOW-TO: Convert EPS to PSD with Separate Layers Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    },
                    VectorizationOptions = new PsdVectorizationOptions
                    {
                        VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                    }
                };

                image.Save(outputPath, psdOptions);
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
 * 1. When you need to edit a vector EPS artwork in Photoshop while keeping each element on its own layer for precise adjustments.
 * 2. When automating a workflow that converts print‑ready EPS files to layered PSDs for a design team that uses C# and Aspose.Imaging.
 * 3. When preserving the original vector data as separate PSD layers is required to apply layer‑specific effects or masks in Photoshop.
 * 4. When generating PSD previews from EPS logos on a server, ensuring each graphic component remains editable in downstream C# applications.
 * 5. When migrating legacy EPS assets to a layered Photoshop format without flattening, allowing developers to programmatically maintain editability in .NET projects.
 */
