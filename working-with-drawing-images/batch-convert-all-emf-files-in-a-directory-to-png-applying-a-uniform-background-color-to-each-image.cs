// HOW-TO: Batch Convert EMF Files to PNG with White Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (EmfImage emfImage = (EmfImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions();
                    vectorOptions.BackgroundColor = Aspose.Imaging.Color.White;
                    vectorOptions.PageWidth = emfImage.Width;
                    vectorOptions.PageHeight = emfImage.Height;

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.VectorRasterizationOptions = vectorOptions;
                        pngOptions.Source = new FileCreateSource(outputPath, false);
                        emfImage.Save(outputPath, pngOptions);
                    }
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
 * 1. When you need to generate web‑ready PNG thumbnails from a collection of Windows Metafile (EMF) diagrams and ensure a consistent white canvas behind each image.
 * 2. When a reporting system exports charts as EMF and you must convert them to PNG for inclusion in PDF or HTML reports without transparent backgrounds.
 * 3. When migrating legacy design assets stored as EMF to a modern asset pipeline that only accepts PNG files with a solid background.
 * 4. When automating a build process that pulls EMF icons from a source folder and creates PNG versions for mobile applications that require a fixed background color.
 * 5. When preparing a batch of EMF logos for an e‑commerce catalog and you need to standardize their size and background before uploading to the storefront.
 */
