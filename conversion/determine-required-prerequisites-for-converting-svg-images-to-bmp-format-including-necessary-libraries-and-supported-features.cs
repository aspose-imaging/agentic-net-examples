using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Prerequisites for converting SVG to BMP using Aspose.Imaging:

        // 1. Install the Aspose.Imaging for .NET library via NuGet:
        //    Install-Package Aspose.Imaging
        //    This library provides SvgImage, BmpImage, SvgOptions, BmpOptions, etc.

        // 2. .NET runtime (e.g., .NET 6, .NET 7, or .NET Framework 4.6+).
        //    The library targets multiple .NET versions.

        // 3. For BMP output you need:
        //    - Aspose.Imaging.ImageOptions.BmpOptions (to specify bits per pixel, compression, etc.)
        //    - Aspose.Imaging.FileFormats.Bmp.BmpImage (the target raster format).

        // 4. For SVG input you need:
        //    - Aspose.Imaging.FileFormats.Svg.SvgImage (to load the SVG file)
        //    - Aspose.Imaging.ImageOptions.SvgRasterizationOptions (to define rasterization size, DPI, etc.)

        // 5. Supported features during conversion:
        //    - Vector rasterization with custom page size and DPI.
        //    - Background color handling (BackgroundColor property).
        //    - Compression options for BMP (BmpOptions.Compression).
        //    - Resolution settings (BmpOptions.ResolutionSettings).
        //    - Metadata preservation (KeepMetadata property).

        // 6. No additional native dependencies are required; Aspose.Imaging is a self‑contained managed library.

        // 7. Licensing:
        //    - Use a valid Aspose.Imaging license file or evaluation mode.

        Console.WriteLine("Prerequisites for converting SVG to BMP using Aspose.Imaging:");
        Console.WriteLine("- Aspose.Imaging for .NET (NuGet package)");
        Console.WriteLine("- .NET runtime (e.g., .NET 6, .NET 7)");
        Console.WriteLine("- Optional: System.Drawing.Common if you need GDI+ bitmap manipulation");
        Console.WriteLine("- Supported features: vector rasterization, background color, compression, resolution settings, metadata handling");
    }
}