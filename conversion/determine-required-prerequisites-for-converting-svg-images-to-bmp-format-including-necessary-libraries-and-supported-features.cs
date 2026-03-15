using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Prerequisites for converting SVG to BMP using Aspose.Imaging:
        // 1. Aspose.Imaging for .NET library (install via NuGet).
        // 2. Reference to Aspose.Imaging.dll in the project.
        // 3. Supported features:
        //    - Loading SVG via Image.Load or SvgImage constructors.
        //    - Vector rasterization using VectorRasterizationOptions (e.g., SvgRasterizationOptions).
        //    - Saving to BMP using BmpOptions.
        //    - Ability to set resolution, background color, and other rasterization settings.
        // 4. Required namespaces are included above.
        // 5. No external dependencies like System.Drawing.

        // Instantiate option objects to ensure the required namespaces are used.
        using (BmpOptions bmpOptions = new BmpOptions())
        {
            bmpOptions.BitsPerPixel = 24;
        }

        using (SvgRasterizationOptions svgRasterOptions = new SvgRasterizationOptions())
        {
            // Example rasterization settings.
            svgRasterOptions.PageSize = new Size(800, 600);
        }

        Console.WriteLine("Prerequisites for converting SVG to BMP with Aspose.Imaging:");
        Console.WriteLine("- Aspose.Imaging for .NET library (install via NuGet).");
        Console.WriteLine("- Using namespaces: Aspose.Imaging, Aspose.Imaging.ImageOptions, Aspose.Imaging.Sources, Aspose.Imaging.FileFormats.Svg, Aspose.Imaging.FileFormats.Bmp.");
        Console.WriteLine("- Load SVG using Image.Load or new SvgImage(stream).");
        Console.WriteLine("- Set VectorRasterizationOptions (e.g., SvgRasterizationOptions) for rasterization.");
        Console.WriteLine("- Save with BmpOptions (e.g., new BmpOptions()).");
        Console.WriteLine("- Ensure proper disposal of Image and option objects (using blocks).");
    }
}