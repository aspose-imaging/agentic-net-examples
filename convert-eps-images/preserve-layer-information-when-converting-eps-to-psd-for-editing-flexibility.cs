// HOW-TO: Convert EPS to PSD With Separate Layers Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };

                    psdOptions.VectorizationOptions = new PsdVectorizationOptions
                    {
                        VectorDataCompositionMode = Aspose.Imaging.FileFormats.Psd.VectorDataCompositionMode.SeparateLayers
                    };

                    image.Save(outputPath, psdOptions);
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
 * 1. When a designer needs to edit an EPS artwork in Photoshop, a developer can convert the EPS to a PSD that retains each vector element as its own layer.
 * 2. When an automated workflow must prepare print‑ready files, the code can transform EPS logos into layered PSDs for further color correction.
 * 3. When a web service receives EPS uploads and must provide editable Photoshop files, this snippet creates PSDs with preserved vector layers for downstream editing.
 * 4. When migrating legacy EPS assets to a modern asset‑management system, developers can use the code to keep the original layer structure intact in the resulting PSDs.
 * 5. When building a batch conversion tool that processes many EPS files, the example ensures each file is saved as a PSD with separate layers for maximum editing flexibility.
 */
