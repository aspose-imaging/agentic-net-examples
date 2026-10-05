// HOW-TO: Convert Single‑Page CDR To Layered PSD In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.cdr";
        string outputPath = "Output\\sample.psd";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PsdOptions options = new PsdOptions())
                {
                    options.VectorizationOptions = new PsdVectorizationOptions
                    {
                        VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                    };
                    image.Save(outputPath, options);
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
 * 1. When a designer provides a CorelDRAW (CDR) illustration and the development team must generate a Photoshop (PSD) file with each vector element on its own layer for further editing.
 * 2. When an automated build pipeline needs to batch‑convert single‑page CDR assets into layered PSDs to integrate them into a web‑based image editor.
 * 3. When a C# application must programmatically export a CDR logo to PSD while preserving editability of individual shapes for branding workflows.
 * 4. When a migration script has to transform legacy CDR graphics into Photoshop files without flattening, enabling designers to continue work in Photoshop.
 * 5. When a server‑side service receives CDR uploads and must return PSD files with separate layers for downstream compositing or printing pipelines.
 */
