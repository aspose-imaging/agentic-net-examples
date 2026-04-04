using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\input\vector.cdr";
        string tempPngPath = @"C:\temp\temp.png";
        string outputPath = @"C:\output\embossed.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Rasterize vector image to high‑resolution PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            int targetWidth = vectorImage.Width * 2;
            int targetHeight = vectorImage.Height * 2;

            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = targetWidth,
                PageHeight = targetHeight
            };

            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(tempPngPath, false),
                VectorRasterizationOptions = rasterOptions
            };

            vectorImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply emboss filter, and save as TIFF
        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
        {
            // Custom emboss kernel
            double[,] embossKernel = new double[,]
            {
                { -2, -1, 0 },
                { -1,  1, 1 },
                {  0,  1, 2 }
            };

            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
            raster.Filter(raster.Bounds, filterOptions);

            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Compression = TiffCompressions.Lzw,
                Photometric = TiffPhotometrics.Rgb,
                PlanarConfiguration = TiffPlanarConfigs.Contiguous
            };

            raster.Save(outputPath, tiffOptions);
        }

        // Clean up temporary PNG
        if (File.Exists(tempPngPath))
        {
            try { File.Delete(tempPngPath); } catch { /* ignore cleanup errors */ }
        }
    }
}