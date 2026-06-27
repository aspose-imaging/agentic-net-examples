using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

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
 * 1. When a developer needs to convert Windows Metafile (EMF) vector logos into 300‑dpi BMP files for high‑quality print catalogs.
 * 2. When an application must generate rasterized BMP thumbnails of EMF diagrams for legacy systems that only support bitmap images.
 * 3. When a reporting tool has to embed EMF charts into PDF documents that require embedded BMP images at printer‑ready resolution.
 * 4. When a batch‑processing service automates the migration of EMF icons to 300‑dpi BMP assets for use in a Windows desktop application with fixed‑size bitmap resources.
 * 5. When a document management system needs to preview EMF drawings as high‑resolution BMP previews on a web portal that cannot render vector formats.
 */