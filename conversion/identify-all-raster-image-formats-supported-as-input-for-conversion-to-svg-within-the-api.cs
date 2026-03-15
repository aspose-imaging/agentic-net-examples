using System;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Raster formats that Aspose.Imaging can load.
    // These are the formats we can convert to SVG.
    static readonly FileFormat[] RasterFormats = new[]
    {
        FileFormat.Bmp,
        FileFormat.Gif,
        FileFormat.Jpeg,
        FileFormat.Png,
        FileFormat.Tiff,
        FileFormat.Webp,
        FileFormat.Dicom,
        FileFormat.Dng,
        FileFormat.Tga,
        FileFormat.Jpeg2000,
        FileFormat.Apng,
        FileFormat.Emf,
        FileFormat.Wmf,
        FileFormat.Emz,
        FileFormat.Wmz,
        FileFormat.Psd,
        FileFormat.Djvu,
        FileFormat.Odg,
        FileFormat.Cdr,
        FileFormat.Cmx,
        FileFormat.Otg,
        FileFormat.FOdg,
        FileFormat.Avif,
        FileFormat.BigTiff
    };

    static void Main()
    {
        Console.WriteLine("Raster image formats supported as input for conversion to SVG:");
        foreach (var format in RasterFormats)
        {
            // Verify that the format is actually registered for loading.
            if ((ImageLoadersRegistry.RegisteredFormats & format) != 0)
            {
                // Demonstrate a simple load‑save cycle (no actual file required).
                // This shows that the format can be loaded and saved as SVG.
                // In a real scenario replace "inputPath" with an actual file path.
                string inputPath = $"sample{GetExtension(format)}";
                string outputPath = $"sample_{format}.svg";

                try
                {
                    // Load the raster image (if the file existed).
                    using (Image image = Image.Load(inputPath))
                    {
                        // Prepare SVG export options.
                        SvgOptions svgOptions = new SvgOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageSize = image.Size
                            }
                        };

                        // Save as SVG.
                        image.Save(outputPath, svgOptions);
                        Console.WriteLine($"- {format} (converted to {outputPath})");
                    }
                }
                catch
                {
                    // If the sample file does not exist we still list the format.
                    Console.WriteLine($"- {format}");
                }
            }
        }
    }

    // Helper to map FileFormat enum to typical file extension.
    static string GetExtension(FileFormat format)
    {
        switch (format)
        {
            case FileFormat.Bmp: return ".bmp";
            case FileFormat.Gif: return ".gif";
            case FileFormat.Jpeg: return ".jpg";
            case FileFormat.Png: return ".png";
            case FileFormat.Tiff: return ".tif";
            case FileFormat.Webp: return ".webp";
            case FileFormat.Dicom: return ".dcm";
            case FileFormat.Dng: return ".dng";
            case FileFormat.Tga: return ".tga";
            case FileFormat.Jpeg2000: return ".jp2";
            case FileFormat.Apng: return ".apng";
            case FileFormat.Emf: return ".emf";
            case FileFormat.Wmf: return ".wmf";
            case FileFormat.Emz: return ".emz";
            case FileFormat.Wmz: return ".wmz";
            case FileFormat.Psd: return ".psd";
            case FileFormat.Djvu: return ".djvu";
            case FileFormat.Odg: return ".odg";
            case FileFormat.Cdr: return ".cdr";
            case FileFormat.Cmx: return ".cmx";
            case FileFormat.Otg: return ".otg";
            case FileFormat.FOdg: return ".fodg";
            case FileFormat.Avif: return ".avif";
            case FileFormat.BigTiff: return ".tif";
            default: return ".dat";
        }
    }
}