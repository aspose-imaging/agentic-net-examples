using System;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        var pngParameters = new List<string>
        {
            nameof(PngOptions.BitDepth),
            nameof(PngOptions.BufferSizeHint),
            nameof(PngOptions.ColorType),
            nameof(PngOptions.FilterType),
            nameof(PngOptions.FullFrame),
            nameof(PngOptions.KeepMetadata),
            nameof(PngOptions.MultiPageOptions),
            nameof(PngOptions.Palette),
            nameof(PngOptions.PngCompressionLevel),
            nameof(PngOptions.Progressive),
            nameof(PngOptions.ResolutionSettings),
            nameof(PngOptions.Source),
            nameof(PngOptions.VectorRasterizationOptions),
            nameof(PngOptions.XmpData),
            nameof(PngOptions.ExifData),
            nameof(PngOptions.ProgressEventHandler)
        };

        Console.WriteLine("PNG conversion input parameters:");
        foreach (var param in pngParameters)
        {
            Console.WriteLine("- " + param);
        }

        using (var options = new PngOptions())
        {
            options.BitDepth = 8;
            options.ColorType = PngColorType.TruecolorWithAlpha;
            options.PngCompressionLevel = PngCompressionLevel.ZipLevel9;
            options.Progressive = true;
            options.FilterType = PngFilterType.Sub;
        }
    }
}