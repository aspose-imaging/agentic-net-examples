using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = new[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };

        // Hardcoded output PNG file
        string outputPath = "output.png";

        // Validate input files
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary folder for intermediate EMF files
        string tempFolder = "temp_emf";
        Directory.CreateDirectory(tempFolder);

        var sizes = new List<Aspose.Imaging.Size>();
        var rasters = new List<RasterImage>();
        var tempEmfPaths = new List<string>();

        // Convert each JPG to EMF and load as raster
        foreach (string inputPath in inputPaths)
        {
            using (Image img = Image.Load(inputPath))
            {
                sizes.Add(img.Size);

                string emfPath = Path.Combine(tempFolder, Path.GetFileNameWithoutExtension(inputPath) + ".emf");
                tempEmfPaths.Add(emfPath);

                // Ensure EMF directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(emfPath));

                // Prepare EMF options with rasterization settings
                EmfOptions emfOptions = new EmfOptions();
                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = img.Size
                };
                emfOptions.VectorRasterizationOptions = vectorOptions;

                // Save JPG as EMF
                img.Save(emfPath, emfOptions);
            }

            // Load the generated EMF as a raster image
            RasterImage raster = (RasterImage)Image.Load(tempEmfPaths.Last());
            rasters.Add(raster);
        }

        // Calculate canvas size for horizontal stitching
        int newWidth = sizes.Sum(s => s.Width);
        int newHeight = sizes.Max(s => s.Height);

        // Create PNG canvas bound to output file
        Source outSource = new FileCreateSource(outputPath, false);
        PngOptions pngOptions = new PngOptions { Source = outSource };

        using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
        {
            int offsetX = 0;
            foreach (RasterImage raster in rasters)
            {
                Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, raster.Width, raster.Height);
                canvas.SaveArgb32Pixels(bounds, raster.LoadArgb32Pixels(raster.Bounds));
                offsetX += raster.Width;
                raster.Dispose();
            }

            // Save the bound PNG image
            canvas.Save();
        }

        // Cleanup temporary EMF files
        foreach (string emfPath in tempEmfPaths)
        {
            try { File.Delete(emfPath); } catch { }
        }
    }
}