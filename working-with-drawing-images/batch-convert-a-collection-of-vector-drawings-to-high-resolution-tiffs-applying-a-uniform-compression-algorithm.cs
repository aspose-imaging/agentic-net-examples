using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

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

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".tif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is VectorImage)
                    {
                        using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                        {
                            tiffOptions.Compression = TiffCompressions.Lzw;
                            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                            tiffOptions.Photometric = TiffPhotometrics.Rgb;
                            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                            var vectorOptions = new VectorRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = image.Width,
                                PageHeight = image.Height,
                                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                                SmoothingMode = SmoothingMode.None
                            };
                            tiffOptions.VectorRasterizationOptions = vectorOptions;

                            image.Save(outputPath, tiffOptions);
                        }
                    }
                    else
                    {
                        // For non-vector images, simply save as TIFF with default options
                        using (var tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                        {
                            image.Save(outputPath, tiffOptions);
                        }
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
 * 1. When a design studio needs to archive dozens of SVG or AI illustrations as loss‑less, high‑resolution TIFF files with LZW compression to reduce storage costs, this code automates the batch conversion.
 * 2. When a printing company must prepare vector artwork for pre‑press workflows that require TIFF images with specific bits‑per‑sample and RGB photometric settings, the program converts the entire input folder in one step.
 * 3. When a document management system imports vector diagrams and stores them as searchable, high‑quality TIFFs for long‑term preservation, developers can use this script to process all files automatically.
 * 4. When an e‑learning platform generates course materials from vector graphics and needs to deliver them as compressed TIFFs for compatibility with legacy LMS viewers, the code provides a fast batch solution.
 * 5. When a GIS application exports map layers created as vector files and must convert them to TIFF with contiguous planar configuration for efficient raster analysis, this routine handles the conversion and compression across the whole dataset.
 */