// HOW-TO: Convert EMF Vector Image to PNG Bitmap with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to display a Windows Metafile (EMF) on a web page that only supports PNG images.
 * 2. When generating thumbnail previews of vector diagrams for reporting tools that require raster formats.
 * 3. When converting printed vector assets into lossless PNG files for inclusion in PDF documents.
 * 4. When automating batch processing of EMF icons to PNG for mobile app resources.
 * 5. When preserving the original dimensions and white background of an EMF while exporting it to a PNG for archival purposes.
 */
